using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApi.OptionModels;

namespace WebApi.Common.Swagger
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider" /> service has been resolved from the service container.
    /// </para>
    /// <para>Taken from https://github.com/microsoft/aspnet-api-versioning.</para>
    /// </remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        #region member variables

        private readonly IApiVersionDescriptionProvider _provider;
        private readonly ApiInfoOptions _apiInfo;

        #endregion

        #region constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions" /> class.
        /// </summary>
        /// <param name="provider">
        /// The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger
        /// documents.
        /// </param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IOptions<ApiInfoOptions> apiInfo)
        {
            _provider = provider;
            _apiInfo = apiInfo.Value;
        }

        #endregion

        #region explicit interfaces

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, _apiInfo));
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Internal implementation for building the Swagger basic config.
        /// </summary>
        /// <param name="description">The description object containing the.</param>
        /// <param name="apiInfo"></param>
        /// <returns>The generated Open API info.</returns>
        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description,
            ApiInfoOptions apiInfo)
        {
            var info = new OpenApiInfo
            {
                Title = apiInfo.Title,
                Version = description.ApiVersion.ToString(),
                Description = apiInfo.Description,
                TermsOfService = new Uri(apiInfo.TermsOfService),
                Contact = new OpenApiContact
                {
                    Name = apiInfo.Contact.Name,
                    Email = apiInfo.Contact.Email,
                    Url = new Uri(apiInfo.Contact.Url)
                },
                License = new OpenApiLicense
                {
                    Name = apiInfo.License.Name
                }
            };
            if (description.IsDeprecated)
            {
                info.Description += @"<p><strong><span style=""color:white;background-color:red"">VERSION IS DEPRECATED</span></strong></p>";
            }
            return info;
        }

        #endregion
    }
}

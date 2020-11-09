namespace WebApi.OptionModels
{
    /// <summary>
    /// ApiInfoOptions
    /// </summary>
    public class ApiInfoOptions
    {
        public const string ApiInfo = "ApiInfo";

        public string Title { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public ContactOptions Contact { get; set; }
        public LicenseOptions License { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class ContactOptions
    {
        public const string Contact = "Contact";
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LicenseOptions
    {
        public const string License = "License";
        public string Name { get; set; }
    }
}
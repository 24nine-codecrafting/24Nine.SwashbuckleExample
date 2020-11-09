# Swashbuckle and versioning example implementation

This project gives an example implementation working with swagger, using the Swashbuckle packages as well as how to activate API versioning and giving support to the versioning using Swagger.

# Required NuGet packages

- Swashbuckle.AspNetCore (5.6.3)
- Swashbuckle.AspNetCore.Annotations (5.6.3) 
- Microsoft.AspNetCore.Mvc.Versioning (om versioning te enablen)
- Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer (voor versie discovery zoals lijst van api versioned controllers etc)
- Microsoft.Extensions.PlatformAbstractions

# How to run the api:
## swagger:
adding /swagger/index.html behind your base url

## via postman:
http://localhost:[portnumber]/api/[v1 | v2]/[resource]
### example:
http://localhost:1234/api/v1/products
http://localhost:1234/api/v2/products 

Include Packages:
Swashbuckle
? need to include or not ? Swagger-Net

check the outputting the XML ducumentation file in the build tab of the properties of the project.

Url:
http://localhost:30094/swagger/

if the Comments will be displayed in the swagger, steps:
1. Uncomment the under line in the SwaggerConfig.cs
c.IncludeXmlComments(GetXmlCommentsPath());
2. Adding the GetXmlCommentsPath() method like below
private static string GetXmlCommentsPath()
{
    return string.Format("{0}/bin/SwaggerTest.XML", System.AppDomain.CurrentDomain.BaseDirectory);
}
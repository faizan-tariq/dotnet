# dotnet

- Started off from: https://dotnet.microsoft.com/learn/aspnet/hello-world-tutorial/install
- Install DotNet SDK from: https://dotnet.microsoft.com/download/dotnet-core/3.1
- Install Visual Studio for Mac from: https://visualstudio.microsoft.com/vs/mac/

### DotNet CLI:
````
dotnet tool install --global dotnet-ef
````

### DB Migration:
````
dotnet ef migrations add InitialCreate
dotnet ef database update  
````

### Entity Framework:
- Create Model Class
- Use Scaffolding to generate Database Context and Controller 

<img src="https://github.com/faizan-tariq/dotnet/blob/master/s1.png" width="600">
<img src="https://github.com/faizan-tariq/dotnet/blob/master/s2.png" width="600">


### Generating Swagger Documentation using NSwag
https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio-mac
<img src="https://github.com/faizan-tariq/dotnet/blob/master/s3.png" width="600">


### Use of dependency injection
https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-3.1

Dependency Injection in Controllers
````
private readonly AppContext _context;
private readonly ITimeStamp _timestamp;

public VideoController(AppContext context, ITimeStamp timestamp)
{
    _context = context;
    _timestamp = timestamp;
}
````

### API Versioning
Install-Package Microsoft.AspNetCore.Mvc.Versioning

<img src="https://github.com/faizan-tariq/dotnet/blob/master/s4.png" width="600">

````
services.AddApiVersioning();
````

Now if you hit your api: https://localhost:5001/api/video
````
{"error":{"code":"ApiVersionUnspecified","message":"An API version is required, but was not specified.","innerError":null}}
````
Change Route to: 
````
[Route("api/v{version:apiVersion}/[controller]")]
````
Updated URL: https://localhost:5001/api/v1.0/video

<img src="https://github.com/faizan-tariq/dotnet/blob/master/s5.png" width="600">
<img src="https://github.com/faizan-tariq/dotnet/blob/master/s6.png" width="800">
<img src="https://github.com/faizan-tariq/dotnet/blob/master/s7.png" width="1000">

Changes in Swagger integration after API versioning:
````
 services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    options.ReportApiVersions = true;
});


services.AddVersionedApiExplorer(options =>
 {
     options.SubstituteApiVersionInUrl = true;
 });

services.AddSwaggerDocument();
````


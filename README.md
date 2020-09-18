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

<img src="https://github.com/faizan-tariq/dotnet/blob/master/s1.png" width="800">
<img src="https://github.com/faizan-tariq/dotnet/blob/master/s2.png" width="800">

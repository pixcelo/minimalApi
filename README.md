# minimalApi

プロジェクト作成
```bash
$ dotnet new web -o MinimalApi -f net8.0
```

## Swagger・Swagger UIの追加
`Swagger`の追加
```bash
$ dotnet add package Swashbuckle.AspNetCore --version 6.1.4
```

```cs
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
    });
}

app.MapGet("/", () => "Hello World!");

app.Run();
```
[http://localhost:xxxx/swagger/](http://localhost:5121/swagger/)にアクセス

ビルド
```bash
$ dotnet run
```

## Reference
- [ASP.NET Core を使用した Web API](https://dotnet.microsoft.com/ja-jp/apps/aspnet/apis)
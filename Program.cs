using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using TemplateDotNetApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddSingleton<IRoleService, RoleService>();
builder.Services.AddSingleton<IStatusService, StatusService>();

//app.MapGet("/", () => "Hello World!");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "ToDo API",
            Description = "An ASP.NET Core Web API for managing ToDo items",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Example Contact",
                Url = new Uri("https://example.com/contact")
            },
            License = new OpenApiLicense
            {
                Name = "Example License",
                Url = new Uri("https://example.com/license")
            }
        }
    );
    var xmlFile = "openapi.json";
    var xmlPath = Path.Combine(AppContxt.BaseDirectory, xmlFile);
    options.IncludeJsonComments(xmlFile);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
* Users
*/
app.MapGet(
    "users/all",
    async ([FromServices] IUserService _service) =>
    {
        var lista = _service.GetAll();
        return Results.Ok(lista);
    }
);

app.MapGet(
    "users/{id}",
    async ([FromServices] IUserService _service, [FromRoute] int id) =>
    {
        var item = _service.GetOne(id);
        return Results.Ok(item);
    }
);

/*
* Roles
*/
app.MapGet(
    "roles",
    async ([FromServices] IRoleService _service) =>
    {
        var lista = _service.GetAll();
        return Results.Ok(lista);
    }
);

app.MapGet(
    "roles/{id}",
    async ([FromServices] IRoleService _service, [FromRoute] int id) =>
    {
        var item = _service.GetOne(id);
        return Results.Ok(item);
    }
);

/*
* Status
*/
app.MapGet(
    "status",
    async ([FromServices] IRoleService _service) =>
    {
        var lista = _service.GetAll();
        return Results.Ok(lista);
    }
);

app.MapGet(
    "status/{id}",
    async ([FromServices] IRoleService _service, [FromRoute] int id) =>
    {
        var item = _service.GetOne(id);
        return Results.Ok(item);
    }
);

app.UseSwagger();
app.UseSwaggerUI();
app.Run();

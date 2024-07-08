using Microsoft.AspNetCore.Mvc;
using TemplateDotNetApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddSingleton<IRoleService, RoleService>();
builder.Services.AddSingleton<IStatusService, StatusService>();

//app.MapGet("/", () => "Hello World!");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*
* Users
*/
app.MapGet(
    "users",
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

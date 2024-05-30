using Microsoft.OpenApi.Models;
using TodoInMemoryStore.DB;

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
app.MapGet("/todos/{id}", (int id) => TodoDB.GetTodo(id));
app.MapGet("/todos", () => TodoDB.GetTodos());
app.MapPost("/todos", (Todo todo) => TodoDB.CreateTodo(todo));
app.MapPut("/todos", (Todo todo) => TodoDB.UpdateTodo(todo));
app.MapDelete("/todos/{id}", (int id) => TodoDB.RemoveTodo(id));

app.Run();

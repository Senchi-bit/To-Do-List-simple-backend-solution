using Scalar.AspNetCore;
using ToDoList.API;
using ToDoList.API.ExceptionHandler;
using ToDoList.API.Extensions.Services;
using ToDoList.Application.CQRS;
using ToDoList.Application.Interfaces.CQRS;

var builder = WebApplication.CreateBuilder(args);

builder.AddCommonServices();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

#region CQRS
builder.Services.Scan(scan => scan.FromAssembliesOf(typeof(IQuery<>))
    .AddClasses(filter =>
    {
        filter.AssignableTo(typeof(IQueryHandler<,>));
    })
    .AsImplementedInterfaces()
    .WithScopedLifetime()).Scan(scan => scan.FromAssembliesOf(typeof(ICommand<>))
    .AddClasses(filter =>
    {
        filter.AssignableTo(typeof(ICommandHandler<,>));
    })
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddScoped<IQuerySender, QuerySender>();
builder.Services.AddScoped<ICommandSender, CommandSender>();
#endregion

var app = builder.Build();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
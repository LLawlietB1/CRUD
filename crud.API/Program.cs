using crud.Application.UseCase.User.Create;
using crud.Application.UseCase.User.Delete;
using crud.Application.UseCase.User.Read;
using crud.Application.UseCase.User.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ExecuteCreatedUser>();
builder.Services.AddScoped<ExecuteDeleteUser>();
builder.Services.AddScoped<ExecuteUpdateUser>();
builder.Services.AddScoped<ExecuteReadUser>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

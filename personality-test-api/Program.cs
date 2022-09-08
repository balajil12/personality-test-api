using Microsoft.AspNetCore.Diagnostics;
using personality_test_api.Db.Connections;
using personality_test_api.Db.Repositories;
using personality_test_api.Services;
using personality_test_api.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlite().AddDbContext<AppDb>();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestResultRepository, TestResultRepository>();
builder.Services.AddScoped<IQuestionManager, QuestionManager>();
builder.Services.AddScoped<ITestManager, TestManager>();
builder.Services.AddScoped<IResultManager, ResultManager>();


using (var db = new AppDb())
{
    db.Database.EnsureCreated();
    db.Initialize();
}

var app = builder.Build();

app.UseExceptionHandler(e => e.Run(async context =>
{
    var pathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var ex = pathFeature.Error;

    if(typeof(CustomBadRequest) == ex.GetType())
        context.Response.StatusCode = 400;
    else if(typeof(CustomNotFound) == ex.GetType())
        context.Response.StatusCode = 404;

    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync($"Exception Occurred : {ex.Message}");
}));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(q => q.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

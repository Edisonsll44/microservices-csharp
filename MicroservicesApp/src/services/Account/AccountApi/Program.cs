using Account.Service.Proxies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.Load("Account.Command.Service"));
//builder.Services.AddControllers().AddNewtonsoftJson();
//config db
Account.DependencyResolver.IoCRegisterDataContext.AddRegisterContext(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
Account.DependencyResolver.IoCRegister.AddRegistration(builder.Services);

//Api URL
builder.Services.Configure<ApiUrls>(ops => builder.Configuration.GetSection("ApiUrls").Bind(ops));

var app = builder.Build();

//builder.Services.AddHttpClient();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

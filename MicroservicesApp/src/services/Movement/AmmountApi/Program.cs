using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Movement.Proxy;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var secretKey = builder.Configuration.GetValue<string>("secretKey");
// Add services to the container.
builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(t =>
{
    t.RequireHttpsMetadata = false;
    t.SaveToken = true;
    t.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Movement.DependencyResolver.IoCRegisterDataContext.AddRegisterContext(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
Movement.DependencyResolver.IoCRegister.AddRegistration(builder.Services);

builder.Services.Configure<ApiUrls>(ops => builder.Configuration.GetSection("ApiUrls").Bind(ops));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

using ClientPersistenceDatabase;
using DependencyResolver;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config db
//builder.Services.AddDbContext<ApplicationDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//        x => x.MigrationsHistoryTable("__EFMigrationHystory", "client"));
//});
IoCRegisterDataContext.AddRegisterContext(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
IoCRegister.AddRegistration(builder.Services);

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

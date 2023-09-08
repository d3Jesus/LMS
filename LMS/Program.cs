using LMS.API.MappingConfig;
using LMS.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddInfrastructure();
builder.Services.AddAutoMapperConfiguration();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services
       .ConfigureJwtAuthentication(builder.Configuration)
       .ConfigureCors();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SetupLogging.Development();
}
else
{
    SetupLogging.Production();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

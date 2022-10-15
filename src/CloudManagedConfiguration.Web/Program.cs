using CloudManagedConfiguration.Application;
using CloudManagedConfiguration.Config;
using CloudManagedConfiguration.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddConfiguration(builder.Configuration, $"/CloudManagedConfiguration/{builder.Environment.EnvironmentName}/");

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddHttpClient<IUniversitiesService, UniversitiesService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
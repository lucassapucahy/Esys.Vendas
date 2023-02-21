using Esys.Vendas.Infra.Ioc;
using Esys.Vendas.Infra.Ioc.Domain;
using Esys.Vendas.Infra.Ioc.Infra;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraDependencies(builder.Configuration);
builder.Services.AddDomainDependencies(builder.Configuration);
builder.Services.AddLogging();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.RunEntityMigrations();
app.RunRabbitStartup();
app.Run();
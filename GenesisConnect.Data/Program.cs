using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using GenesisConnect.Data.DatabaseContext;
using GenesisConnect.Data.Interface;
using GenesisConnect.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//***********implement a way to get connectionstring information ********

// Add services to the container.
var keyVaultUri = "https://GenesisConnect.vault.azure.net/"; // Replace with your Key Vault's URI
var secretName = "GenesisConnectDbConnectionString";

var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
KeyVaultSecret secret = await client.GetSecretAsync(secretName);
var connectionString = secret.Value;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();

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

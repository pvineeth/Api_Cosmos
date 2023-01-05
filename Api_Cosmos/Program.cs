using Api_Cosmos.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IcarCosmosService>(options =>
{
    string Url=builder.Configuration.GetSection("AzureCosmosDBsetting").GetValue<string>("URL");
    string primaryKey = builder.Configuration.GetSection("AzureCosmosDBsetting").GetValue<string>("PrimaryKey");
    string databaseName = builder.Configuration.GetSection("AzureCosmosDBsetting").GetValue<string>("DatabaseName");
    string containerName = builder.Configuration.GetSection("AzureCosmosDBsetting").GetValue<string>("ContainerName");
    var cosmosClient = new CosmosClient(Url, primaryKey);
    return new CarCosmosService(cosmosClient,databaseName,containerName);
});

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

using Amazon.DynamoDBv2;
using BackgroundService.Services;
using BackgroundService.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(awsOptions);

builder.Services.Configure<DynamoDbSettings>(builder.Configuration.GetSection(DynamoDbSettings.KeyName));

builder.Services.AddAWSService<IAmazonDynamoDB>(awsOptions);

builder.Services.AddScoped<IDynamoDbService, DynamoDbService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

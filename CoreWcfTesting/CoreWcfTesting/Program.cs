using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWcfTesting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

builder.Services.AddServiceModelWebServices();

builder.Services.AddScoped<SomeCoolService>();

var app = builder.Build();

var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseServiceModel(builder =>
{
    builder.AddService<SomeCoolService>();
    builder.AddServiceEndpoint<SomeCoolService, ISomeCoolService>(new BasicHttpBinding(), "SomeCoolService.svc");
    builder.AddServiceWebEndpoint<SomeCoolService, ISomeCoolService>(new WebHttpBinding(), "SomeCoolService.svc/json");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

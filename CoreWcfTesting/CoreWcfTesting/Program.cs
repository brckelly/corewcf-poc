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

builder.Services.AddScoped<SomeCoolService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseServiceModel(builder =>
{
    builder.AddService<SomeCoolService>().AddServiceEndpoint<SomeCoolService, ISomeCoolService>(new BasicHttpBinding(), "SomeCoolService.svc");
    //////builder.AddServiceWebEndpoint<NotificationServer, INotificationService>(new WebHttpBinding(), "json");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

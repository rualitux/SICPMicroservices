using EnumeradoService.AsyncDataServices;
using EnumeradoService.Data;
using EnumeradoService.Interfaces;
using EnumeradoService.Repository;
using EnumeradoService.SyncDataServices.Http;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IEnumeradoRepository, EnumeradoRepository>();
builder.Services.AddHttpClient<IInventarioDataClient, HttpInventarioDataClient>();
//una conexión para toda la aplicación
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
DbCalata.PrepPopulation(app);

app.Run();

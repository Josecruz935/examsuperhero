using superheores;
using superheores.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<context>("Data Source=localhost; Initial Catalog=libreriaDB;user id=sa;password=Programaci0n$;Encrypt=False");
builder.Services.AddScoped<IcolourService, colourService>();
builder.Services.AddScoped<IgenderService, genderService>();
builder.Services.AddScoped<IpublisherService, publisherService>();


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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger only in the development environment
    app.UseSwagger();
    app.UseSwaggerUI();  // To serve the Swagger UI
}

app.UseRouting();

app.MapControllers();

app.Run();

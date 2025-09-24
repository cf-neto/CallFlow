var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder =>
        {
            builder
                .WithOrigins("http://127.0.0.1:5500") // URL do seu front-end
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// Adiciona controllers
builder.Services.AddControllers();

// Adiciona Swagger (opcional, mas recomendado)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

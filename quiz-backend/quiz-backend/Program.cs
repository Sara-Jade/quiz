using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using quiz_backend;

var builder = WebApplication.CreateBuilder(args);

static void configurePolicy(CorsPolicyBuilder builder)
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}
// Add services to the container.
builder.Services.AddCors(opt => opt.AddPolicy("Cors", configurePolicy));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuizContext>(opt => opt.UseInMemoryDatabase("quiz"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

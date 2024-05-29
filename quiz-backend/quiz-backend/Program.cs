using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using quiz_backend;
using System.Text;

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
builder.Services.AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("user"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UserDbContext>();
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super secret key. Don't use here if this were prod."));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = signingKey,
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseCors("Cors");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

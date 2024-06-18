using HIVBackend.Data;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HivContext>(options => options.UseNpgsql(connection));

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueCountLimit = int.MaxValue;
});

builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var options = new RewriteOptions();
//options.AddRedirectToHttps(5000);
//app.UseRewriter(options);

app.UseCors("EnableCORS");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("en-GB"),
                new CultureInfo("en"),
                new CultureInfo("ru-RU"),
                new CultureInfo("ru"),
                new CultureInfo("de-DE"),
                new CultureInfo("de")
            };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("ru-RU"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.Run();

public class AuthOptions
{
    public const string ISSUER = "MISServer"; // издатель токена
    public const string AUDIENCE = "MISServer"; // потребитель токена
    const string KEY = "eaghFnHlqByi6MaoZmnQRQMAT3dAm4";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(KEY));
}
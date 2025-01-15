

using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Unisoft_Project.Core.Contracts;
using Unisoft_Project.Core.Services;
using Unisoft_Project.Infrastructure.Data;
using System.Text;

namespace Unisoft_Project.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);






            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("InMemoryDb"));


            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {

                    var secretKey = builder.Configuration["JwtSettings:SecretKey"];
                    var issuer = builder.Configuration["JwtSettings:Issuer"];
                    var audience = builder.Configuration["JwtSettings:Audience"];


                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });


            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHighlightService, HighlightService>();

            var app = builder.Build();

            

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}

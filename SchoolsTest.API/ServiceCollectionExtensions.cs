using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolsTest.Data;
using SchoolsTest.Models.Constants;
using System.Security.Claims;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = AuthOptions.ISSUER,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                };
            });

        services.AddIdentityCore<IdentityUser<int>>(o =>
        {
            o.Stores.MaxLengthForKeys = 128;
        })
            .AddSignInManager()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.SystemAdmin, policy =>
            {
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManageSchool);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManagePosition);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManageRoomType);
            });

            options.AddPolicy(Policies.SchoolAdmin, policy =>
            {
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManageSchoolUsers);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManageEmployee);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.OperatePositionsInSchool);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.OperateRoomTypesInSchool);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManageFloor);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManageRoom);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.ManageStudent);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.FullInfoStudent);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.FullInfoEmployee);
            });

            options.AddPolicy(Policies.Authorized, policy =>
            {
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.InfoSchool);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.InfoEmployee);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.InfoStudent);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.InfoRoom);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.InfoFloor);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.InfoPosition);
                policy.RequireClaim(ClaimNames.Permission, ClaimValues.InfoRoomTypes);
            });
        });

        return services;
    }
}
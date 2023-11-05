using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SchoolsTest.Data;
using SchoolsTest.Data.DTOs;
using SchoolsTest.Models.Interfaces;
using System.Runtime.CompilerServices;

namespace SchoolsTest.API;

public class SchoolIdChecker
{
    private readonly RequestDelegate _next;

    private readonly ISchoolRepository _repository;

    private readonly AppDbContext _dbContext;

    public SchoolIdChecker(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context, int id)
    {
        //var schoolId = _repository.Get(id);

        //if (schoolId is null)
        //{
        //    Results.NotFound("SchoolId not found, create school before create this object");
        //}

        var schoolIdQuery = context.Request.Query["schoolId"];

        if (!string.IsNullOrWhiteSpace(schoolIdQuery))
        {
            if(_dbContext == null)
            {
                await context.Response.WriteAsJsonAsync("Bad request");
                await _next(context);
            }
        }

        var schoolIdBody = context.Request.Body;

        if(schoolIdBody != null)
        {
            if (_dbContext == null)
            {
                await context.Response.WriteAsJsonAsync("Bad request");
                await _next(context);
            }
        }

        var schoolIdHeaders = context.Request.Headers;

        if (!schoolIdHeaders.IsNullOrEmpty())
        {
            if (_dbContext == null)
            {
                await context.Response.WriteAsJsonAsync("Bad request");
                await _next(context);
            }
        }

        //var school = await _repository.Get(schoolId);

        await _next(context);
    }

}
public static class SchoolIdCheckerExtensions
{
    public static IApplicationBuilder UseSchoolIdChecker(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SchoolIdChecker>();
    }
}

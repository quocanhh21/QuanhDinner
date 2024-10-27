var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);

    //builder.Services.AddControllers(options =>
    //{
    //    options.Filters.Add<ErrorHandlingFilterAttribute>();
    //});
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, QuanhDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    //app.Map("/error", (HttpContext httpContext) =>
    //{
    //    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    //    return Results.Problem();
    //}); // For minimal APIs, this is not needed
    //app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}
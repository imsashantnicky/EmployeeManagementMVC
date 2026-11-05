using Asp.Versioning;

using Asp.Versioning.ApiExplorer;
using EmployeeManagementMVC.Repositories;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services
.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = false;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee Management API",
        Version = "v1",
        Description = "Employee API contract, version 1."
    });
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Employee Management API",
        Version = "v2",
        Description = "Employee API contract, version 2."
    });
    options.DocInclusionPredicate((documentName, apiDescription) =>

    string.Equals(
    apiDescription.GroupName,
    documentName,
    StringComparison.OrdinalIgnoreCase));
});
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
        "Employee API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json",
        "Employee API v2");
        options.RoutePrefix = "swagger";
    });
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WikiFloraAPI;
using WikiFloraAPI.Data;
using WikiFloraAPI.Models;
using WikiFloraAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IFloraService, FloraService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IClaimsTransformation,KeycloakClaimsTransformation>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy => { policy.WithOrigins("http://localhost:4200/").WithMethods("GET", "POST", "DELETE", "PUT").AllowAnyOrigin().AllowAnyHeader(); });
});
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = (context) =>
    {
        var exceptionError = context.HttpContext.Features.Get<ExceptionHandler>();
        context.ProblemDetails.Detail = exceptionError?.details;
    };
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    AuthOption authOption = builder.Configuration.GetSection("AuthOption").Get<AuthOption>()!;
    x.MetadataAddress = authOption.serverBaseUrl + "/.well-known/openid-configuration";
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = authOption.serverBaseUrl,
        ValidateAudience = true,
        ValidAudience = "account",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOption.secret)),
        
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(2),
    };
});

builder.Services.AddAuthorization(option =>
{
    option.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    option.AddPolicy( "Admin", policy => { policy.RequireAssertion(context => context.User.IsInRole("admin")); } );

});

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"FloraPhotos")),
    RequestPath = "/photo"
});
app.Run();

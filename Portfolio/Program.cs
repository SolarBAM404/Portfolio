using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Components;
using Portfolio.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

// Add services to the container.
IServiceCollection services = builder.Services;
services.AddRazorComponents()
    .AddInteractiveServerComponents();

services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

DbSettings dbSettings = new DbSettings(
    config.GetValue<string>("Database:ConnectionString"), 
    config.GetValue<string>("Database:DatabaseName")
);

services.AddIdentityMongoDbProvider<MongoUser>(identity =>
    {
        identity.Password.RequiredLength = 8;
    }, mongo =>
    {
        mongo.ConnectionString = dbSettings.ConnString + "/" + dbSettings.DatabaseName;
    });

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
services.AddAuthentication(options =>
{
    //Set default Authentication Schema as Bearer
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme =
        JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidIssuer = config["JwtIssuer"],
            ValidAudience = config["JwtIssuer"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"])),
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
});

services.AddMongoDB<PortfolioContext>(dbSettings.ConnString + "/" + dbSettings.DatabaseName);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
    // .AddAdditionalAssemblies(typeof(_Imports).Assembly);

app.Run();


class DbSettings
{
    public string ConnString { get; set; }
    public string DatabaseName { get; set; }

    public DbSettings(string connString, string databaseName)
    {
        ConnString = connString;
        DatabaseName = databaseName;
    }
}
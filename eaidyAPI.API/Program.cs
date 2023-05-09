using eaidyAPI.Business.Abstract;
using eaidyAPI.Business.Concrete;
using eaidyAPI.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

// Kestrel ports for IP4 usage on API Url instead of 'localhost'
const int HTTP_PORT = 5001,
          HTPPS_PORT = 7001;

var builder = WebApplication.CreateBuilder(args);

// Kestrel configuration
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(HTTP_PORT); // to listen for incoming http connection on HTTP_PORT
    options.ListenAnyIP(HTPPS_PORT, configure => configure.UseHttps()); // to listen for incoming https connection on HTTPS_PORT
});

builder.Services.AddControllers();

// Adding CORS (Cross Origin Resource Sharing) policy to allow all origins
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Dependency Injection (DI)
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "eaidy Web API";
        doc.Info.Version = "1.0.1";
        doc.Info.Contact = new NSwag.OpenApiContact()
        {
            Name = "Ata Çalışkan",
            Url = "https://www.eaidy.com",
            Email = "atacaliskan@hotmail.com.tr"
        };
    });
});

var app = builder.Build();

// Applying CORS policy configured above.
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseOpenApi();
// Using swagger UI for API Docs.
app.UseSwaggerUi3();
// Controller Mapping Service.
app.MapControllers();

app.Run();


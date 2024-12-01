using Libs;
using Libs.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;

using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Libs.Entity;
using Libs.Service;
using Libs.Repositories;
using Libs.Repositoory;
using Libs.Helps;
using MailKit;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                policy =>
                {
                    policy.AllowAnyOrigin()     // Allow any origin
                          .AllowAnyHeader()     // Allow any headers
                          .AllowAnyMethod();    // Allow any HTTP methods (GET, POST, etc.)
                });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = "503398515807-l1f0qncmcvuqiol4r60789eemiu05nm0.apps.googleusercontent.com";
    options.ClientSecret = "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";
    options.CallbackPath = "/signin-google";
    /*    options.Events.OnAuthenticationFailed = context =>
            {
                context.Response.Redirect("/Account/Login");
                context.HandleResponse(); // Suppress the exception
                return Task.CompletedTask;
            };*/
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "VipPro" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

}, ServiceLifetime.Transient);

// Identity service
builder.Services.AddIdentity<AppUser , IdentityRole>(Options => {
    Options.Password.RequireDigit = true;
    Options.Password.RequireLowercase = true;
    Options.Password.RequireUppercase = true;
    Options.Password.RequireNonAlphanumeric =true;
    Options.Password.RequiredLength = 12;
})
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(Options => {
    Options.DefaultAuthenticateScheme = 
    Options.DefaultChallengeScheme =
    Options.DefaultForbidScheme =
    Options.DefaultScheme =
    Options.DefaultSignInScheme =
    Options.DefaultSignOutScheme =JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer( Options => {
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:Signingkey"])
        )
    };
}
);

builder.Services.AddTransient<SellService>();
builder.Services.AddTransient<FinanceService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ImessageRepository, MessageRepository>();
builder.Services.AddScoped<IToken, TokenRepository>(); 
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddTransient<IIMail, MailRepository>();
builder.Services.AddTransient<MailServices>();
// build session for website 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddControllersWithViews();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); 
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(@"D:\DACN\DoAnChuyenNghanh\WebApi\WebApi\images"),
    RequestPath = "/images"
});


app.UseCors("AllowAll");

app.UseAuthentication();
 
app.UseAuthorization(); 

app.MapControllers();

app.UseSession();

app.Run();

using BonozWeb.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BanazDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BONOZDB")));

// Add services to the container.

//builder.Services.AddSession();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISales, SalesManager>();
builder.Services.AddScoped<ISecurity, SecurityManager>();
builder.Services.AddScoped<IAuthService, AuthServiceManager>();
builder.Services.AddScoped<NotificationService>();


#region Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    //options.AccessDeniedPath = new PathString("/UnAuthorized");
    options.LoginPath = new PathString("/Login");
    options.LogoutPath = new PathString("/Logout");
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = System.TimeSpan.FromHours(2);
});

builder.Services.AddHttpContextAccessor();

#endregion

builder.Services.AddSession(s => { s.IdleTimeout = System.TimeSpan.FromHours(7); });

#region Authorization

//builder.Services.AddAuthorization(op =>
//{
//    op.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();

//    //foreach (int eVal in Enum.GetValues(typeof(PrivilegedResource)))
//    //{
//    //    string name = Enum.GetName(typeof(PrivilegedResource), eVal);
//    //    op.AddPolicy(name, x => x.Requirements.Add(new PrivilegedResourceRequirement(eVal)));
//    //}
//    //op.AddPolicy("AllClear", op.DefaultPolicy);
//});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

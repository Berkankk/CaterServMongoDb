using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Services.Concrete;
using CaterServMongoDb.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryService, CategoryService>();//Reg�strat�on i�lemi yaparak bunlar� g�sterdik her servis i�in yap�lacak
builder.Services.AddScoped<IPRoductService, ProductService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICheffService, CheffService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IEventCategoryService, EventCategoryService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());  //Mapleme i�lemini verdik burada

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //Appsettings de olan de�eri girdik
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

//yukar�da da interface i�lemini tan�mlad�k



builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

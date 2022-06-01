using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreApp.Business.Abstract;
using StoreApp.Business.Concrete;
using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.Concrete.EfCore;
using StoreApp.WEBUI.EmailServices;
using StoreApp.WEBUI.Identity;
using StoreApp.WEBUI.Middlewares;


namespace StoreApp.WEBUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

       
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>();
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"))
            ) ;


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "StoreApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict

                };
            });

            services.AddScoped<IAdvertisedDAL, EfCoreAdvertisedDAL>();
            services.AddScoped<ICartDAL, EfCoreCartDAL>();
            services.AddScoped<ICategoryDAL, EfCoreCategoryDAL>();
            services.AddScoped<ICategorySubDAL, EfCoreCategorySubDAL>();
            services.AddScoped<IFavoriteDAL, EfCoreFavoriteDAL>();
            services.AddScoped<IOrderDAL, EfCoreOrderDAL>();
            services.AddScoped<IProductDAL, EfCoreProductDAL>();



            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IAdvertisedService, AdvertisedManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategorySubService, CategorySubManager>();
            services.AddScoped<IFavoriteService, FavoriteManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IProductService, ProductManager>();



            
            //services.AddTransient<IEmailService, SmtpEmailSender>();
            
            
            services.AddTransient<IEmailService, SmtpEmailSender>(i=> new SmtpEmailSender(Configuration["EmailSender:Host"],
                Configuration.GetValue<int>("EmailSender:Port"), Configuration["EmailSender:UserName"],
                Configuration["EmailSender:Password"], Configuration.GetValue<bool>("EmailSender:EnableSSL")));

            services.AddControllersWithViews();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.CustomStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "userProducts",
                    pattern: "user/products",
                    defaults: new { controller = "User", action = "ProductList" }
                    );

                endpoints.MapControllerRoute(
                    name: "userProducts",
                    pattern: "user/products/{id?}",
                    defaults: new { controller = "User", action = "EditProduct" }
                    );

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "products/{categorysub?}",
                    defaults: new { controller = "Store", action="Products" }
                    );



                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "cart",
                    defaults: new { controller = "Cart", action = "Index" }
                    );

                endpoints.MapControllerRoute(
                    name: "myproducts",
                    pattern: "myproducts",
                    defaults: new { controller = "User", action = "MyProducts" }
                    );

                endpoints.MapControllerRoute(
                   name: "orders",
                   pattern: "orders",
                   defaults: new { controller = "Cart", action = "GetOrders" }
                   );

                endpoints.MapControllerRoute(
                   name: "checkout",
                   pattern: "checkout",
                   defaults: new { controller = "Cart", action = "Checkout" }
                   );
                endpoints.MapControllerRoute(
                   name: "favorite",
                   pattern: "favorite",
                   defaults: new { controller = "Favorite", action = "Index" }
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedIdentity.Seed(userManager,roleManager,Configuration).Wait();
            
        }
    }
}

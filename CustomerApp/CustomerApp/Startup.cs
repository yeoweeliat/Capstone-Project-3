using CustomerApp.DbContextCustomer;
using CustomerApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// new keyword leads to tight coupling, change one part of the code, need to change multiple places,
// cant we just change 1 part of code and all changed (like a switch)?
// to solve this, we can use DI
// one change at one place, change reflected in multiple places across the code (good)

// DI with decoupling -> change at 1 place and change reflected across the entire application
// DI cannot be injected across family (parent child inheritance)
namespace CustomerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // set breakpoint here and add watch to check connection string, env test etc

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // add code for dependency injection
            //services.AddScoped<CustomerDbContext>();


            // think of what scenario you are in, use the right one

            // create instance once, inject the same instance everywhere (per browser request made to the server)
            // used when instantiating models / DbContext (99% of the time, often used)
            //services.AddScoped<Customer>(); // inject customer model to api
            services.AddScoped<Customer,CustomerDiscounted>();

            // seperate transaction, when you want to isolate transaction
            // AddTransient =  different instance injected., instantiates every single time the service is injected, same 
            //services.AddTransient<Customer>();



            // AddSingleton - Guid will not change, one big global object shared through all browser requests (close browser, open another browser, same guid, same object instance).
            //services.AddSingleton<Customer>(); // when you want to share global data across all clients (cache)



            services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);


            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            services.AddDbContext<CustomerDbContext>(options =>
            options.UseSqlServer(Configuration["ConnString"]));


            // Code 2 -> for httpsession
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // add sequence of firing (middleware in startup.cs)
            app.UseMiddleware<LogRequests>();
            app.UseMiddleware<CheckSecurity>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Code 3 -> for httpsession
            app.UseSession(); // add

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("MyPolicy"); // add CORS, allow CORS on all controllers (Cross Origin Resource Sharing)

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

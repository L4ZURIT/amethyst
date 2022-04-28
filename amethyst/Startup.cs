using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


using amethyst.Data.DataBase;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace amethyst
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContent>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc();  
            services.AddTransient<IAllAppeals, AppealRepository>();
            services.AddTransient<IAllUsers, UsersRepository>();
            services.AddTransient<IRegisterNewUser, RegisterRepository>();
            services.AddTransient<INewAccount, NewAccount>();

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
            services.AddControllersWithViews();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            

        }
    } 


}

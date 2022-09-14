using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Services.ImplService.SysBasic;
using Services.IService.SysBasic;
using Repository.IRepository.SysBasic;
using Repository.ImpRepository.SysBasic;
using EFData;
using System;
using Microsoft.AspNetCore.Mvc;
using Services.ImpService.SysBasic;
using Common;

namespace StudentInfoSystem
{
    public class Startup
    {
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration,IWebHostEnvironment en)
        {
            Configuration = configuration;
            WebHostEnvironment = en;
            GlobalContent.HostEnvironment = en;
             
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DataContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<EFDataContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DataContext")));

            #region
            //services.AddScoped(typeof(EFDataContext));   
            services.AddTransient<ISys_UserAndRoleRepository, ImpSys_UserAndRoleRepository>();
            services.AddTransient<ISys_UserAndRoleService, ImplSys_UserAndRoleService>();


            services.AddTransient<ISys_RoleRepository, ImpSys_RoleRepository>();  
            services.AddTransient<ISys_RoleService, ImplSys_RoleService>();   

            services.AddTransient<ISys_RoleAndAuthorityRepository, ImpSys_RoleAndAuthorityRepository>();
            services.AddTransient<ISys_RoleAndAuthorityService, ImplSys_RoleAndAuthorityService>();

            services.AddTransient<ISys_MenuAuthorityRepository, ImpSys_MenuAuthorityRepository>();
            services.AddTransient<ISys_MenuAuthorityService, ImplSys_MenuAuthorityService>();

            services.AddScoped<ISys_MenuRepository, ImpSys_MenuRepository>();
            services.AddScoped<ISys_MenuService, ImplSys_MenuService>();


            services.AddTransient<ISys_AuthorityRequestRepository, ImpSys_AuthorityRequestRepository>();
            services.AddTransient<ISys_AuthorityRequestService, ImplSys_AuthorityRequestService>();
            services.AddTransient<ISys_MenuRepository, ImpSys_MenuRepository>();
            services.AddTransient<ISys_MenuService, ImplSys_MenuService>();
            services.AddTransient<ISys_UserRepository, ImpSys_UserRepository>();
            services.AddTransient<ISys_UserService, ImplSys_UserService>();

            #endregion
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0

            //services.AddDistributedMemoryCache();
            //¿ªÆôsession
            services.AddSession(options =>{
                                options.IdleTimeout = TimeSpan.FromMinutes(20);
                                options.Cookie.Name = "test";});

           

            services.AddControllersWithViews();
            

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(opt => { opt.LoginPath = new PathString("/Login/Login/"); });


            GlobalContent.SystemConfig = Configuration.GetSection("SystemConfig").Get<SystemConfig>();
            GlobalContent.Services = services;
            GlobalContent.Configuration = Configuration;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();//Ê¹ÓÃSession

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.EntityFramework;
using Repositories.EntityFramework.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System.IO;
using CustomerInquiryWebApi.Services;
using AutoMapper;
using CustomerInquiryWebApi.Extensions;
using CustomerInquiryWebApi.Mapping;

namespace CustomerInquiryWebApi
{
    public class Startup
    {
        private readonly Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<СustomerInquiryDbContext>(options =>
                options.UseSqlServer(connectionString: Configuration.GetConnectionString("msSQLConnectionString")));

            ConfigureMapping(services);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            IntegrateSimpleInjector(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app, env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            container.Verify(); // Get all benefits from Simple Injector
           
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void InitializeContainer(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            container.Register<ICustomerRepository, CustomerRepository>();
            container.Register<ITransactionRepository, TransactionRepository>();
            container.Register<ICustomerService, CustomerService>();

            container.AutoCrossWireAspNetComponents(app);
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        private void ConfigureMapping(IServiceCollection services)
        {
            services.AddAutoMapper(mc =>
            {
                mc.AddProfile(new CustomerMappingProfile());
                mc.AddProfile(new TransactionMappingProfile());
            });


        }
    }
}

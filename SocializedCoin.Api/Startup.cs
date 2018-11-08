using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<ILatestDataRepository, LatestDataRepository>();
            services.AddSingleton<IGeneralDataRepository, GeneralDataRepository>();
            services.AddSingleton<ILatestWithGeneralDataRepository, LatestWithGeneralDataRepository>();
            services.AddSingleton<IMarketExchangeRepository, MarketExchangeRepository>();
            services.AddSingleton<IGlobalMetricsRepository, GlobalMetricsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:8080").AllowAnyHeader());

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
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
            services.AddScoped<ILatestDataRepository, LatestDataRepository>();
            services.AddScoped<IGeneralDataRepository, GeneralDataRepository>();
            services.AddScoped<IMarketExchangeRepository, MarketExchangeRepository>();
            services.AddScoped<IGlobalMetricsRepository, GlobalMetricsRepository>();
            services.AddScoped<ICryptoListRepository, CryptoListRepository>();
            services.AddScoped<ITopCryptoRepository, TopCryptoRepository>();
            services.AddScoped<IDashboardListRepository, DashboardListRepository>();
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
using Garden.Core.DAL;
using Garden.Core.DAL.Fetch.Articles;
using Garden.Core.DAL.Repository;
using Garden.Core.DAL.Sort;
using Garden.Core.DAL.Specification;
using Garden.DAL;
using Garden.DAL.Fetch.Articles;
using Garden.DAL.Repository;
using Garden.DAL.Sort;
using Garden.DAL.Specification;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unity;

namespace Garden.WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            //container.RegisterType<IStorageContext, StorageContext>();
            container.RegisterType<IStorage, Storage>();
            container.RegisterType<IArticleRepository, ArticleRepository>();

            container.RegisterType<IArticleBuilder, ArticleBuilder>();
            container.RegisterType<IFetchArticleWithNothing, FetchArticleWithNothing>();
            container.RegisterType<IFetchArticleWithComments, FetchArticleWithComments>();
            container.RegisterType<ISortArticle, SortArticle>();
        }
    }
}

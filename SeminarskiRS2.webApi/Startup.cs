using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using SeminarskiRS2.webApi.Filters;
using SeminarskiRS2.webApi.Security;
using SeminarskiRS2.webApi.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;

namespace SeminarskiRS2.webApi
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
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen();
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddAutoMapper();
            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<ICRUDService<Model.Drzave, DrzaveSearchRequest,DrzaveInsertRequest, DrzaveInsertRequest>, DrzaveService>();
            services.AddScoped<ICRUDService<Model.Grad, GradoviSearchRequest, GradoviInsertRequest,GradoviInsertRequest>, GradoviService>();
            services.AddScoped<ICRUDService<Model.Ulaznice, UlazniceSearchRequest, UlazniceInsertRequest, UlazniceInsertRequest>, UlazniceService>();
            services.AddScoped<ICRUDService<Model.Lige, LigaSearchRequest, LigaInsertRequest, LigaInsertRequest>, LigeService>();
            services.AddScoped<ICRUDService<Model.Timovi, TimoviSearchRequest, TimoviInsertRequest, TimoviInsertRequest>, TimoviService>();
            services.AddScoped<ICRUDService<Model.Stadioni, StadioniSearchRequest, StadioniInsertRequest, StadioniInsertRequest>, StadioniService>();
            services.AddScoped<ICRUDService<Model.Tribine, TribineSearchRequest, TribineInsertRequest, TribineInsertRequest>, TribineService>();
            services.AddScoped<ICRUDService<Model.Sektori, SektoriSearchRequest, SektoriInsertRequest, SektoriInsertRequest>, SektoriService>();
            services.AddScoped<ICRUDService<Model.Sjedala, SjedalaSearchRequest, SjedalaInsertRequest, SjedalaInsertRequest>, SjedalaService>();
            services.AddScoped<ICRUDService<Model.Utakmice, UtakmiceSearchRequest, UtakmiceInsertRequest, UtakmiceInsertRequest>, UtakmiceService>();
            services.AddScoped<ICRUDService<Model.Preporuke, PreporukaSearchRequest, PreporukaInsertRequest, PreporukaInsertRequest>, PreporukeService>();
            services.AddScoped<ICRUDService<Model.Uplate, UplateSearchRequest, UplateInsertRequest, UplateInsertRequest>, UplateService>();

            //registracija
            services.AddScoped<GradoviService, GradoviService>();
            services.AddScoped<DrzaveService, DrzaveService>();

            var connection = Configuration.GetConnectionString("SeminarskiRS2");
            services.AddDbContext<_170120Context>(options => options.UseSqlServer(connection));
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
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}

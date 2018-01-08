using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hello
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
      services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      }));
      services.AddMvc();
      //services.AddCors(options =>
      //{
      //  options.AddPolicy("AllowSpecificOrigin",
      //      builder => builder.WithOrigins("http://localhost:55658/api/hello"));
      //});
     
      services.Configure<MvcOptions>(options =>
      {
        options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      // Shows UseCors with CorsPolicyBuilder.
      // Shows UseCors with named policy.
      //app.UseCors("AllowSpecificOrigin");
      // Enable Cors
      app.UseCors("MyPolicy");
      app.UseDefaultFiles();
      app.UseDefaultFiles();
      app.UseMvc();
    }
  }
}

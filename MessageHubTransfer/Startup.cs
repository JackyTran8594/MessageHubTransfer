using MessageHubTransfer.Hubs;
using MessageHubTransfer.Workerservice;
using Microsoft.Extensions.Logging;


namespace MessageHubTransfer
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
            
            //services.AddRazorPages();
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHostedService<WorkerService>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            // add logging
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
          

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                //x.SwaggerEndpoint("/swagger/v1/swagger.json", "Baha'i Prayers API");
                //x.InjectStylesheet("/swagger/custom.css");
                //x.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MessageBrokerHub>("/messageBroker");
                endpoints.MapHub<ServerDataHub>("/serverData");
                endpoints.MapHub<ClockServerHub>("/clockData");
                endpoints.MapControllers();
            });

  
        }

    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Library.Infra.CrossCutting.Extension
{
    public static class SwaggerConfig
    {
        public static void SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Fernando's Library ",
                        Version = "v1",
                        Description = "Sitema para avaliação do Mestre Brandão  ",
                        Contact = new Contact
                        {
                            Name = "Fernando Santana Pinto",
                            Url = "https://github.com/fernandosp",
                            Email = "pintofs1@hotmail.com"
                        }
                    });
            });
        }

        public static void SwaggerApplication(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Livraria ");
            });
        }
    }
}
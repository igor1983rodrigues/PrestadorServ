using Microsoft.Owin.Cors;
using Owin;
using PrestadorServ.Models.Dao;
using PrestadorServ.Models.IDao;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace PrestadorServ
{
    internal static class StartupExtensao
    {
        public static void Configurar(this Container container)
        {
            container.Register<IClienteDao, ClienteDao>();
        }
    }

    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var container = new Container();

            container.Configurar();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            var httpConfiguration = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(container)
            };

            //-- Habilita Cores
            app.UseCors(CorsOptions.AllowAll);

            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}

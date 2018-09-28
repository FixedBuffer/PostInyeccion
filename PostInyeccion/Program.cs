using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostInyeccion.Models;
using PostInyeccion.Services;

namespace PostInyeccion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generamos la coleccion de servicios
            IServiceCollection serviceCollection = new ServiceCollection();
            //Registramos el DbContext
            serviceCollection.AddDbContext<PostDbContext>(options=>
                options.UseMySql("Server=localhost;Database=postefcore;Uid=root;Pwd=root;"));
            //Registramos el EmailSender
            serviceCollection.AddSingleton<IEmailSender, EmailSender>();
            serviceCollection.AddSingleton<IGeneradorInformes, GeneradorInformes>();

            Injector.GenerarProveedor(serviceCollection);
            //Obtengo clase desde el IOC
            IGeneradorInformes generador = Injector.GetService<IGeneradorInformes>();    
            generador.GenerarInforme();
        }
    }   
}
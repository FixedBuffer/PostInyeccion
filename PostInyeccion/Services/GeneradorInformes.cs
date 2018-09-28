using Microsoft.EntityFrameworkCore;
using PostInyeccion.Models;
using System.Linq;

namespace PostInyeccion.Services
{
    public class GeneradorInformes : IGeneradorInformes
    {
        //Dependencias Inyectadas
        PostDbContext _contexto;
        IEmailSender _emailSender;

        //Inyectamos las dependencias en el constructor
        public GeneradorInformes(PostDbContext contexto, IEmailSender emailSender)
        {
            _contexto = contexto;
            _emailSender = emailSender;
        }

        public void GenerarInforme()
        {
            var profesores = _contexto.Profesores.Include(x => x.Cursos)
                                                .ThenInclude(x => x.Alumnos).ToList();
            //Trabajo de maquetacion
            //.......

            //Enviamos el correo
            var envioOK = _emailSender.Enviar(profesores);
            if (!envioOK)
            {
                //Registramos el fallo en un log 
            }
        }
    }
}

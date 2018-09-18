using Microsoft.EntityFrameworkCore;
using PostInyeccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInyeccion.Services
{
    internal class GeneradorInformes
    {
        //Dependencias Inyectadas
        PostDbContext _contexto;
        IEmailSender _emailSender;

        //Inyectamos las dependencias en el constructor
        internal GeneradorInformes(PostDbContext contexto, IEmailSender emailSender)
        {
            _contexto = contexto;
            _emailSender = emailSender;
        }

        internal void GenerarInforme()
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

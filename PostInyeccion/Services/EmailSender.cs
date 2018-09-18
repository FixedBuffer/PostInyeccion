using PostInyeccion.Models;
using System.Collections.Generic;

namespace PostInyeccion.Services
{
    public class EmailSender : IEmailSender
    {
        public bool Enviar(List<Profesores> profesores)
        {
            //Enviar correo
            return true;
        }
    }
}

using PostInyeccion.Models;
using System.Collections.Generic;

namespace PostInyeccion.Services
{
    interface IEmailSender
    {
        bool Enviar(List<Profesores> profesores);
    }
}

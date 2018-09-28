using PostInyeccion.Models;
using System.Collections.Generic;

namespace PostInyeccion.Services
{
    public interface IEmailSender
    {
        bool Enviar(List<Profesores> profesores);
    }
}

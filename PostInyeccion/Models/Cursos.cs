using System;
using System.Collections.Generic;

namespace PostInyeccion.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int IdProfesor { get; set; }

        public Profesores IdProfesorNavigation { get; set; }
        public ICollection<Alumnos> Alumnos { get; set; }
    }
}

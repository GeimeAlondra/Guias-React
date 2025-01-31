using reactBackend.Context;
using reactBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBackend.Repository
{
    public class AlumnoDao
    {
        public RegistroAlumnosContext contexto = new RegistroAlumnosContext();
    
        public List<Alumno> SelectAll()
        {
            // Creamos una variable var que es generica 
            // El contexto tiene referecniada todos los modelos
            // Dentro de EF tenemos el metodo modelo.ToList<Modelo>
            var alumno = contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }

        public Alumno? GetById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }
    }
}

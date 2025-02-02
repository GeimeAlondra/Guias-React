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
        // Para hacer cualquier opracio con de datos debemos llamar al contexto
        // -> la peticion llama al contexto
        // -> contexto verifica el dataset
        // -> el data set mediante su datatable se actualiza
        // -> el contexto mediante su metodo save guarda las actualizaciones , delete o insert
        // -> devuelve el tipo de correspondiente de error o peticion.
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

        public bool insertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno
                {
                    Direccion = alumno.Direccion,
                    Edad = alumno.Edad,
                    Email = alumno.Email,
                    Dni = alumno.Dni,
                    Nombre = alumno.Nombre
                };

                // Añadimos al contexto de dataset que representa la base de datos el metodo add
                contexto.Alumnos.Add(alum);
                // Este elemnto en si no nos guardara los datos para ello debemos utilizar el metodo save
                contexto.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool actualizarAlumno(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GetById(id);

                if (alumnoUpdate == null)
                {
                    Console.WriteLine("Alumno es null");
                    return false;
                }

                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dni = actualizar.Dni;
                alumnoUpdate.Nombre = actualizar.Nombre;
                alumnoUpdate.Email = actualizar.Email;

                contexto.Alumnos.Update(alumnoUpdate);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public bool borrarAlumno(int id)
        {
            var borrar = GetById(id);
            try
            {
                if (borrar == null)
                {
                    return false;

                }
                else
                {
                    contexto.Alumnos.Remove(borrar);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }
    }
}

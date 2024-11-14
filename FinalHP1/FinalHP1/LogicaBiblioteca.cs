using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHP1 // Asegúrate que el namespace sea "FinalHP1" para que coincida con el proyecto
{
    // Todo el código que te compartió tu amigo va aquí

        public class Material
        {
            // Propiedades de la clase Material
            public string Id { get; set; }       // Identificador único del material
            public string Titulo { get; set; }   // Título del material
            public DateTime FechaRegistro { get; set; } // Fecha en la que el material fue registrado
            public int CantidadRegistrada { get; set; }  // Cantidad total de unidades registradas
            public int CantidadActual { get; set; } // Cantidad actual disponible para préstamo

            // Constructor
            public Material(string id, string titulo, DateTime fechaRegistro, int cantidadRegistrada)
            {
                Id = id;
                Titulo = titulo;
                FechaRegistro = fechaRegistro;
                CantidadRegistrada = cantidadRegistrada;
                CantidadActual = cantidadRegistrada; // Inicialmente la cantidad actual es igual a la registrada
            }

            // Método para incrementar la cantidad registrada de un material
            public void IncrementarCantidad(int cantidad)
            {
                CantidadRegistrada += cantidad;
                CantidadActual += cantidad;
            }

            // Método para hacer un préstamo
            public bool Prestar()
            {
                if (CantidadActual > 0)
                {
                    CantidadActual--;
                    return true;
                }
                return false;
            }

            // Método para devolver un material
            public void Devolver()
            {
                if (CantidadActual < CantidadRegistrada)
                {
                    CantidadActual++;
                }
            }
        }

        public class Persona
        {
            // Propiedades de la clase Persona
            public string Nombre { get; set; }
            public string Cedula { get; set; } // Cédula única para cada persona
            public string Rol { get; set; } // Estudiante, Profesor, Administrativo
            public int PrestamosActivos { get; set; } // Cantidad de préstamos activos

            // Constructor
            public Persona(string nombre, string cedula, string rol)
            {
                Nombre = nombre;
                Cedula = cedula;
                Rol = rol;
                PrestamosActivos = 0; // Inicialmente no tiene préstamos activos
            }

            // Método para verificar si la persona puede hacer un préstamo
            public bool PuedePrestar()
            {
                int limite = 0;

                // Según el rol de la persona, se asigna el límite de préstamos
                switch (Rol.ToLower())
                {
                    case "estudiante":
                        limite = 5;
                        break;
                    case "profesor":
                        limite = 3;
                        break;
                    case "administrativo":
                        limite = 1;
                        break;
                    default:
                        throw new InvalidOperationException("Rol desconocido");
                }

                // Verificamos si tiene capacidad para realizar más préstamos
                return PrestamosActivos < limite;
            }

            // Método para realizar un préstamo
            public void RealizarPrestamo()
            {
                PrestamosActivos++;
            }

            // Método para realizar una devolución
            public void RealizarDevolucion()
            {
                if (PrestamosActivos > 0)
                {
                    PrestamosActivos--;
                }
            }
        }

        public class Movimiento
        {
            // Propiedades del movimiento
            public string IdMaterial { get; set; }
            public string CedulaPersona { get; set; }
            public DateTime FechaMovimiento { get; set; }
            public string TipoMovimiento { get; set; } // Puede ser "Préstamo" o "Devolución"

            // Constructor
            public Movimiento(string idMaterial, string cedulaPersona, DateTime fechaMovimiento, string tipoMovimiento)
            {
                IdMaterial = idMaterial;
                CedulaPersona = cedulaPersona;
                FechaMovimiento = fechaMovimiento;
                TipoMovimiento = tipoMovimiento;
            }
        }


        public class CatalogoMateriales
        {
            // Diccionario que contiene los materiales, usando el ID como clave
            private Dictionary<string, Material> materiales = new Dictionary<string, Material>();

            // Método para registrar un nuevo material en el catálogo
            public void RegistrarMaterial(Material material)
            {
                if (materiales.ContainsKey(material.Id))
                {
                    throw new InvalidOperationException("Ya existe un material con este ID.");
                }
                materiales[material.Id] = material;
            }

            // Método para obtener un material por su ID
            public Material ObtenerMaterial(string id)
            {
                if (materiales.ContainsKey(id))
                {
                    return materiales[id];
                }
                return null;
            }

            // Método para incrementar la cantidad registrada de un material
            public void IncrementarCantidadMaterial(string id, int cantidad)
            {
                Material material = ObtenerMaterial(id);
                if (material != null)
                {
                    material.IncrementarCantidad(cantidad);
                }
            }
        }

        public class RegistroPersonas
        {
            // Diccionario que contiene las personas, usando la cédula como clave
            private Dictionary<string, Persona> personas = new Dictionary<string, Persona>();

            // Método para registrar una persona
            public void RegistrarPersona(Persona persona)
            {
                if (personas.ContainsKey(persona.Cedula))
                {
                    throw new InvalidOperationException("Ya existe una persona con esta cédula.");
                }
                personas[persona.Cedula] = persona;
            }

            // Método para obtener una persona por su cédula
            public Persona ObtenerPersona(string cedula)
            {
                if (personas.ContainsKey(cedula))
                {
                    return personas[cedula];
                }
                return null;
            }

            // Método para eliminar una persona, solo si no tiene préstamos activos
            public void EliminarPersona(string cedula)
            {
                Persona persona = ObtenerPersona(cedula);
                if (persona != null && persona.PrestamosActivos == 0)
                {
                    personas.Remove(cedula);
                }
                else
                {
                    throw new InvalidOperationException("No se puede eliminar la persona, tiene préstamos activos.");
                }
            }
        }

        public class HistorialMovimientos
        {
            // Lista para almacenar los movimientos de préstamo y devolución
            private List<Movimiento> movimientos = new List<Movimiento>();

            // Método para registrar un movimiento en el historial
            public void RegistrarMovimiento(Movimiento movimiento)
            {
                movimientos.Add(movimiento);
            }

            // Método para consultar el historial completo
            public List<Movimiento> ConsultarHistorial()
            {
                return movimientos;
            }
        }

        public class Biblioteca
        {
            private CatalogoMateriales catalogo;
            private RegistroPersonas registroPersonas;
            private HistorialMovimientos historial;

            // Constructor
            public Biblioteca()
            {
                catalogo = new CatalogoMateriales();
                registroPersonas = new RegistroPersonas();
                historial = new HistorialMovimientos();
            }

            // Método para registrar un material
            public void RegistrarMaterial(string id, string titulo, DateTime fechaRegistro, int cantidadRegistrada)
            {
                Material material = new Material(id, titulo, fechaRegistro, cantidadRegistrada);
                catalogo.RegistrarMaterial(material);
            }

            // Método para registrar una persona
            public void RegistrarPersona(string nombre, string cedula, string rol)
            {
                Persona persona = new Persona(nombre, cedula, rol);
                registroPersonas.RegistrarPersona(persona);
            }

            // Método para eliminar una persona
            public void EliminarPersona(string cedula)
            {
                registroPersonas.EliminarPersona(cedula);
            }

            // Método para registrar un préstamo
            public void RegistrarPrestamo(string idMaterial, string cedulaPersona)
            {
                Material material = catalogo.ObtenerMaterial(idMaterial);
                Persona persona = registroPersonas.ObtenerPersona(cedulaPersona);

                if (material != null && persona != null && persona.PuedePrestar())
                {
                    if (material.Prestar())
                    {
                        persona.RealizarPrestamo();
                        Movimiento movimiento = new Movimiento(idMaterial, cedulaPersona, DateTime.Now, "Préstamo");
                        historial.RegistrarMovimiento(movimiento);
                        Console.WriteLine("Préstamo realizado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("No hay unidades disponibles para este material.");
                    }
                }
                else
                {
                    Console.WriteLine("La persona no puede realizar más préstamos o el material no existe.");
                }
            }

            // Método para registrar una devolución
            public void RegistrarDevolucion(string idMaterial, string cedulaPersona)
            {
                Material material = catalogo.ObtenerMaterial(idMaterial);
                Persona persona = registroPersonas.ObtenerPersona(cedulaPersona);

                if (material != null && persona != null && persona.PrestamosActivos > 0)
                {
                    material.Devolver();
                    persona.RealizarDevolucion();
                    Movimiento movimiento = new Movimiento(idMaterial, cedulaPersona, DateTime.Now, "Devolución");
                    historial.RegistrarMovimiento(movimiento);
                    Console.WriteLine("Devolución registrada con éxito.");
                }
                else
                {
                    Console.WriteLine("No se puede realizar la devolución.");
                }
            }

            // Método para consultar el historial
            public void ConsultarHistorial()
            {
                var movimientos = historial.ConsultarHistorial();
                foreach (var movimiento in movimientos)
                {
                    Console.WriteLine($"{movimiento.TipoMovimiento} | Material ID: {movimiento.IdMaterial} | Persona: {movimiento.CedulaPersona} | Fecha: {movimiento.FechaMovimiento}");
                }
            }
        }

    

}

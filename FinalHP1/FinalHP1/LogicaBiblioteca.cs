using System;
using System.Collections.Generic;
using System.IO;

namespace FinalHP1
{
    public class Material
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CantidadRegistrada { get; set; }
        public int CantidadActual { get; set; }

        public Material(string id, string titulo, DateTime fechaRegistro, int cantidadRegistrada)
        {
            Id = id;
            Titulo = titulo;
            FechaRegistro = fechaRegistro;
            CantidadRegistrada = cantidadRegistrada;
            CantidadActual = cantidadRegistrada;
        }

        public void IncrementarCantidad(int cantidad)
        {
            CantidadRegistrada += cantidad;
            CantidadActual += cantidad;
        }

        public bool Prestar()
        {
            if (CantidadActual > 0)
            {
                CantidadActual--;
                return true;
            }
            return false;
        }

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
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Rol { get; set; }
        public int PrestamosActivos { get; set; }

        public Persona(string nombre, string cedula, string rol)
        {
            Nombre = nombre;
            Cedula = cedula;
            Rol = rol;
            PrestamosActivos = 0;
        }

        public bool PuedePrestar()
        {
            int limite = 0;
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
            return PrestamosActivos < limite;
        }

        public void RealizarPrestamo()
        {
            PrestamosActivos++;
        }

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
        public string IdMaterial { get; set; }
        public string CedulaPersona { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; }

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
        private Dictionary<string, Material> materiales = new Dictionary<string, Material>();

        public void RegistrarMaterial(Material material)
        {
            if (materiales.ContainsKey(material.Id))
            {
                throw new InvalidOperationException("Ya existe un material con este ID.");
            }
            materiales[material.Id] = material;
        }

        public Material ObtenerMaterial(string id)
        {
            if (materiales.ContainsKey(id))
            {
                return materiales[id];
            }
            return null;
        }

        public void IncrementarCantidadMaterial(string id, int cantidad)
        {
            Material material = catalogo.ObtenerMaterial(id);
            if (material != null)
            {
                material.IncrementarCantidad(cantidad);
            }
            else
            {
                throw new InvalidOperationException("El material no existe.");
            }
        }

        public List<Material> ObtenerTodosLosMateriales()
        {
            return new List<Material>(materiales.Values);
        }
    }

    public class RegistroPersonas
    {
        private Dictionary<string, Persona> personas = new Dictionary<string, Persona>();

        public void RegistrarPersona(Persona persona)
        {
            if (personas.ContainsKey(persona.Cedula))
            {
                throw new InvalidOperationException("Ya existe una persona con esta cédula.");
            }
            personas[persona.Cedula] = persona;
        }

        public Persona ObtenerPersona(string cedula)
        {
            if (personas.ContainsKey(cedula))
            {
                return personas[cedula];
            }
            return null;
        }

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

        public List<Persona> ObtenerTodasLasPersonas()
        {
            return new List<Persona>(personas.Values);
        }
    }

    public class HistorialMovimientos
    {
        private List<Movimiento> movimientos = new List<Movimiento>();

        public void RegistrarMovimiento(Movimiento movimiento)
        {
            movimientos.Add(movimiento);
        }

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

        public Biblioteca()
        {
            catalogo = new CatalogoMateriales();
            registroPersonas = new RegistroPersonas();
            historial = new HistorialMovimientos();
            LeerDatos();
        }

        public void RegistrarMaterial(string id, string titulo, DateTime fechaRegistro, int cantidadRegistrada)
        {
            Material material = new Material(id, titulo, fechaRegistro, cantidadRegistrada);
            catalogo.RegistrarMaterial(material);
        }

        public void RegistrarPersona(string nombre, string cedula, string rol)
        {
            Persona persona = new Persona(nombre, cedula, rol);
            registroPersonas.RegistrarPersona(persona);
        }

        public void EliminarPersona(string cedula)
        {
            registroPersonas.EliminarPersona(cedula);
        }

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

        public void ConsultarHistorial()
        {
            var movimientos = historial.ConsultarHistorial();
            foreach (var movimiento in movimientos)
            {
                Console.WriteLine($"{movimiento.TipoMovimiento} | Material ID: {movimiento.IdMaterial} | Persona: {movimiento.CedulaPersona} | Fecha: {movimiento.FechaMovimiento}");
            }
        }

        public void GuardarDatos()
        {
            using (StreamWriter writer = new StreamWriter("materiales.txt"))
            {
                foreach (var material in catalogo.ObtenerTodosLosMateriales())
                {
                    writer.WriteLine($"{material.Id},{material.Titulo},{material.FechaRegistro},{material.CantidadRegistrada},{material.CantidadActual}");
                }
            }

            using (StreamWriter writer = new StreamWriter("personas.txt"))
            {
                foreach (var persona in registroPersonas.ObtenerTodasLasPersonas())
                {
                    writer.WriteLine($"{persona.Nombre},{persona.Cedula},{persona.Rol},{persona.PrestamosActivos}");
                }
            }

            using (StreamWriter writer = new StreamWriter("movimientos.txt"))
            {
                foreach (var movimiento in historial.ConsultarHistorial())
                {
                    writer.WriteLine($"{movimiento.IdMaterial},{movimiento.CedulaPersona},{movimiento.FechaMovimiento},{movimiento.TipoMovimiento}");
                }
            }
        }

        public void LeerDatos()
        {
            if (File.Exists("materiales.txt"))
            {
                using (StreamReader reader = new StreamReader("materiales.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        var material = new Material(data[0], data[1], DateTime.Parse(data[2]), int.Parse(data[3]));
                        material.CantidadActual = int.Parse(data[4]);
                        catalogo.RegistrarMaterial(material);
                    }
                }
            }

            if (File.Exists("personas.txt"))
            {
                using (StreamReader reader = new StreamReader("personas.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        var persona = new Persona(data[0], data[1], data[2]);
                        persona.PrestamosActivos = int.Parse(data[3]);
                        registroPersonas.RegistrarPersona(persona);
                    }
                }
            }

            if (File.Exists("movimientos.txt"))
            {
                using (StreamReader reader = new StreamReader("movimientos.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        var movimiento = new Movimiento(data[0], data[1], DateTime.Parse(data[2]), data[3]);
                        historial.RegistrarMovimiento(movimiento);
                    }
                }
            }
        }
    }
}
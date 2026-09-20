using System;

namespace SistemaVeterinario.logica
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dpi { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public override string ToString() => Nombre;
    }
}
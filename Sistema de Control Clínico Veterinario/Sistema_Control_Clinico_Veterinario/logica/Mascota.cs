using System;
using System.Collections.Generic;

namespace SistemaVeterinario.logica
{
    public class Mascota
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Peso { get; set; }
        public Cliente Propietario { get; set; }
        public List<Consulta> Historial { get; set; } = new List<Consulta>();

        public void AgregarConsulta(Consulta c) => Historial.Add(c);

        public void MostrarHistorial()
        {
            Console.WriteLine($"\n   --- HISTORIAL DE {Nombre} ---");
            if (Historial.Count == 0)
            {
                Console.WriteLine("   Sin consultas registradas.");
                return;
            }
            foreach (var c in Historial)
            {
                Console.WriteLine($"   Consulta #{c.IdConsulta} | {c.Motivo}");
                Console.WriteLine($"     Diagnostico: {c.Diagnostico}");
                Console.WriteLine($"     Gravedad: {c.Gravedad}");
                Console.WriteLine($"     Tratamiento: {c.Tratamiento?.Descripcion}");
                Console.WriteLine($"     Medicamentos: {c.Tratamiento?.Medicamentos}");
                Console.WriteLine();
            }
        }

        public override string ToString() => Nombre;
    }
}
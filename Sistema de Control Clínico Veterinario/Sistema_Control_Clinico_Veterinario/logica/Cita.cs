using System;

namespace SistemaVeterinario.logica
{
    public class Cita
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; } = "Programada";
        public Cliente Cliente { get; set; }
        public Mascota Mascota { get; set; }
        public Veterinario Veterinario { get; set; }
        public Consulta Consulta { get; set; }

        public void Cancelar() => Estado = "Cancelada";
        public void Completar() => Estado = "Completada";

        public override string ToString() =>
            $"Cita #{IdCita} | {Fecha:dd/MM/yyyy} {Hora} | Estado: {Estado} | Motivo: {Motivo}";
    }
}
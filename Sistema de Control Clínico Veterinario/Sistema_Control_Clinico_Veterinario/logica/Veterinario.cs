namespace SistemaVeterinario.logica
{
    public class Veterinario : Persona
    {
        public string CodigoVet { get; set; }
        public string Especialidad { get; set; }
        public string Horario { get; set; }
        public string Consultorio { get; set; }

        public override string ToString() => $"Dr(a). {Nombre}";
    }
}
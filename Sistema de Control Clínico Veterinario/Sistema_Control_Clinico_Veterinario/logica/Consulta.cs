namespace SistemaVeterinario.logica
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public string Motivo { get; set; }
        public string Diagnostico { get; set; }
        public string Gravedad { get; set; }
        public Tratamiento Tratamiento { get; set; }
        public string Receta { get; set; }

        public void RegistrarTratamiento(Tratamiento t) => Tratamiento = t;
        public void GenerarReceta(string indicaciones) => Receta = indicaciones;
    }
}
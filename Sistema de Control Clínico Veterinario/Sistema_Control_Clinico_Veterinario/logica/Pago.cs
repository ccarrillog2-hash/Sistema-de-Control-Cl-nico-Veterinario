namespace SistemaVeterinario.logica
{
    public class Pago
    {
        public int IdPago { get; set; }
        public double Monto { get; set; }
        public string MetodoPago { get; set; }
        public double Cambio { get; set; }
        public string NumAutorizacion { get; set; }
        public string Banco { get; set; }
        public string Estado { get; private set; } = "Pendiente";

        public void ProcesarPago() => Estado = "Aprobado";
    }
}
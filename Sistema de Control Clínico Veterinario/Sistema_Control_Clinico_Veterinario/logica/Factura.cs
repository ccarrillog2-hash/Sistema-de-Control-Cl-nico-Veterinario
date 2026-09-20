using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVeterinario.logica
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Cliente Cliente { get; set; }
        public double Subtotal { get; set; }
        public double Impuestos { get; private set; }
        public double Total { get; private set; }
        public double Descuento { get; private set; }
        public string Estado { get; private set; } = "Pendiente";
        public List<Pago> Pagos { get; set; } = new List<Pago>();

        public Factura(Cliente cliente, double subtotal)
        {
            Cliente = cliente;
            Subtotal = subtotal;
            Recalcular();
        }

        private void Recalcular()
        {
            Impuestos = Subtotal * 0.16;
            Total = Subtotal + Impuestos - Descuento;
        }

        public void AplicarDescuento(double porcentaje)
        {
            Descuento = Subtotal * (porcentaje / 100.0);
            Recalcular();
        }

        public void AgregarPago(Pago p)
        {
            Pagos.Add(p);
            if (Pagos.Sum(x => x.Monto) >= Total)
                Estado = "Pagada";
        }

        public void Emitir()
        {
            Console.WriteLine("\n   ============ FACTURA ============");
            Console.WriteLine($"   No. Factura: {IdFactura}");
            Console.WriteLine($"   Cliente: {Cliente.Nombre}  NIT: {Cliente.Nit}");
            Console.WriteLine($"   Fecha: {Fecha:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"   Subtotal:  Q{Subtotal:F2}");
            Console.WriteLine($"   Impuestos: Q{Impuestos:F2}");
            Console.WriteLine($"   Descuento: Q{Descuento:F2}");
            Console.WriteLine($"   TOTAL:     Q{Total:F2}");
            Console.WriteLine("   =================================");
        }
    }
}
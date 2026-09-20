import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Factura {
    private int idFactura;
    private Date fecha;
    private double subtotal;
    private double impuestos;
    private double total;
    private String estado;
    private Cliente cliente;
    private List<Pago> pagos;
    
    public Factura(Cliente c, double subtotal) {
        this.cliente = c;
        this.subtotal = subtotal;
        this.impuestos = subtotal * 0.16;
        this.total = subtotal + impuestos;
        this.fecha = new Date();
        this.estado = "Pendiente";
        this.pagos = new ArrayList<>();
    }
    
    public double calcularTotal() { return total; }
    
    public void aplicarDescuento(double porcentaje) {
        this.total = total - (total * porcentaje / 100);
    }
    
    public void agregarPago(Pago p) {
        pagos.add(p);
        if (totalPagado() >= total) this.estado = "Pagada";
    }
    
    private double totalPagado() {
        double suma = 0;
        for (Pago p : pagos) suma += p.getMonto();
        return suma;
    }
    
    public String getEstado() { return estado; }
    public double getTotal() { return total; }
}
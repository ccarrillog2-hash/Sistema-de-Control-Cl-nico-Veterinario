import java.util.Date;

public class Pago {
    private int idPago;
    private double monto;
    private String metodoPago;
    private Date fecha;
    private String estado;
    
    public Pago(int id, double monto, String metodo) {
        this.idPago = id;
        this.monto = monto;
        this.metodoPago = metodo;
        this.fecha = new Date();
        this.estado = "Pendiente";
    }
    
    public boolean procesarPago() {
        this.estado = "Aprobado";
        return true;
    }
    
    public double getMonto() { return monto; }
    public String getMetodoPago() { return metodoPago; }
    public void setEstado(String estado) { this.estado = estado; }
    public String getEstado() { return estado; }
}
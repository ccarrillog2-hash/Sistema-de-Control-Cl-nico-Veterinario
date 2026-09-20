import java.util.Date;

public class Cita {
    private int idCita;
    private Date fecha;
    private String hora;
    private String motivo;
    private String estado;
    private Cliente cliente;
    private Mascota mascota;
    private Veterinario veterinario;
    
    public Cita(int id, Date fecha, String hora, String motivo,
                Cliente c, Mascota m, Veterinario v) {
        this.idCita = id;
        this.fecha = fecha;
        this.hora = hora;
        this.motivo = motivo;
        this.estado = "Programada";
        this.cliente = c;
        this.mascota = m;
        this.veterinario = v;
    }
    
    public void confirmar() { this.estado = "Confirmada"; }
    public void cancelar() { this.estado = "Cancelada"; }
    public void setEstado(String estado) { this.estado = estado; }
    public String getEstado() { return estado; }
    public Date getFecha() { return fecha; }
}
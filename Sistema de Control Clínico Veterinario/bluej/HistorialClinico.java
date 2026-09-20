import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class HistorialClinico {
    private int idHistorial;
    private Date fechaCreacion;
    private Date fechaUltimaActualizacion;
    private List<Consulta> consultas;
    private Mascota mascota;
    
    public HistorialClinico() {
        this.idHistorial = 0;
        this.fechaCreacion = new Date();
        this.fechaUltimaActualizacion = new Date();
        this.consultas = new ArrayList<Consulta>();
        this.mascota = null;
    }
    
    public HistorialClinico(int id, Mascota mascota) {
        this.idHistorial = id;
        this.fechaCreacion = new Date();
        this.fechaUltimaActualizacion = new Date();
        this.consultas = new ArrayList<Consulta>();
        this.mascota = mascota;
    }
    
    public void agregarConsulta(Consulta c) {
        if (c != null) {
            consultas.add(c);
            this.fechaUltimaActualizacion = new Date();
            System.out.println("Consulta #" + c.getIdConsulta() + " agregada al historial");
        }
    }
    
    public void consultarHistorial() {
        if (consultas.isEmpty()) {
            System.out.println("Sin historial previo para esta mascota.");
        } else {
            System.out.println("=== HISTORIAL CLINICO #" + idHistorial + " ===");
            System.out.println("Mascota: " + (mascota != null ? mascota.getNombre() : "Sin asignar"));
            for (Consulta c : consultas) {
                System.out.println("  " + c.toString());
            }
        }
    }
    
    public void actualizarHistorial() {
        this.fechaUltimaActualizacion = new Date();
        System.out.println("Historial #" + idHistorial + " actualizado.");
    }
    
    public Consulta buscarConsulta(int idConsulta) {
        for (Consulta c : consultas) {
            if (c.getIdConsulta() == idConsulta) return c;
        }
        return null;
    }
    
    public int getTotalConsultas() { return consultas.size(); }
    public List<Consulta> getConsultas() { return consultas; }
    public int getIdHistorial() { return idHistorial; }
    public Mascota getMascota() { return mascota; }
    public void setMascota(Mascota m) { this.mascota = m; }
    public Date getFechaCreacion() { return fechaCreacion; }
    public Date getFechaUltimaActualizacion() { return fechaUltimaActualizacion; }
    
    @Override
    public String toString() {
        return "Historial #" + idHistorial + " (" + consultas.size() + " consultas)";
    }
}
public class Diagnostico {
    private int idDiagnostico;
    private String descripcion;
    private String gravedad;
    
    public Diagnostico(int id, String descripcion, String gravedad) {
        this.idDiagnostico = id;
        this.descripcion = descripcion;
        this.gravedad = gravedad;
    }
    
    public String getDescripcion() { return descripcion; }
    public String getGravedad() { return gravedad; }
}
import java.util.Date;

public class Consulta {
    private int idConsulta;
    private Date fecha;
    private String motivo;
    private String observaciones;
    private Diagnostico diagnostico;
    private Tratamiento tratamiento;
    
    public Consulta(int id, String motivo) {
        this.idConsulta = id;
        this.fecha = new Date();
        this.motivo = motivo;
    }
    
    public void registrarDiagnostico(Diagnostico d) { this.diagnostico = d; }
    public void registrarTratamiento(Tratamiento t) { this.tratamiento = t; }
    public int getIdConsulta() { return idConsulta; }
    public Diagnostico getDiagnostico() { return diagnostico; }
    public Tratamiento getTratamiento() { return tratamiento; }
}
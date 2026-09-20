import java.util.ArrayList;
import java.util.List;

public class Tratamiento {
    private int idTratamiento;
    private String descripcion;
    private int duracionDias;
    private List<Medicamento> medicamentos;
    
    public Tratamiento(int id, String descripcion, int duracion) {
        this.idTratamiento = id;
        this.descripcion = descripcion;
        this.duracionDias = duracion;
        this.medicamentos = new ArrayList<>();
    }
    
    public void agregarMedicamento(Medicamento m) {
        medicamentos.add(m);
    }
    
    public List<Medicamento> getMedicamentos() { return medicamentos; }
}
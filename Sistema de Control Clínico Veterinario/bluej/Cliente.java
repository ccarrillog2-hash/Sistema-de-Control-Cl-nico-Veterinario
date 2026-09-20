import java.util.ArrayList;
import java.util.List;

public class Cliente extends Persona {
    private String nit;
    private List<Mascota> mascotas;
    
    public Cliente(String nombre, String dpi, String telefono, String email, String nit) {
        super(nombre, dpi, telefono, email);
        this.nit = nit;
        this.mascotas = new ArrayList<>();
    }
    
    public void agregarMascota(Mascota m) {
        mascotas.add(m);
    }
    
    public List<Mascota> getMascotas() { return mascotas; }
    public String getNit() { return nit; }
}
import java.util.Date;

public class Mascota {
    private String nombre;
    private String especie;
    private String raza;
    private String sexo;
    private Date fechaNacimiento;
    private double peso;
    private HistorialClinico historial;
    
    public Mascota(String nombre, String especie, String raza, double peso) {
        this.nombre = nombre;
        this.especie = especie;
        this.raza = raza;
        this.peso = peso;
        this.historial = new HistorialClinico();
    }
    
    public String getNombre() { return nombre; }
    public String getEspecie() { return especie; }
    public String getRaza() { return raza; }
    public double getPeso() { return peso; }
    public HistorialClinico getHistorial() { return historial; }
}
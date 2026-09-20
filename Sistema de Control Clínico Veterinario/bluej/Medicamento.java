public class Medicamento {
    private int idMedicamento;
    private String nombre;
    private String dosis;
    private double precio;
    
    public Medicamento(int id, String nombre, String dosis, double precio) {
        this.idMedicamento = id;
        this.nombre = nombre;
        this.dosis = dosis;
        this.precio = precio;
    }
    
    public String getNombre() { return nombre; }
    public double getPrecio() { return precio; }
}
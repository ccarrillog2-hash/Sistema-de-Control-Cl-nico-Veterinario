public class Persona {
    private String nombre;
    private String dpi;
    private String telefono;
    private String email;
    private String direccion;
    
    public Persona(String nombre, String dpi, String telefono, String email) {
        this.nombre = nombre;
        this.dpi = dpi;
        this.telefono = telefono;
        this.email = email;
    }
    
    public String getNombre() { return nombre; }
    public void setNombre(String nombre) { this.nombre = nombre; }
    public String getDpi() { return dpi; }
    public String getTelefono() { return telefono; }
    public String getEmail() { return email; }
}
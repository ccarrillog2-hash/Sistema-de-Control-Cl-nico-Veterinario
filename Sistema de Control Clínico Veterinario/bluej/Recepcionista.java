public class Recepcionista extends Persona {
    private String codigoEmpleado;
    
    public Recepcionista(String nombre, String dpi, String telefono, String email, String codigo) {
        super(nombre, dpi, telefono, email);
        this.codigoEmpleado = codigo;
    }
    
    public void registrarCliente(Cliente c) {
        System.out.println("Cliente registrado: " + c.getNombre());
    }
    
    public void registrarMascota(Mascota m) {
        System.out.println("Mascota registrada: " + m.getNombre());
    }
    
    public void crearCita(Cita c) {
        System.out.println("Cita creada para: " + c.getFecha());
    }
    
    public Factura generarFactura(Cliente c, double total) {
        return new Factura(c, total);
    }
}
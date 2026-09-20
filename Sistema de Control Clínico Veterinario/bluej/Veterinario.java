public class Veterinario extends Persona {
    private String codigoVet;
    private String especialidad;
    private String horario;
    
    public Veterinario(String nombre, String dpi, String telefono, String email,
                       String codigo, String especialidad) {
        super(nombre, dpi, telefono, email);
        this.codigoVet = codigo;
        this.especialidad = especialidad;
    }
    
    public void atenderCita(Cita c) {
        c.setEstado("En atención");
    }
    
    public void registrarConsulta(Consulta c) {
        System.out.println("Consulta registrada para cita: " + c.getIdConsulta());
    }
    
    public String getEspecialidad() { return especialidad; }
}
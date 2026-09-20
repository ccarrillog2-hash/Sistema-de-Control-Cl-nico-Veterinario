import java.util.Date;

public class Receta {
    private int idReceta;
    private Date fecha;
    private String indicaciones;
    private Consulta consulta;
    
    public Receta(int id, Consulta c, String indicaciones) {
        this.idReceta = id;
        this.fecha = new Date();
        this.consulta = c;
        this.indicaciones = indicaciones;
    }
    
    public void generarPDF() {
        System.out.println("Generando PDF de receta #" + idReceta);
    }
}
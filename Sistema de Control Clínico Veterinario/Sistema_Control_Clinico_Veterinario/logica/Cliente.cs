public class Cliente : Persona
{
    public int Id { get; set; }
    public string Nit { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public string Usuario { get; set; }
    public string Contrasena { get; set; }

    public List<Mascota> Mascotas { get; set; } = new List<Mascota>();

    public void AgregarMascota(Mascota m)
    {
        Mascotas.Add(m);
        m.Propietario = this;
    }
}
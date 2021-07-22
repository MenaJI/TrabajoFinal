namespace ApiREST.Entities
{
    public class Persona
    {
        public int Id { get; set; }

        // public Usuario usuario {get; set;}

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public TiposDocs TipoDoc { get; set; }

        public double NroDocumento { get; set; }

        public Generos Genero { get; set; }

        public Localidades Localidad { get; set; }

        public Nacionalidades Nacionalidad { get; set; }

        public EstadosCiviles EstadoCivil { get; set; }


    }
}
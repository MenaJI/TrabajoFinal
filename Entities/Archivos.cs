namespace ApiREST.Entities
{
    public class Archivos : BaseEntity
    {
        public string Nombre { get; set; }
        public string TipoArchivo { get; set; }
        public string FileBase64 { get; set; }
        public string AlumnoUserName { get; set; }
    }
}
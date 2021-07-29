namespace ApiREST.Entities
{
    public class Modulos
    {
        public int Id { get; set; }

        public Dias Dia { get; set; }

        public Horarios Horario { get; set; }

        public bool Estado { get; set; }
    }
}
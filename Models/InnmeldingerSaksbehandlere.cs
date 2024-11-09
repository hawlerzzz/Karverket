namespace Karverket.Models
{
    public class InnmeldingerSaksbehandlere
    {
        public List<User> Saksbehandlere { get; set; }
        public Innmelding innmelding {  get; set; }
    }
}

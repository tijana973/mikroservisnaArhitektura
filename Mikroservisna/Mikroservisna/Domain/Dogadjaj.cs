namespace Mikroservisna.Domain
{
    public class Dogadjaj

    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Agenda { get; set; }
        public DateTime DatumOdrazavanja {  get; set; }
        public int Trajanje { get; set; }
        public double Cena { get; set; }
        public List<Predavac> Predavaci { get; set; }

        public int IdLokacija { get; set; }
        public Lokacija Lokacija { get; set; }
    }
}

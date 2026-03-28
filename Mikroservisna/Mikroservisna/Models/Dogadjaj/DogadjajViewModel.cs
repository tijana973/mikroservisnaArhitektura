using Mikroservisna.Domain;

namespace Mikroservisna.Models.Dogadjaj
{
    public class DogadjajViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Agenda { get; set; }
        public DateTime DatumOdrazavanja { get; set; }
        public int Trajanje { get; set; }
        public double Cena { get; set; }
        public List<Domain.Predavac> Predavaci { get; set; }

        public int IdLokacija { get; set; }
        public Domain.Lokacija Lokacija { get; set; }
    }
}

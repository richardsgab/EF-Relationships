namespace OneToManyDemo.Models.ViewModels
{
    public class BoekenVM1
    {
        public List<Boek> Boeken { get; set; }
        public List<Auteur> Auteurs { get; set; }
        public int GeselecteerdeAuteurId { get; set; }
    }
}

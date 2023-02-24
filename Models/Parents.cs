namespace Preparation.Models
{
    public class Parents
    {
        public int? Id { get; set; }
        public string? Pere { get; set; }
        public string? Mere { get; set; }
        public string? Adresse { get; set; }
        public List<Personnes>? Personnes { get; set; }
    }
}

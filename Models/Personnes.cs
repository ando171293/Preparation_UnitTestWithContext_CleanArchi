using System.ComponentModel.DataAnnotations.Schema;

namespace Preparation.Models
{
    public class Personnes
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public int? Age { get; set; }
        public string? Adresse { get; set; }
        public string? Fonction { get; set; }

        [ForeignKey(nameof(Id_Parent))]
        public int? Id_Parent { get; set; }
        public virtual Parents? Parents { get; set; }    

    }
}

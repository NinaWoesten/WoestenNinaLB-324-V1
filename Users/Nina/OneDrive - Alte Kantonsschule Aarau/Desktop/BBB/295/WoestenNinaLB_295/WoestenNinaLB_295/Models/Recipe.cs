using System.ComponentModel.DataAnnotations;

namespace WoestenNinaLB_295.Models
{
    public class Recipe
    {
        [Key]
        public int Recipe_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Persons { get; set; }
        public int Reviews { get; set; }
        public string Steps { get; set; }
        public List<Ingredients> Ingredients { get; set; } 
        public Recipe()
        {
            Ingredients = new List<Ingredients>();
        }
     
    }
}

using System.ComponentModel.DataAnnotations;

namespace WoestenNinaLB_295.Models
{
    public class Ingredients
    {
        [Key]
        public int Ingredients_Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public Ingredients()
        {

        }
        
    }
}

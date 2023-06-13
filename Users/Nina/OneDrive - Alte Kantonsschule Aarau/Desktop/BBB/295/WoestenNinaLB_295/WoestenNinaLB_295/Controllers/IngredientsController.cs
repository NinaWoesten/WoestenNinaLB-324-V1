using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WoestenNinaLB_295.Models;

namespace WoestenNinaLB_295.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientsController(RecipeContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public IActionResult CreateEdit(Ingredients ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (ingredient.Ingredients_Id == 0)
            {
                _context.Ingredients.Add(ingredient);
            }
            else
            {
                var ingredientInDb = _context.Ingredients.Find(ingredient.Ingredients_Id);
                if (ingredientInDb == null)
                    return NotFound();

                _context.Entry(ingredientInDb).CurrentValues.SetValues(ingredient);
            }
            _context.SaveChanges();

            return Ok(ingredient);
        }

        //Get
        [HttpGet]
        public IActionResult Get(int ingredient_Id)
        {
            var result = _context.Ingredients.Find(ingredient_Id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //Delete
        [HttpDelete]
        public IActionResult Delete(int ingredient_Id)
        {
            var result = _context.Ingredients.Find(ingredient_Id);
            if (result == null)
                return NotFound();

            _context.Ingredients.Remove(result);
            _context.SaveChanges();
            return NoContent();
        }
    }
}


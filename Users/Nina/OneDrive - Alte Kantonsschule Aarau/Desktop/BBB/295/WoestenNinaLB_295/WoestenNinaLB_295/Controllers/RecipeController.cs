using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WoestenNinaLB_295.Models;

namespace WoestenNinaLB_295.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly RecipeContext _context;

    public RecipeController(RecipeContext context)
    {
        _context = context;
    }

    //Create/Edit
    [HttpPost]
    public IActionResult CreateEdit(Recipe recipe)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (recipe.Recipe_Id == 0)
        {
            _context.Recipes.Add(recipe);
        }
        else
        {
            var recipeInDb = _context.Recipes.Find(recipe.Recipe_Id);
            if (recipeInDb == null)
                return NotFound();

            _context.Entry(recipeInDb).CurrentValues.SetValues(recipe);
        }
        _context.SaveChanges();

        return Ok(recipe);
    }

    //Get
    [HttpGet]
    public IActionResult Get(int recipe_Id)
    {
        var result = _context.Recipes.Find(recipe_Id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    //Delete
    [HttpDelete]
    public IActionResult Delete(int recipe_Id)
    {
        var result = _context.Recipes.Find(recipe_Id);
        if (result == null)
            return NotFound();

        _context.Recipes.Remove(result);
        _context.SaveChanges();
        return NoContent();
    }

    //Get All
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _context.Recipes.ToList();
        return Ok (result);
    }
}

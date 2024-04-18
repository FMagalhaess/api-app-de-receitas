using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using recipes_api.Repositories;

namespace recipes_api.Controllers;

[ApiController]
[Route("recipe")]
public class RecipesController : ControllerBase
{
    public readonly IRecipeService _service;
    public readonly IRecipeRepository _repository;

    public RecipesController(IRecipeService service, IRecipeRepository repository)
    {
        _service = service;
        _repository = repository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.GetRecipes());
    }

    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {
        try
        {
            return Ok(_repository.GetRecipe(name));
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Recipe recipe)
    {
        try
        {
        Recipe createdRecipe = _repository.AddRecipe(recipe);
        return Created("", createdRecipe);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] Recipe recipe)
    {
        try
        {
            _repository.RecipeExists(name);
            _repository.UpdateRecipe(recipe, name);
            return NoContent();
        }
        catch(Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }


    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        try
        {
        _repository.DeleteRecipe(name);
        return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("recipe")]
public class RecipesController : ControllerBase
{
    public readonly IRecipeService _service;

    public RecipesController(IRecipeService service)
    {
        this._service = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetRecipes());
    }

    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {
        try
        {
            return Ok(_service.GetRecipe(name));
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Recipe recipe)
    {
        Recipe createdRecipe = _service.AddRecipe(recipe);
        return Created("", createdRecipe);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] Recipe recipe)
    {
        try
        {
            _service.UpdateRecipe(recipe);
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
        _service.DeleteRecipe(name);
        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using recipes_api.Repositories;
using recipes_api.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace recipes_api.Controllers;

[ApiController]
[Route("recipe")]
public class RecipesController : ControllerBase
{
    public readonly IRecipeService _service;
    public readonly IRecipeRepository _recipeRepository;
    public readonly IIngredientRepository _ingredientRepository;

    public RecipesController(IRecipeService service, IRecipeRepository repository)
    {
        _service = service;
        _recipeRepository = repository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_recipeRepository.GetRecipes());
    }

    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {
        try
        {
            return Ok(_recipeRepository.GetRecipe(name));
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "User")]
    public IActionResult Create([FromBody] InputRecipeDto recipe)
    {
        try
        {
        Recipe createdRecipe = _recipeRepository.AddRecipe(recipe);
        return Created("", createdRecipe);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] InputRecipeDto recipe)
    {
        try
        {
            _recipeRepository.RecipeExists(name);
            _recipeRepository.UpdateRecipe(recipe, name);
            return NoContent();
        }
        catch(Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }


    [HttpDelete("{recipeId}")]
    public IActionResult Delete(string recipeId)
    {
        try
        {
        _recipeRepository.DeleteRecipe(recipeId);
        return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }
}

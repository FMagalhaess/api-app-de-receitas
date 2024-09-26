using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using recipes_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace recipes_api.Controllers;

[ApiController]
[Route("comment")]
public class CommentController : ControllerBase
{  
    public readonly ICommentRepository _repository;
    
    public CommentController(ICommentRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "User")]
    public IActionResult Create([FromBody]Comment comment)
    {
        try
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email not found in token.");
            }
            comment.Email = email;
            _repository.ExceptionTryCatch(comment);
            return Created("", _repository.CreateComment(comment));
        }
        catch (Exception ex)
        {
            return BadRequest(new {ex.Message});
        }
    }

    [HttpGet("{recipeId}", Name = "GetComment")]
    public IActionResult Get(string recipeId)
    {                
        return Ok(_repository.GetComments(recipeId));                   
    }
}
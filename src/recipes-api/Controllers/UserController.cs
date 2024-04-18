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
[Route("user")]
public class UserController : ControllerBase
{
    public readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("{email}", Name = "GetUser")]
    public IActionResult Get(string email)
    {
        try
        {
            return Ok(_service.GetUser(email));
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        try
        {
            _service.AddUser(user);
            return Created("", user);
        } catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{email}")]
    public IActionResult Update(string email, [FromBody] User user)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{email}")]
    public IActionResult Delete(string email)
    {
        try
        {
            _service.DeleteUser(email);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { ex.Message });
        }
    }
}
using WeatherAPI.Models;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
//UserController: ControllerBase means that UserController inherits from ControllerBase. The ControllerBase class provides methods and properties useful in a controller context for an API. 
public class UsersController : ControllerBase
{
    //private means this can only be access within this class. The readonly modifier allows the field to be assigned in the constructor and nowhere else.
    private readonly UsersService _userService;
    //Private readonly field that will hold a reference to an instance of UserService. 

    //Below is the constructor of UsersController. Takes a parameter of type UsersService. This service - UsersService - will be injected by the ASP.NET Core framework, and it's used to interact with the user-related data and operations. 
    public UsersController(UsersService userService){
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<User>> Get(){        
        return await _userService.GetAsync();
    }
    

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _userService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }
        return user;        
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _userService.CreateAsync(newUser);
        
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    // [HttpPut("{id:length(24)}")]
    // public async Task<IActionResult> Update(string id, Book updatedBook)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     updatedBook.Id = book.Id;

    //     await _booksService.UpdateAsync(id, updatedBook);

    //     return NoContent();
    // }

    // [HttpDelete("{id:length(24)}")]
    // public async Task<IActionResult> Delete(string id)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     await _booksService.RemoveAsync(id);

    //     return NoContent();
    // }
}
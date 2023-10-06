using WeatherAPI.Models;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
//UserController: ControllerBase means that UserController inherits from ControllerBase. The ControllerBase class provides methods and properties useful in a controller context for an API. 
public class UserController : ControllerBase
{
    private readonly UsersService _userService;
    //Private readonly field that will hold a reference to an instance of UserService. 

    public UserController(UsersService userService) => _userService = userService;

    [HttpGet]
    public async Task<List<User>> Get(){
        Console.WriteLine("Get request received");
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
        Console.WriteLine(user);
        Console.WriteLine("User found");

        return user;
        
    }

    // [HttpPost]
    // public async Task<IActionResult> Post(Book newBook)
    // {
    //     await _booksService.CreateAsync(newBook);

    //     return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    // }

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
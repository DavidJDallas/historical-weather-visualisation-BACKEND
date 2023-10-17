using WeatherAPI.Models;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.PasswordHasher;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
//UserController: ControllerBase means that UserController inherits from ControllerBase. The ControllerBase class provides methods and properties useful in a controller context for an API. 
public class UsersController : ControllerBase
{
    //private means this can only be access within this class. The readonly modifier allows the field to be assigned in the constructor and nowhere else.
    private readonly UsersService _userService;
    private readonly IPasswordHasher _passwordHasher;
    //Private readonly field that will hold a reference to an instance of UserService. 

    //Below is the constructor of UsersController. Takes a parameter of type UsersService. This service - UsersService - will be injected by the ASP.NET Core framework, and it's used to interact with the user-related data and operations. 

    // Injected refers to the process of providing an instance of a class or service to a component, rather than the component creating the instance itself. 

    //DI is a design pattern used to achieve loose coupling between different parts of an application, making it more maintanable and testable. 
    public UsersController(UsersService userService, IPasswordHasher passwordHasher){
        _userService = userService;
        _passwordHasher = passwordHasher;
    }

    [HttpGet]
    public async Task<List<User>> Get(){ 
        //This refers to getAysnc method in the UsersService class.        
        return await _userService.GetAsync();
    }
    

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        //This refers to get
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

        //Calls the CreateAsync method in the UsersService Class. 

        string encryptedPass = _passwordHasher.Hash(newUser.Password);
        var result = _passwordHasher.Verify(encryptedPass, newUser.Password);

        newUser.Password = encryptedPass;

        Console.WriteLine(newUser.Password);
        Console.WriteLine(result);



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

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {     

        await _userService.RemoveAllAsync();

        return NoContent();
    }
}
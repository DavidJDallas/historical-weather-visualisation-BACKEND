using DataStoreApi.Models;
using DataStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataStoreApi.Controllers;

[ApiController]
[Route("api/main")]
public class DataController: ControllerBase
{
    private readonly DataService _dataService;
    public DataController(DataService dataservice) => _dataService = dataservice;

    [HttpGet]
    public async Task<List<Data>> Get() => await _dataService.GetAsync();

    //
    [HttpPost]
    public async Task<ActionResult<Data>> Post(Data newData)
    {
        await _dataService.CreateAsync(newData);
        return CreatedAtAction(nameof(Get), new {id=newData.Id}, newData);
    }
}
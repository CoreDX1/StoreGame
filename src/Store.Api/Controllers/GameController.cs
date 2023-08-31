using Microsoft.AspNetCore.Mvc;
using Store.Application.Interface;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameApplication _gameApplication;

    public GameController(IGameApplication gameApplication)
    {
        _gameApplication = gameApplication;
    }

    /// <summary>
    /// Llama a la tabla Game
    /// </summary>
    /// <returns>Una accion de que devuelve la lista de juegos</returns>
    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> GameList()
    {
        var response = await _gameApplication.GetGameList();
        return Ok(response);
    }

    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> GameList([FromQuery] string query)
    {
        var response = await _gameApplication.GetTitleQuery(query);
        return Ok(response);
    }

    [HttpGet]
    [Route("search/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _gameApplication.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    [Route("order")]
    public async Task<IActionResult> Order()
    {
        var response = await _gameApplication.GetNameOrder();
        return Ok(response);
    }
}

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
}

using Microsoft.AspNetCore.Mvc;
using Store.Application.Interface;

namespace Store.Api.Controllers;

public class GameController : ControllerBase
{
    private readonly IGameApplication _gameApplication;

    public GameController(IGameApplication gameApplication)
    {
        _gameApplication = gameApplication;
    }

    [HttpGet("/GameList")]
    public async Task<IActionResult> GameList()
    {
        var response = await _gameApplication.ListGames();
        return Ok(response);
    }
}

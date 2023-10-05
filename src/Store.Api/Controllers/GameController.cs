using Microsoft.AspNetCore.Mvc;

using Store.Application.DTO.Game.Request;
using Store.Application.DTO.Game.Response;
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
    [ProducesResponseType(typeof(IEnumerable<GameTypeResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GameList()
    {
        var response = await _gameApplication.GameListAsync();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GameTypeResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _gameApplication.GameByIdAsync(id);
        return Ok(response);
    }

    [HttpPost("filter")]
    [ProducesResponseType(typeof(IEnumerable<GameTypeResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FilterGame([FromBody] FilterRequestDto filterProductDto)
    {
        var response = await _gameApplication.FilterGamesAsync(filterProductDto);
        return Ok(response);
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<GameTypeResponseDto>), StatusCodes.Status200OK),]
    public async Task<IActionResult> SearchTitle([FromQuery] string query)
    {
        var response = await _gameApplication.GetTitleQuery(query);
        return Ok(response);
    }

    [HttpPut("edit")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> EditGame(int gameId, [FromBody] EditRequestDto data)
    {
        var response = await _gameApplication.EditGameAsync(gameId, data);
        return Ok(response);
    }
}

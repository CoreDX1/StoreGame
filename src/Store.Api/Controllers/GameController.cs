using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO.Game.Request;
using Store.Application.Interface;
using Store.Infrastructure.Commons.Request;

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

    [HttpPost]
    [Route("order")]
    public async Task<IActionResult> Order([FromBody] OrderRequestDto order)
    {
        var response = await _gameApplication.GetNameOrder(order);
        return Ok(response);
    }

    [HttpPost]
    [Route("filter")]
    public async Task<IActionResult> FilterGame([FromBody] GameFilterProductDto filterProductDto)
    {
        var response = await _gameApplication.PostGameFilter(filterProductDto);
        return Ok(response);
    }
}

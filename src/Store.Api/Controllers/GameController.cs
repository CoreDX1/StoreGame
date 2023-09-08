﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("list")]
    public async Task<IActionResult> GameList()
    {
        var response = await _gameApplication.GameListAsync();
        return Ok(response);
    }

    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> GameList([FromQuery] string query)
    {
        var response = await _gameApplication.SearchGamesByTitleAsync(query);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _gameApplication.GameByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    [Route("order")]
    public async Task<IActionResult> Order([FromBody] OrderRequestDto order)
    {
        var response = await _gameApplication.OrderGamesByTitleAsync(order);
        return Ok(response);
    }

    [HttpPost]
    [Route("filter")]
    public async Task<IActionResult> FilterGame([FromBody] GameFilterProductDto filterProductDto)
    {
        var response = await _gameApplication.FilterGamesAsync(filterProductDto);
        return Ok(response);
    }
}

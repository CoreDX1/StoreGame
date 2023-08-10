using Microsoft.AspNetCore.Mvc;

namespace Store.Api;

public class BookController : ControllerBase
{
    [HttpGet("/books")]
    public ActionResult<string> Message()
    {
        return "Hello, World!";
    }
}

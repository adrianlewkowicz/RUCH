using Microsoft.AspNetCore.Mvc;

public class PwRController : Controller
{
    private readonly PwRService _service;

    public PwRController()
    {
        _service = new PwRService();
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetPoints(string partnerId, string partnerKey, string city)
    {
        var response = await _service.GiveMeAllRUCHWithFilledD1(partnerId, partnerKey, city);
        // Tutaj deserializacja odpowiedzi i przekazanie do widoku
        return View("ListPoints", response);
    }
}

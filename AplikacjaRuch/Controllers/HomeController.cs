using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AplikacjaRuch.Models;

namespace AplikacjaRuch.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly PwRService _service;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

        return View("ListPoints", response);
    }


    public IActionResult CreateLabel()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GenerateLabel(LabelRequest request)
    {
        // Wywołaj metodę GenerateLabelBusinessPack z odpowiednimi argumentami
        var generatedLabel = await _service.GenerateLabelBusinessPack(request.SenderName, request.ReceiverName, request.PointId);

        // Jeśli wygenerowana etykieta to obiekt, musisz ją przekazać do odpowiedniego widoku
        return View("GeneratedLabel", generatedLabel);
    }

}

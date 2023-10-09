using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teledok.EF;
using Teledok.Models;
using Teledok.Models.Enums;
using Teledok.Services.Validation;

namespace Teledok.Controllers;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly TeledokDbContext _context;

    public ClientController(ILogger<ClientController> logger, TeledokDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var clients = _context.Clients.Include(c=>c.Founders).ToList();
        return View(clients);
    }

    public List<SelectListItem> GetFoundersAsSelectList()
    {
        List<SelectListItem> listItems = new List<SelectListItem>();
        foreach (var item in _context.Founders.ToList())
        {
            listItems.Add(new SelectListItem()
            {
                Text = item.Fullname,
                Value = item.Id.ToString()
            });
        }

        return listItems;
    }

    public IActionResult CreateClient()
    {
        ViewBag.Founders = GetFoundersAsSelectList();
        return View();
    }

    [HttpPost]
    public IActionResult CreateClient(ClientViewModel client)
    {
        ClientValidation validation = new ClientValidation(client);
        var errorList = validation.Validate();
        foreach (var error in errorList)
        {
            ModelState.AddModelError(error.errorKey,error.errorMessage);
        }
        HashSet<Founder> founders = new();
        if (client.Founders != null)
        {
            foreach (var founderId in client.Founders)
            {
                var founder = _context.Founders.FirstOrDefault(f => f.Id == founderId);
                if (founder != null)
                    founders.Add(founder);
                else
                    ModelState.AddModelError("Founders", "Ошибка нахождения учредителя");
            }
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Founders = GetFoundersAsSelectList();
            return View(client);
        }

        var newClient = new Client()
        {
            INN = client.INN,
            Name = client.Name,
            CreationDate = DateTime.Parse(client.CreationDate),
            LastEditDate = DateTime.Parse(client.LastEditDate),
            ClientType = (ClientTypes)client.ClientType,
            Founders = founders
        };
        try
        {
            _context.Clients.Add(newClient);
            _context.SaveChanges();
        }
        catch (Exception exception)
        {
            ModelState.AddModelError("Db","Ошибка сохранения в БД");
        }
        
        return RedirectToAction("Index");
    }
}
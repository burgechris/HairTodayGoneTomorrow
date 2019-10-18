using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Client.Include(clients => clients.Stylist).ToList();
      return View(model);
    }

    [HttpGet]
    public ActionResult New(int StylistId)
    {
      ViewBag.StylistId = new SelectList(_db.Stylist, "StylistId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult New(Client client)
    {
      _db.Client.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
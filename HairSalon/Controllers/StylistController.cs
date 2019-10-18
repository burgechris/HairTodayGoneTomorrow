using Microsoft.AspNetCore.Mvc;
using Business.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylist.ToList();
      return View(model);
    }

    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
    public ActionResult New(Stylist stylist)
    {
      _db.Stylist.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
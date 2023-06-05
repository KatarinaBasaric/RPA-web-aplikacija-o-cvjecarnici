using Cvjecarnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cvjecarnica.Controllers
{
    public class CvijetController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public CvijetController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisCvijet());

        }
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Cvijet cvijet = new Cvijet() { Id = sljedeciId };
            return View(cvijet);

           
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,Boja,Cijena,SlikaUrl,KategorijaId")] Cvijet cvijet)
        {
            ModelState.Remove("Kategorija"); 

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(cvijet);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", cvijet.KategorijaId);
            return View(cvijet);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvijet = _repozitorijUpita.DohvatiCvijetSIdom(Convert.ToInt32(id));

            if (cvijet == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", cvijet.KategorijaId);
            return View(cvijet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv,Boja,Cijena,SlikaUrl,KategorijaId")] Cvijet cvijet)
        {
            if (id != cvijet.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Kategorija"); 
            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(cvijet);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", cvijet.KategorijaId);
            return View(cvijet);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvijet = _repozitorijUpita.DohvatiCvijetSIdom(Convert.ToInt32(id));
            if (cvijet == null)
            {
                return NotFound();
            }
            return View(cvijet);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var cvijet = _repozitorijUpita.DohvatiCvijetSIdom(id);
            _repozitorijUpita.Delete(cvijet);
            return RedirectToAction("Index");
        }





    }
}

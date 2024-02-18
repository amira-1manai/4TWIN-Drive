############################################################ CONTROLLERS ############################################################


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Data;
using GP.Service;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;


                                       1 ere etape créer le constructeur :

        private readonly IServiceArchitecte serviceArchitecte;
        private readonly IServiceParcelle serviceParcelle;
        private readonly IServicePlan servicePlan;

        public PlanController(IServiceArchitecte _serviceArchitecte, IServiceParcelle _serviceParcelle, IServicePlan _servicePlan) 
        {
            this.serviceArchitecte = _serviceArchitecte;
            this.serviceParcelle = _serviceParcelle;
            this.servicePlan = _servicePlan;

        }

-------------------------------------------------------------- INDEX --------------------------------------------------------------

        public ActionResult Index()
        {
            return View(servicePlan.GetMany());
        }


-------------------------------------------------------------- CREATE --------------------------------------------------------------

        // GET: PlanController/Create
        public ActionResult Create()
        {
            ViewBag.NumeroArchitecte = new SelectList(serviceArchitecte.GetMany(), "NumeroArchitecte", "Nom"); 
            ViewBag.NumeroParcelle = new SelectList(serviceParcelle.GetMany(), "NumeroParcelle", "NatureDuSol"); 
            return View();
        }

        // POST: PlanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plan plan)
        {
            try
            {
                servicePlan.Add(plan);
                servicePlan.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


-------------------------------------------------------------- EDIT --------------------------------------------------------------


        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = prdsrv.GetById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.categoryId = new SelectList(catsrv.GetMany(), "CategoryId", "Name", product.categoryId);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prd)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    prdsrv.Update(prd);
                    prdsrv.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(prd.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.categoryId = new SelectList(catsrv.GetMany(), "CategoryId", "Name", prd.categoryId);
            return View(prd);
        }

        private bool ProductExists(int id)
        {
            return prdsrv.GetMany().Any(e => e.ProductId == id);
        }


-------------------------------------------------------------- DELETE --------------------------------------------------------------

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = prdsrv.GetMany()
                .FirstOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var product = prdsrv.GetById(id);
            prdsrv.Delete(product);
            prdsrv.Commit();
            return RedirectToAction(nameof(Index));
        }


-------------------------------------------------------------- Importer une image --------------------------------------------------------------

     // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(catsrv.GetMany(), "CategoryId", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, IFormFile file)
        {
            try
            {
                string wwwrootpath = webHostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                p.Image = filename;
                string path = Path.Combine(wwwrootpath + "\\Upload\\", filename);
                using (var fileStram = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStram);
                }
                prdsrv.Add(p);
                prdsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


Dans la vue Create, ajouter le code suivant :

<form asp-action="Create" enctype="multipart/form-data">

<div class="form-group">
	<label asp-for="Image" class="control-label"></label>
	<input name="file" type="file" />
	<span asp-validation-for="Image" class="text-danger"></span>
</div>

Dans la vue index, ajouter le code suivant :

<td>
	<img src="~/Upload/@item.Image" width="50" height="50" />
</td>

-------------------------------------------------------------- Barre de recherche --------------------------------------------------------------

        public ActionResult Index(string filter)
        {
            var listProducts = prdsrv.GetMany();
            if (!String.IsNullOrEmpty(filter))
            {
                listProducts = prdsrv.GetProductByName(filter);
            }
            return View(listProducts);
        }
				
Dans le service :		
public IEnumerable<Product> GetProductByName(string name)
{
	return GetMany().Where(p => p.Name.ToLower().Contains(name.ToLower()));
}

// ou bien 

        // GET: CagnotteController
        public ActionResult Index()
        {
            return View(cagnotteService.GetMany());
        }
        // Post: CagnotteController/Index
        [HttpPost]
        public ActionResult Index(string filter)
        {
            var list = cagnotteService.GetMany();
            if (!String.IsNullOrEmpty(filter))
            {
                list = list.Where(p => p.Titre.ToString().Equals(filter)).ToList();
            }
            return View(list);
        }
		
Dans la vue index, ajouter le code suivant :

<h1>Index</h1>
<form asp-action="Index">
    <table>
        <tr>
            <td>Rechereche Par Nom : <input type="text" name="filter" /></td>
            <td><input type="submit" value="rechercher" id="submit" /></td>
        </tr>
    </table>
</form>

-------------------------------------------------------------- Vue Partielle --------------------------------------------------------------

        public ActionResult Index2()
        {
            return View(prdsrv.GetMany());
        }
		
		public ActionResult _Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = prdsrv.GetMany().FirstOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return PartialView(product);
        }
		
2emeEtape Générer la vue vide Index2

3emeEatpe Ajouter le code suivant dans la vue Index2
@model IEnumerable<Domain.Entities.Product>

@foreach (var item in Model)
    {
        <partial name="_Details" model="item"/>
    }
4eme eatpe Ajouter une vue partielle qui s’appelle « _Details »


------------------------------------------------------- Liste Déroulante Statique(enum) -------------------------------------------------------

Dans la vue Create, ajouter le code suivant :

@using GP.Domain.Entities

<div class="form-group">
	<label asp-for="Etat" class="control-label"></label>
	<select asp-for="Etat" asp-items="Html.GetEnumSelectList<Etat>()" class="form-control"></select>
	<span asp-validation-for="Etat" class="text-danger"></span>
</div>















using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampusADO.UI.Web.Data;
using CampusADO.UI.Web.Models;

namespace CampusADO.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public ProdutoController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        DALProduto DAL = new DALProduto();

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            return View(DAL.Get().ToList());
            //return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            //var produto = await _context.Produtos
            //    .FirstOrDefaultAsync(m => m.ProdutoID == id);

            Produto produto = DAL.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("ProdutoID,Nome,Preco,Estoque")] */Produto produto)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(produto);
                //await _context.SaveChangesAsync();
                DAL.Cadastra(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var produto = await _context.Produtos.FindAsync(id);
            Produto produto = DAL.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,/*, [Bind("ProdutoID,Nome,Preco,Estoque")]*/ Produto produto)
        {
            if (id != produto.ProdutoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DAL.Atualiza(produto);
                    //_context.Update(produto);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoID))
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
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto produto = DAL.GetById(id);
            //var produto = await _context.Produtos
            //    .FirstOrDefaultAsync(m => m.ProdutoID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var produto = await _context.Produtos.FindAsync(id);
            //_context.Produtos.Remove(produto);
            //await _context.SaveChangesAsync();
            DAL.Exclui(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            // return _context.Produtos.Any(e => e.ProdutoID == id);
            Produto produto = DAL.GetById(id);

            return produto != null;
        }
    }
}

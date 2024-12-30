using ProductDetailProject.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace ProductDetailProject.Controllers
{
    public class ProductController : Controller
    {

        ServicesContext db = new ServicesContext();
        // GET: Product


        //Pagination on server side for Product Table
        public ActionResult Index(int ? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var pdata = db.ProductTable.OrderBy(x => x.CategoryId).ToPagedList(pageNumber, pageSize);
            return View(pdata);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ProductTable pt)
        {
            db.ProductTable.Add(pt);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


        public ActionResult Edit(int id)
        {
            var row = db.ProductTable.Where(model => model.ProductId == id).FirstOrDefault();
            return View(row);
        }



        [HttpPost]
        public ActionResult Edit(ProductTable pt)
        {
            db.Entry(pt).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");

        }


        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var context = new ServicesContext())
            {
                var data = context.ProductTable.FirstOrDefault(x => x.ProductId == id);
                if (data != null)
                {
                    context.ProductTable.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("index", "Product");
                }
                else
                    return View();
            }
        }




        //Pagination on server side for ProductList
        public ActionResult ProductList(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var productlist = (from pt in db.ProductTable
                                join ct in db.CategoryTable on pt.CategoryId equals ct.CategoryId
                               select new ShowData
                                {
                                    ProductId = pt.ProductId,
                                    ProductName = pt.ProductName,
                                    CategoryId = ct.CategoryId,
                                    CategoryName = ct.CategoryName
                                }).OrderBy(pt => pt.CategoryId).ToPagedList(pageNumber, pageSize);
            return View(productlist);

          

        }
    }
}
    

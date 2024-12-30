using PagedList;
using ProductDetailProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace ProductDetailProject.Controllers
{
    public class CategoryController : Controller
    {

        ServicesContext db = new ServicesContext();
        // GET: Category

        //Pagination on server side for Category Table
        public ActionResult Index(int ? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;
            var cdata = db.CategoryTable.OrderBy(x => x.CategoryId).ToPagedList(pageNumber, pageSize);
            return View(cdata);
        }


        public ActionResult Insert()
        {
            return View();
        }

        //to insert:-
        [HttpPost]
        public ActionResult Insert(CategoryTable ct)
        {
                db.CategoryTable.Add(ct);
                db.SaveChanges();
                return RedirectToAction("Index", "Category");
              
            
        }


        //to Edit:-
        public ActionResult Edit(int id)
        {
            var row = db.CategoryTable.Where(model => model.CategoryId == id).FirstOrDefault();
            return View(row);
        }



        [HttpPost]
        public ActionResult Edit(CategoryTable ct)
        {
            db.Entry(ct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");

        }


        //to Delete:-
        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {

             using (var context = new ServicesContext())
            {
                var _data = context.CategoryTable.FirstOrDefault(x => x.CategoryId == Id);
                if (_data != null)
                {
                    context.CategoryTable.Remove(_data);
                    context.SaveChanges();
                    return RedirectToAction("index", "Category");
                }
                else
                    return View();
            }
        }
    }
}
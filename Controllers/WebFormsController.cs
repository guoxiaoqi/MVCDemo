using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Data;

namespace MVCDemo.Controllers
{
    public class WebFormsController : Controller
    {
        private Model1 db = new Model1();
        //
        // GET: /WebForms/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortOrder">排序</param>
        /// <param name="nameSearch">姓名查找</param>
        /// <param name="currentFilter">分页时过滤条件不变</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult WebForm1(string sortOrder,string nameSearch, string  currentFilter,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //分页时保持搜索框不变
            if(nameSearch!=null)
            {
                page = 1;
            }
            else
            {
                nameSearch = currentFilter;
            }
            
            ViewBag.CurrentFilter = nameSearch;

            var stus = from u in db.StuInfo
                       select u;
            //判断字符串是否为0或空
            if (!string.IsNullOrEmpty(nameSearch))
            {
                //名字过滤
                stus = stus.Where(u => u.SName.Contains(nameSearch));
            }

            //排序
            switch (sortOrder)
            {
                case "name_desc":
                    stus = stus.OrderByDescending(u => u.SName);
                    break;
                default:
                    stus = stus.OrderBy(u => u.SName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(stus.ToPagedList(pageNumber,pageSize));
        }

        //新建学生
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StuInfo StuInfo)
        {
            db.StuInfo.Add(StuInfo);
            db.SaveChanges();
            return RedirectToAction("WebForm1");
        }

        //修改用户
        public ActionResult Edit(int id)
        {
            StuInfo stuInfo = db.StuInfo.Find(id);
            return View(stuInfo);
        }
        [HttpPost]
        public ActionResult Edit(StuInfo stuInfo)
        {
            db.Entry(stuInfo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("WebForm1");
        }

        //删除用户
        public ActionResult Delete(int id)
        {
            StuInfo stuInfo = db.StuInfo.Find(id);
            return View(stuInfo);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StuInfo stuInfo = db.StuInfo.Find(id);
            db.StuInfo.Remove(stuInfo);
            db.SaveChanges();
            return RedirectToAction("WebForm1");
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Models.ViewModel;

namespace FinalProject.Controllers
{
    //MorningBroadway1Entities _db = new MorningBroadway1Entities();
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ManageProduct()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (MorningBroadway1Entities db = new MorningBroadway1Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<ProductViewModel> lstitem = new List<ProductViewModel>();
                var lst = db.tblProducts.Include("tblCatagory").ToList();
                foreach (var item in lst)
                {
                    lstitem.Add(new ProductViewModel() { ProductId = item.ProductId, CategoryName = item.tblCatagory.CatagoryName, ProductName = item.ProductName, UnitPrice = item.Units, SellingPrice = item.SellingPrice, Photo = item.Photo });
                }
                return Json(new { data = lstitem }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (MorningBroadway1Entities db = new MorningBroadway1Entities())
                {
                    ViewBag.Categories = db.tblCatagories.ToList();
                    ViewBag.Action = "Create New Product";
                    return View(new ProductViewModel());
                }
            }
            else
            {
                using (MorningBroadway1Entities db = new MorningBroadway1Entities())
                {
                    ViewBag.Action = "Edit Product";
                    ViewBag.Categories = db.tblCatagories.ToList();
                    tblProduct item = db.tblProducts.Where(i => i.ProductId == id).FirstOrDefault();
                    ProductViewModel itemvm = new ProductViewModel();
                    itemvm.ProductId = item.ProductId;
                    itemvm.CatagoryId = Convert.ToInt32(item.CatagoryId);
                    itemvm.ProductName = item.ProductName;
                    itemvm.UnitPrice = item.Units;
                    itemvm.SellingPrice = item.SellingPrice;
                    //itemvm.Description = item.de;
                    itemvm.Photo = item.Photo;
                    itemvm.IsSpecial = item.IsSpecial;

                    return View(itemvm);
                }
            }
        }

        [HttpPost]

        public ActionResult AddOrEdit(ProductViewModel ivm)
        {
            using (MorningBroadway1Entities db = new MorningBroadway1Entities())
            {
                if (ivm.ProductId == 0)
                {
                    tblProduct itm = new tblProduct();

                    itm.CatagoryId = Convert.ToInt32(ivm.CatagoryId);
                    itm.ProductName = ivm.ProductName;
                    itm.Units = ivm.UnitPrice;
                    itm.SellingPrice = ivm.SellingPrice;
                    //itm.Description = ivm.Description;
                    itm.IsSpecial = ivm.IsSpecial;
                    HttpPostedFileBase fup = Request.Files["Photo"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/ProductImages/" + fup.FileName));
                            itm.Photo = fup.FileName;
                        }
                    }



                    db.tblProducts.Add(itm);
                    db.SaveChanges();
                    ViewBag.Message = "Created Successfully";
                }
                else
                {
                    tblProduct itm = db.tblProducts.Where(i => i.ProductId == ivm.ProductId).FirstOrDefault();
                    itm.CatagoryId = Convert.ToInt32(ivm.CatagoryId);
                    itm.ProductName = ivm.ProductName;
                    itm.Units = ivm.UnitPrice;
                    itm.SellingPrice = ivm.SellingPrice;
                    //itm.Description = ivm.Description;
                    itm.IsSpecial = ivm.IsSpecial;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/ProductImages/" + fup.FileName));
                            itm.Photo = fup.FileName;
                        }
                    }



                    db.SaveChanges();
                    ViewBag.Message = "Updated Successfully";

                }
                ViewBag.Categories = db.tblCatagories.ToList();
                return View(new ProductViewModel());

            }


        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            using (MorningBroadway1Entities db = new MorningBroadway1Entities())
            {
                tblProduct sm = db.tblProducts.Where(x => x.ProductId == id).FirstOrDefault();
                db.tblProducts.Remove(sm);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
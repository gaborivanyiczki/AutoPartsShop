using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.Areas.admin.Controllers
{
    public class AttributesController : Controller
    {
        private StoreDB db = new StoreDB();
        // GET: admin/Attributes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Attributes attributes) {
            if (ModelState.IsValid)
            {
                db.Attributes.Add(attributes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attributes);
        }

        //ATTRIBUTE VALUES PART
        public ActionResult Values()
        {
            return View();
        }

        public ActionResult AddValues()
        {
            ViewBag.Attribute_ID = new SelectList(db.Attributes, "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddValues(AttributeValue attributeValue)
        {
            if (ModelState.IsValid)
            {
                db.AttributeValues.Add(attributeValue);
                db.SaveChanges();
                return RedirectToAction("Values");
            }
            ViewBag.Attribute_ID = new SelectList(db.Attributes, "ID", "Name", attributeValue.Attribute_ID);
            return View(attributeValue);
        }

        //PRODUCT ATTRIBUTE PART
        public ActionResult ProductAttributes()
        {
            return View();
        }

        public ActionResult AddAttributes()
        {
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Name");
            ViewBag.AttributeValue_ID = new SelectList(db.AttributeValues, "ID", "AttributeValueName");
           
            return View();
        }

        [HttpPost]
        public ActionResult AddAttributes(ProductAttributeValue productAttribute)
        {
            if (ModelState.IsValid)
            {
                db.ProductAttributeValues.Add(productAttribute);
                db.SaveChanges();
                return RedirectToAction("ProductAttributes");
            }
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Name", productAttribute.Product_ID);
            ViewBag.AttributeValue_ID = new SelectList(db.AttributeValues, "ID", "AttributeValueName" , productAttribute.AttributeValue_ID);

            return View(productAttribute);
        }
    }
}
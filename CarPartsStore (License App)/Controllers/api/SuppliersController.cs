using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarPartsStore__License_App_.Models;
using CarPartsStore__License_App_.Dto;
using AutoMapper;

namespace CarPartsStore__License_App_.Controllers.api
{
    public class SuppliersController : ApiController
    {
        private StoreDB db = new StoreDB();

        //get suppliers
        [HttpGet]
        public IHttpActionResult GetSuppliers()
        {
            var suppliersDTO = db.Suppliers.ToList()
                .Select(Mapper.Map<Supplier, SuppliersDTO>);
            return Ok(suppliersDTO);
        }

        //get supplier
        [HttpGet]
        public SuppliersDTO GetSupplier(int id)
        {
            var supplier = db.Suppliers.SingleOrDefault(c => c.ID == id);

            if(supplier == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Supplier, SuppliersDTO>(supplier);
        }

        //create supplier
        [HttpPost]
        public IHttpActionResult CreateSupplier(SuppliersDTO suppliersDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var supplier = Mapper.Map<SuppliersDTO, Supplier>(suppliersDTO);

            db.Suppliers.Add(supplier);
            db.SaveChanges();

            suppliersDTO.ID = supplier.ID;

            return Ok(supplier);

        }

        //update supplier
        [HttpPut]
        public void UpdateSupplier(int id, SuppliersDTO suppliersDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

           var supplierInDB = db.Suppliers.SingleOrDefault(c => c.ID == id);

            if (supplierInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(suppliersDTO, supplierInDB);

            db.SaveChanges();
        }

        //Delete
        [HttpDelete]
        public void DeleteSupplier(int id)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var supplierInDB = db.Suppliers.SingleOrDefault(c => c.ID == id);

            if (supplierInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Suppliers.Remove(supplierInDB);
            db.SaveChanges();
        }
    }
}

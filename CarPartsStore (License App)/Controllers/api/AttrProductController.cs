using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarPartsStore__License_App_.Dto;
using CarPartsStore__License_App_.Models;
using AutoMapper;

namespace CarPartsStore__License_App_.Controllers.api
{
    public class AttrProductController : ApiController
    {
        private StoreDB db = new StoreDB();

        //get 
        [HttpGet]
        public IHttpActionResult Get()
        {
            var attribute = db.ProductAttributeValues.ToList()
                .Select(Mapper.Map<ProductAttributeValue, ProductAttributeDTO>);
            return Ok(attribute);
        }

        //return attribute by id
        [HttpGet]
        public ProductAttributeDTO Get(int id)
        {
            var attribute = db.ProductAttributeValues.SingleOrDefault(c => c.ID == id);

            if (attribute == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<ProductAttributeValue, ProductAttributeDTO>(attribute);
        }


        //Update 
        [HttpPut]
        public void Update(int id, ProductAttributeDTO attributeDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var attributeinDB = db.ProductAttributeValues.SingleOrDefault(c => c.ID == id);

            if (attributeinDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(attributeDTO, attributeinDB);

            db.SaveChanges();
        }


        //Delete
        [HttpDelete]
        public void Delete(int id)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var attributeINDB = db.ProductAttributeValues.SingleOrDefault(c => c.ID == id);

            if (attributeINDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.ProductAttributeValues.Remove(attributeINDB);
            db.SaveChanges();
        }
    }
}

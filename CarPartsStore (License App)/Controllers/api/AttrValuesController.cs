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
    public class AttrValuesController : ApiController
    {
        private StoreDB db = new StoreDB();

        //get 
        [HttpGet]
        public IHttpActionResult Get()
        {
            var attribute = db.AttributeValues.ToList()
                .Select(Mapper.Map<AttributeValue, AttributeValueDTO>);
            return Ok(attribute);
        }

        //return attribute by id
        [HttpGet]
        public AttributeValueDTO Get(int id)
        {
            var attribute = db.AttributeValues.SingleOrDefault(c => c.ID == id);

            if (attribute == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<AttributeValue, AttributeValueDTO>(attribute);
        }


        //Update 
        [HttpPut]
        public void Update(int id, AttributeValueDTO attributeDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var attributeinDB = db.AttributeValues.SingleOrDefault(c => c.ID == id);

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

            var attributeINDB = db.AttributeValues.SingleOrDefault(c => c.ID == id);

            if (attributeINDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.AttributeValues.Remove(attributeINDB);
            db.SaveChanges();
        }
    }
}

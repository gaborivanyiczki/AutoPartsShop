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
    public class AttributeController : ApiController
    {
        private StoreDB db = new StoreDB();

        //get 
        [HttpGet]
        public IHttpActionResult Get()
        {
            var attribute = db.Attributes.ToList()
                .Select(Mapper.Map<Attributes, AttributeDTO>);
            return Ok(attribute);
        }

        //return attribute by id
        [HttpGet]
        public AttributeDTO Get(int id)
        {
            var attribute = db.Attributes.SingleOrDefault(c => c.ID == id);

            if (attribute == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Attributes, AttributeDTO>(attribute);
        }


        //Update 
        [HttpPut]
        public void Update(int id, AttributeDTO attributeDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var attributeinDB = db.Attributes.SingleOrDefault(c => c.ID == id);

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

            var attributeINDB = db.Attributes.SingleOrDefault(c => c.ID == id);

            if (attributeINDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Attributes.Remove(attributeINDB);
            db.SaveChanges();
        }

    }
}

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
    public class BodyController : ApiController
    {

        private StoreDB db = new StoreDB();

        //get bodies
        [HttpGet]
        public IHttpActionResult GetBodies()
        {
            var bodies = db.Body.ToList()
                .Select(Mapper.Map<Body, BodyDTO>);
            return Ok(bodies);
        }

        //return body by id
        [HttpGet]
        public BodyDTO GetBody(int id)
        {
            var body = db.Body.SingleOrDefault(c => c.ID == id);

            if (body == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Body, BodyDTO>(body);
        }

        //create body
        [HttpPost]
        public IHttpActionResult CreateBody(BodyDTO bodyDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var body = Mapper.Map<BodyDTO, Body>(bodyDTO);

            db.Body.Add(body);
            db.SaveChanges();

            bodyDTO.ID = body.ID;

            return Ok(body);
        }


        //Update body
        [HttpPut]
        public void UpdateBody(int id, BodyDTO bodyDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var bodyInDB = db.Body.SingleOrDefault(c => c.ID == id);

            if (bodyInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(bodyDTO, bodyInDB);

            db.SaveChanges();
        }


        //Delete
        [HttpDelete]
        public void DeleteBody(int id)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var BodyInDB = db.Body.SingleOrDefault(c => c.ID == id);

            if (BodyInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Body.Remove(BodyInDB);
            db.SaveChanges();
        }
    }
}

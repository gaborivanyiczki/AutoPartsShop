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
    public class ManufacturesController : ApiController
    {
        private StoreDB db = new StoreDB();

        //get manufactures
        [HttpGet]
        public IHttpActionResult GetManufactures()
        {
            var manufactures = db.Manufactures.ToList()
                .Select(Mapper.Map<Manufacture, ManufactureDTO>);

            return Ok(manufactures);
        }

        //get manufacture by id
        [HttpGet]
        public ManufactureDTO GetManufacture(int id)
        {
            var manufacture = db.Manufactures.SingleOrDefault(c => c.ID == id);

            if (manufacture == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Manufacture, ManufactureDTO>(manufacture);
        }

        //create manufacture
        [HttpPost]
        public IHttpActionResult CreateManufacture(ManufactureDTO manufactureDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var manufactures = Mapper.Map<ManufactureDTO, Manufacture>(manufactureDTO);

            db.Manufactures.Add(manufactures);
            db.SaveChanges();

            manufactureDTO.ID = manufactures.ID;

            return Ok(manufactures);
        }

        //update manufactures
        [HttpPut]
        public void UpdateManufactures(int id,ManufactureDTO manufactureDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var manufactureInDB = db.Manufactures.SingleOrDefault(c => c.ID == id);

            if (manufactureInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(manufactureDTO, manufactureInDB);

            db.SaveChanges();
        }

        //Delete
        [HttpDelete]
        public void DeleteManufacture(int id)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var manufactureInDB = db.Manufactures.SingleOrDefault(c => c.ID == id);

            if (manufactureInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Manufactures.Remove(manufactureInDB);
            db.SaveChanges();
        }


    }
}

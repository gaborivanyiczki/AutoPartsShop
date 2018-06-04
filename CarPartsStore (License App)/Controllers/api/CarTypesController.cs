using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CarPartsStore__License_App_.Dto;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.Controllers.api
{

    public class CarTypesController : ApiController
    {
        private StoreDB db = new StoreDB();

        //Get cartypes
        [HttpGet]
        public IHttpActionResult GetCarTypes()
        {
            var carTypeDto = db.CarType
                .ToList()
                .Select(Mapper.Map<CarType, CarTypeDTO>);
            return Ok(carTypeDto);
        }

        //Get a cartype
        [HttpGet]
        public CarTypeDTO GetCarType(int id)
        {
            var carType = db.CarType.SingleOrDefault(c => c.ID == id);

            if (carType == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<CarType, CarTypeDTO>(carType);
        }

        //Create CarType
        [HttpPost]
        public IHttpActionResult CreateCarType(CarTypeDTO carTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var carType = Mapper.Map<CarTypeDTO, CarType>(carTypeDTO);

            db.CarType.Add(carType);
            db.SaveChanges();

            carTypeDTO.ID = carType.ID;

            return Ok(carType);
        }

        //Update cartype
        [HttpPut]
        public void UpdateCarType(int id, CarTypeDTO carTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var cartypeInDB = db.CarType.SingleOrDefault(c => c.ID == id);

            if (cartypeInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(carTypeDTO, cartypeInDB);

            db.SaveChanges();
        }


        //Delete
        [HttpDelete]
        public void DeleteCarType(int id)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var carTypeInDB = db.CarType.SingleOrDefault(c => c.ID == id);

            if (carTypeInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.CarType.Remove(carTypeInDB);
            db.SaveChanges();
        }

    }
}

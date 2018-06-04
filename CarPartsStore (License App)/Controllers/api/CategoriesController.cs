using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CarPartsStore__License_App_.Models;
using CarPartsStore__License_App_.Dto;

namespace CarPartsStore__License_App_.Controllers.api
{
    public class CategoriesController : ApiController
    {
        private StoreDB db = new StoreDB();

        //get categories
        [HttpGet]
        public IHttpActionResult GetCategory()
        {
            var categoryDto = db.Categories.ToList()
                .Select(Mapper.Map<Category, CategoriesDTO>);
            return Ok(categoryDto);
        }

        //get a category
        [HttpGet]
        public CategoriesDTO GetCategory(int id)
        {
            var category = db.Categories.SingleOrDefault(c => c.ID == id);

            if(category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Category, CategoriesDTO>(category);
        }


        //post category
        [HttpPost]
        public IHttpActionResult CreateCategory(CategoriesDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var category = Mapper.Map<CategoriesDTO, Category>(categoryDTO);

            db.Categories.Add(category);
            db.SaveChanges();

            categoryDTO.ID = category.ID;

            return Ok(category);
        }


        //Update cartype
        [HttpPut]
        public void UpdateCategory(int id, CategoriesDTO categoriesDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var categoryInDB = db.Categories.SingleOrDefault(c => c.ID == id);

            if(categoryInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(categoriesDTO, categoryInDB);

            db.SaveChanges();
        }

        //Delete
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var categoryInDB = db.Categories.SingleOrDefault(c => c.ID == id);

            if (categoryInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Categories.Remove(categoryInDB);
            db.SaveChanges();
        }
    }
}

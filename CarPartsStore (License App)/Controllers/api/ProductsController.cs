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
    public class ProductsController : ApiController
    {
        private StoreDB db = new StoreDB();

        //get products list
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            var products = db.Products.ToList()
                .Select(Mapper.Map<Product, ProductDTO>);

            return Ok(products);
        }


        //get product by id
        [HttpGet]
        public ProductDTO GetProduct(int id)
        {
            var product = db.Products.SingleOrDefault(c => c.ID == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Product, ProductDTO>(product);
        }

        //create product
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDTO, Product>(productDTO);

            db.Products.Add(product);
            db.SaveChanges();

            productDTO.ID = product.ID;

            return Ok(product);
        }

        //update product
        [HttpPut]
        public void UpdateProduct(int id, ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var product = db.Products.SingleOrDefault(c => c.ID == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(productDTO, product);

            db.SaveChanges();
        }

        //Delete
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var product = db.Products.SingleOrDefault(c => c.ID == id);

            if (product == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Products.Remove(product);
            db.SaveChanges();
        }



    }
}

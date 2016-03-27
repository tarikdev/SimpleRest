using Coolblue.Assigment.DAL;
using Coolblue.Assigment.DAL.Entities;
using Coolblue.Assigment.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoolblueAssigment.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        readonly IProductRepository _productRepo;

        public ProductController()
        {
            _productRepo = new ProductRepository();
        }
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpPost]
        public Product Post(Product value)
        {
            return _productRepo.AddProduct(value);
        }

        [HttpGet]
        public HttpResponseMessage Get(string productId)
        {
            var product = _productRepo.GetProduct(productId);

            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);

            }

            return Request.CreateResponse(HttpStatusCode.Found,product);
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productRepo.GetAllProducts().ToList();
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string productId)
        {
            var result = _productRepo.RemoveProduct(productId);

            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Put(string productId, Product value)
        {
            var result = _productRepo.UpdateProduct(productId, value);

            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK,value);
        }
    }
}

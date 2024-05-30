using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace APIIntroduction.Controllers
{
    public class ProductController : ApiController
    {
        #region Normal c# method
        //[HttpGet]
        //public List<Product> GetAll()
        //{
        //    List<Product> products = new List<Product>()
        //    {

        //        new Product() { ProductID = 1, Name = "Shirt", Price = 599 },
        //        new Product() { ProductID = 2, Name = "Shoes", Price = 1599 },

        //        new Product() { ProductID = 3, Name = "Jeans", Price = 2599 }

        //    };
        //    return products;
        //}
        #endregion Normal c# method

        #region using httpresponsemessage
        //[HttpGet]
        //public HttpResponseMessage GetAll()
        //{
        //    List<Product> products = new List<Product>()
        //    {

        //        new Product() { ProductID = 1, Name = "Shirt", Price = 599 },
        //        new Product() { ProductID = 2, Name = "Shoes", Price = 1599 },

        //        new Product() { ProductID = 3, Name = "Jeans", Price = 2599 }

        //    };
        //    return Request.CreateResponse(HttpStatusCode.OK,products);
        //}

        #endregion using httpresponsemessage

        [HttpGet]
        public  IHttpActionResult GetAll() {  
            List<Product> products = new List<Product>()
            {

                new Product() { ProductID = 1, Name = "Shirt", Price = 599 },
                new Product() { ProductID = 2, Name = "Shoes", Price = 1599 },

                new Product() { ProductID = 3, Name = "Jeans", Price = 2599 }

            };
            return  Ok(products);
        }

        #region Normal c# method
        //public Product GetProductById(int id)
        //{
        //    Product product = new Product()
        //    { ProductID = 1, Name = "Shirt", Price = 399 };
        //    return product;
        //}
        #endregion Normal c# method

        #region using HttpResponseMessage
        //[HttpGet]
        //public HttpResponseMessage GetProductById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    Product product = new Product()
        //    { ProductID = 1, Name = "Shirt", Price = 399 };
        //    return Request.CreateResponse(HttpStatusCode.OK, product);
        //}
        #endregion using HttpResponseMessage

        [HttpGet]
        public  IHttpActionResult GetProductById([FromUri]int id)
        {
            if (id <= 0)
            {
                //return Request.CreateResponse(HttpStatusCode.BadRequest);
                return BadRequest("Product ID cannot be zero");
            }

            Product product = new Product()
            { ProductID = 1, Name = "Shirt", Price = 399 };
            return Ok(product);
        }


        [HttpPost] //creating product
        
        public IHttpActionResult create([FromBody] Product product)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpPut] //to updates products
        public IHttpActionResult Update([FromUri]int id,[FromBody] Product product)
        {
            try
            {
                if (product !=null &&  product.ProductID >0)
                {
                    if (id ==  product.ProductID)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                    

                }
                else
                {
                    return BadRequest();
                }
 
            }
             
            catch
            {
                return InternalServerError();
            }

        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            if(id>0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

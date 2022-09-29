using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.IQApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.IQApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // /api/products/getproducts
        [Authorize]
        [HttpGet]
        [Authorize(Policy = "ReadProduct")]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "Kalem",
                    Price = 100,
                    Stock = 500
                },
                new Product()
                {
                    Id = 2,
                    Name = "Silgi",
                    Price = 150,
                    Stock = 300
                },
                new Product()
                {
                    Id = 3,
                    Name = "Defter",
                    Price = 58,
                    Stock = 400
                },
                new Product()
                {
                    Id = 4,
                    Name = "Makas",
                    Price = 200,
                    Stock = 300
                }
            };
            return Ok(productList);
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpPost]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"{id}'si olan ürün güncellendi");
        }

        [Authorize(Policy = "UpdateOrCreate")]//Scope üzerine eklenmiş olanı buradan alabiliriz. Startupa ekledik
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.Id = 2;
            return Ok(product);
        }
    }
}
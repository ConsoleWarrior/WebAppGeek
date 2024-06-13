using Microsoft.AspNetCore.Mvc;
using WebAppGeek.Abstraction;
using WebAppGeek.Data;
using WebAppGeek.Dto;
using WebAppGeek.Models;
using WebAppGeek.Repository;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public ActionResult<int> AddProduct(ProductDto productDto)
        {
            try
            {
                var id = _productRepository.AddProduct(productDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409);
            }
            //using (StorageContext storageContext = new StorageContext())
            //{
            //    if (storageContext.Products.Any(p => p.Name == name))
            //        return StatusCode(409);

            //    var product = new Product() { Name = name, Description = description, Price = price };
            //    storageContext.Products.Add(product);
            //    storageContext.SaveChanges();
            //    return Ok(product.Id);

        }
        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_productRepository.GetAllProducts());

            //using(StorageContext storageContext = new StorageContext())
            //{
            //    //var list = storageContext.Products.Select(p => new Product{Name = p.Name, Description = p.Description, Price = p.Price}).ToList();
            //    var list = storageContext.Products.ToList();
            //    return Ok(list);
            //}
        }
        //[HttpDelete]
        //public ActionResult DeleteProduct(int id)
        //{
        //    using (StorageContext storageContext = new StorageContext())
        //    {
        //        var product = storageContext.Products.FirstOrDefault(p => p.Id == id);
        //        if (product != null)
        //        {
        //            storageContext.Products.Remove(product);
        //            storageContext.SaveChanges();
        //            return Ok();
        //        }
        //        return StatusCode(404, "Нет продукта с таким ID");
        //    }
        //}
    }
}

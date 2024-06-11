using Microsoft.AspNetCore.Mvc;
using WebAppGeek.Data;
using WebAppGeek.Models;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProductGroup(string name, string description)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                if (storageContext.ProductGroups.Any(p => p.Name == name))
                    return StatusCode(409);

                var productGroup = new ProductGroup() { Name = name, Description = description };
                storageContext.ProductGroups.Add(productGroup);
                storageContext.SaveChanges();
                return Ok($"Добавлена группа с ID = {productGroup.Id}");
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductGroup>> GetAllProductGroups()
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var list = storageContext.ProductGroups.ToList();
                return Ok(list);
            }
        }
        [HttpDelete]
        public ActionResult DeleteProductGroup(int id)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var productGroup = storageContext.ProductGroups.FirstOrDefault(p => p.Id == id);
                if (productGroup != null)
                {
                    storageContext.ProductGroups.Remove(productGroup);
                    storageContext.SaveChanges();
                    return Ok();
                }
                return StatusCode(404,"Нет группы с таким ID");
            }
        }
    }
}

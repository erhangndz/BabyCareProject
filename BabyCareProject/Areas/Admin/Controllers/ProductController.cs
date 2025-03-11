using BabyCareProject.Dtos.ProductDtos;
using BabyCareProject.Services.InstructorServices;
using BabyCareProject.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService _productService, IInstructorService _instructorService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateProduct()
        {
            var instructors = await _instructorService.GetAllInstructorAsync();
            ViewBag.instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateAsync(createProductDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateProduct(string id)
        {
            var instructors = await _instructorService.GetAllInstructorAsync();
            ViewBag.instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();

            var value = await _productService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(updateProductDto);
            return RedirectToAction(nameof(Index));
        }
    }
}

using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetail(string id)
        {
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDdetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductAsync(createProductDetailDto);
            return Ok("Product detail başarıyla eklendi.");
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Product detail başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Product detail başarıyla güncellendi.");
        }
    }
}

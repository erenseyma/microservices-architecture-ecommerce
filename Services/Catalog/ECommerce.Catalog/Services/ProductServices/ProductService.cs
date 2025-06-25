using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productColleciton;

        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productColleciton = database.GetCollection<Product>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productColleciton.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productColleciton.DeleteOneAsync(x=>x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values= await _productColleciton.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productColleciton.Find<Product>(x=>x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productColleciton.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}

using Dapper;
using ECommerce.Discount.Context;
using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code ,@rate ,@isActive ,@validDate)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@code",createCouponDto.Code);
            paramaters.Add("@rate",createCouponDto.Rate);
            paramaters.Add("@isActive",createCouponDto.IsActive);
            paramaters.Add("@validDate",createCouponDto.validDate);
            using(var connection=_dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons Where CouponId=@couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@couponId",id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,paramaters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId = @couponId";
            var parameters = new DynamicParameters();  
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where CouponId=@couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@code", updateCouponDto.Code);
            paramaters.Add("@rate", updateCouponDto.Rate);
            paramaters.Add("@isActive", updateCouponDto.IsActive);
            paramaters.Add("@validDate", updateCouponDto.validDate);
            paramaters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

    }
}

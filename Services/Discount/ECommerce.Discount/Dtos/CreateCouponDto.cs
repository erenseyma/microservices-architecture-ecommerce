﻿namespace ECommerce.Discount.Dtos
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime validDate { get; set; }
    }
}

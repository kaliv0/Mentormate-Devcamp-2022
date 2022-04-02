using Mentormate.UnitTestsTask.Contracts;
using Mentormate.UnitTestsTask.Models;
using System;

namespace Mentormate.UnitTestsTask.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IDiscountRepository _discountRepository;

        public ProductService(IProductRepository productRepository,
            IPriceRepository priceRepository,
            IDiscountRepository discountRepository)
        {
            _productRepository = productRepository;
            _priceRepository = priceRepository;
            _discountRepository = discountRepository;
        }

        public ProductPrice GetProductPrice(long productId, long userId, DateTimeOffset orderDate)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new ArgumentException($"Cannot find product with id: {productId}.");
            }

            var basePrice = _priceRepository.GetBasePrice(productId);
            if (basePrice == null)
            {
                throw new ArgumentException($"Cannot find price for product with id: {productId}.");
            }

            decimal discount = 0;
            if (!basePrice.IsFinal && ApplyDiscount(orderDate))
            {
                discount = _discountRepository.GetDiscountAmount(productId, userId);
            }

            var result = new ProductPrice()
            {
                Id = product.Id,
                Name = product.Name,
                Price = Math.Max(basePrice.Ammount - discount, 0)
            };

            return result;
        }

        private bool ApplyDiscount(DateTimeOffset orderDate)
            => (orderDate.Hour < 11 && orderDate.Hour % 5 == 0)
                || orderDate.DayOfWeek == DayOfWeek.Monday;

    }
}

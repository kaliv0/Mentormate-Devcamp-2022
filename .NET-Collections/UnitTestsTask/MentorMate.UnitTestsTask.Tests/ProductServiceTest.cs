using System;
using Xunit;
using Moq;
using FluentAssertions;
using Mentormate.UnitTestsTask.Contracts;
using Mentormate.UnitTestsTask.Entities;
using Mentormate.UnitTestsTask.Models;
using Mentormate.UnitTestsTask.Services;

namespace MentorMate.UnitTestsTask.Tests
{
    public class ProductServiceTest
    {
        private Mock<IProductRepository> _productRepository;
        private Mock<IPriceRepository> _priceRepository;
        private Mock<IDiscountRepository> _discountRepository;
        private ProductService _productService;

        public ProductServiceTest()
        {
            _discountRepository = new Mock<IDiscountRepository>();
            _priceRepository = new Mock<IPriceRepository>();
            _productRepository = new Mock<IProductRepository>();

            _productService = new ProductService(
                _productRepository.Object, _priceRepository.Object, _discountRepository.Object);
        }

        [Fact]
        public void ProductService_GetProductPrice_ShouldThrowArgumentExceptionWhenProductIsNull()
        {
            //Arrange
            var productId = -1L;
            var userId = 1L;
            var date = DateTimeOffset.UtcNow;

            _productRepository
                .Setup(_ => _.GetById(productId))
                .Returns<Product>(null);

            //Act
            Action act = () => _productService.GetProductPrice(productId, userId, date);

            //Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Cannot find product with id: {productId}.");
        }

        [Fact]
        public void ProductService_GetProductPrice_ShouldThrowArgumentExceptionWhenBasePriceIsNull()
        {
            //Arrange
            var productId = 1L;
            var userId = 1L;
            var date = DateTimeOffset.UtcNow;

            _productRepository
                .Setup(_ => _.GetById(productId))
                .Returns(new Product());

            _priceRepository
                .Setup(_ => _.GetBasePrice(productId))
                .Returns<BasePrice>(null);

            //Act
            Action act = () => _productService.GetProductPrice(productId, userId, date);

            //Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Cannot find price for product with id: {productId}.");
        }

        [Theory]
        [InlineData(false, 17, 11)] //baseprice is not final
        [InlineData(true, 17, 11)]  //baseprice is final but hour is 11
        [InlineData(false, 17, 3)]  //baseprice is not final but hour is not a multiple of 5
        [InlineData(false, 17, 5)]  //the day of week is not Monday
        [InlineData(true, 17, 5)]   //the day of week is not Monday
        public void ProductService_GetProductPrice_ShouldReturnValidProductPrice(bool isFinal, int date, int hour)
        {
            //Arrange
            var productId = 1L;
            long userId = 1L;
            var dateTime = new DateTimeOffset(2022, 2, date, hour, 0, 0, new TimeSpan(0, 0, 0)); ;

            var productRepositoryResult = new Product()
            {
                Id = productId,
                Name = "Foo Bar"
            };

            var priceRepositoryResult = new BasePrice()
            {
                IsFinal = isFinal,
                Ammount = 10
            };

            _productRepository
                .Setup(_ => _.GetById(productId))
                .Returns(productRepositoryResult);

            _priceRepository
                .Setup(_ => _.GetBasePrice(productId))
                .Returns(priceRepositoryResult);

            var expectedProductPrice = new ProductPrice()
            {
                Id = productId,
                Name = "Foo Bar",
                Price = 10
            };

            //Act
            var result = _productService.GetProductPrice(productId, userId, dateTime);

            //Assert
            result.Should()
               .BeEquivalentTo(expectedProductPrice);
        }

        [Theory]
        [InlineData(false, 17, 10)]  //baseprice is not final, hour is smaller than 9 and a multiple of 5
        [InlineData(false, 14, 12)]  //the day of week is Monday
        [InlineData(false, 14, 9)]  //the day of week is Monday
        public void ProductService_GetProductPrice_ShouldReturnValidProductPriceWithDiscount(bool isFinal, int date, int hour)
        {
            //Arrange
            var productId = 1L;
            long userId = 1L;
            var dateTime = new DateTimeOffset(2022, 2, date, hour, 0, 0, new TimeSpan(0, 0, 0)); ;

            var productRepositoryResult = new Product()
            {
                Id = productId,
                Name = "Foo Bar"
            };

            var priceRepositoryResult = new BasePrice()
            {
                IsFinal = isFinal,
                Ammount = 10
            };

            _productRepository
                .Setup(_ => _.GetById(productId))
                .Returns(productRepositoryResult);

            _priceRepository
                .Setup(_ => _.GetBasePrice(productId))
                .Returns(priceRepositoryResult);

            _discountRepository
                .Setup(_ => _.GetDiscountAmount(productId, userId))
                .Returns(2);

            var expectedProductPrice = new ProductPrice()
            {
                Id = productId,
                Name = "Foo Bar",
                Price = 8
            };

            //Act
            var result = _productService.GetProductPrice(productId, userId, dateTime);

            //Assert
            result.Should()
               .BeEquivalentTo(expectedProductPrice);
        }
    }
}
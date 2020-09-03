using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Grishaev_90311.Controllers;
using WebLabsV05.DAL.Entities;
using Xunit;

namespace WebGrishaev.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            var controller = new ProductController();
            var data = TestData.GetDishesList();
            controller._dishes = data;

            var comparer = Comparer<Dish>
            .GetComparer((d1, d2) => d1.DishId.Equals(d2.DishId));

            // act
            var result = controller.Index(2) as ViewResult;
            var model = result.Model as List<Dish>;
            // assert
            Assert.Equal(2, model.Count); Assert.Equal(data[2], model[0], comparer);
        }
    }
}
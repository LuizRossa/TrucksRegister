using System;
using System.Collections.Generic;
using System.Text;
using TrucksRegister.Models;
using Xunit;

namespace Trucks_TestProject.Models
{
    public class TrucksModelsTeste
    {
        [Fact]
        public void Test_GetModelYear()
        {
            //act
            ModelYear modelYear = new ModelYear();

            // assert
            Assert.Equal(typeof(List<ModelYear>), modelYear.getAllModelYears().GetType());

        }

        [Fact]
        public void Test_GetTruckModel()
        {
            //act
            TruckModel truckModel = new TruckModel();

            // assert
            Assert.Equal(typeof(List<TruckModel>), truckModel.getAllTruckModels().GetType());

        }
    }
}

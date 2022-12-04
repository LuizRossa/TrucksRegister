using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TrucksRegister.Models;
using TrucksRegister.Repository;

namespace Trucks_TestProject.Repository
{
    public class TrucksRepositoryTeste
    {
        private readonly TrucksRepository _truckesRepository;
        private readonly Mock<TrucksContext> trucksContextMock = new Mock<TrucksContext>();

        public TrucksRepositoryTeste()
        {
            _truckesRepository = new TrucksRepository(trucksContextMock.Object);
        }


        [Fact]
        public void Test_GetAllTrucks()
        {
            // Act
            var result = _truckesRepository.GetAllTrucks();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_GetTrucksFirstOrDefault_Id_Null()
        {
            // act
            int? id = null;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckesRepository.GetTrucksFirtsOrDefault(id));
        }

        [Fact]
        public void Test_GetTrucksFirstOrDefault_Id_False()
        {
            // act
            int id = -1;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckesRepository.GetTrucksFirtsOrDefault(id));
        }

        [Fact]
        public void Test_FindById_Null()
        {
            // act
            int? id = null;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckesRepository.Find(id));
        }

        [Fact]
        public void Test_FindById_False()
        {
            // act
            int id = -1;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckesRepository.Find(id));
        }
    }
}

using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TrucksRegister.Interfaces;
using TrucksRegister.Services;
using TrucksRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace Trucks_TestProject.Services
{
    public class TrucksServiceTeste
    {
        private readonly TrucksService _truckService;
        private readonly Mock<ITrucksRepository> _truckRepositoryMock = new Mock<ITrucksRepository>();

        public TrucksServiceTeste()
        {
            _truckService = new TrucksService(_truckRepositoryMock.Object);
        }

        [Fact]
        public void Test_GetAllTrucks()
        {
            // Act
            var result = _truckService.GetAllTrucks();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_GetTrucksFirstOrDefault_Id_Null()
        {
            // act
            int? id = null;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckService.GetTrucksFirstOrDefault(id));
        }

        [Fact]
        public void Test_GetTrucksFirstOrDefault_Id_False()
        {
            // act
            int id = -1;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckService.GetTrucksFirstOrDefault(id));
        }

        [Fact]
        public void Test_FindById_Null()
        {
            // act
            int? id = null;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckService.FindById(id));
        }

        [Fact]
        public void Test_FindById_False()
        {
            // act
            int id = -1;
            // assert
            Assert.ThrowsAsync<Exception>(() => _truckService.FindById(id));
        }
    }
}

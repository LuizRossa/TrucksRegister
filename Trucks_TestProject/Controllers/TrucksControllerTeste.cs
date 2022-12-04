using System;
using System.Collections.Generic;
using System.Text;
using System;
using Xunit;
using System.Threading.Tasks;
using TrucksRegister.Models;
using NSubstitute;
using TrucksRegister.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TrucksRegister.Interfaces;
using Moq;
using TrucksRegister.Services;

namespace Trucks_TestProject.Controllers
{
    public class TrucksControllerTeste
    {
        private readonly TrucksController _controller;
        private readonly Mock<ITrucksService> _trucksServiceMock = new Mock<ITrucksService>();

        public TrucksControllerTeste() 
        {
            _controller = new TrucksController(_trucksServiceMock.Object);
        }

        [Fact]
        public async void Test_IndexGetAsync()
        {
            // Act
            string erro = null;
            var result = await _controller.Index(erro) as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Test_Details_Id_null()
        {
            // Act
            int? id = null;
            // Assert
            await Assert.ThrowsAsync<Exception>(() => _controller.Details(id));
        }

        [Fact]
        public async void Test_Details_Id_False()
        {
            // Act
            int id = -1;
            // Assert
            await Assert.ThrowsAsync<Exception>(() => _controller.Details(id));
        }

        [Fact]
        public void Test_CreateGet()
        {
            // Act
            string erro = null;
            var result = _controller.Create(erro) as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Test_Create_Post_Invalid_Model()
        {
            Trucks trucks= new Trucks();
            trucks.Id = 1;
            trucks.Model = "FG";
            trucks.ManufacturingYear = 2022;
            trucks.ModelYear = 2023;

            // Act
            var result = (RedirectToActionResult)await _controller.Create(trucks);
            // Assert
            Assert.Equal("Create", result.ActionName);
        }

        [Fact]
        public async void Test_Create_Post_Invalid_Model_Year()
        {
            Trucks trucks = new Trucks();
            trucks.Id = 1;
            trucks.Model = "FH";
            trucks.ManufacturingYear = 2022;
            trucks.ModelYear = 0;

            // Act
            var result = (RedirectToActionResult)await _controller.Create(trucks);
            // Assert
            Assert.Equal("Create", result.ActionName);
        }

        [Fact]
        public async void Test_EditGet_Id_False()
        {
            // act
            int? id = -1;

            // assert
            var result = (RedirectToActionResult)await _controller.Edit(id);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async void Test_EditGet_Id_Null()
        {
            // act
            int? id = 0;

            // assert
            var result = (RedirectToActionResult)await _controller.Edit(id);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async void Test_EditPost_Id_False()
        {
            // act
            int id = -1;

            Trucks trucks = new Trucks();
            trucks.Id = 1;
            trucks.Model = null;
            trucks.ManufacturingYear = 1111;
            trucks.ModelYear = 2222;

            // assert
            var result = (RedirectToActionResult)await _controller.Edit(id, trucks);
            Assert.Equal("Edit", result.ActionName);
        }

        [Fact]
        public async void Test_EditPost_ModelFalse()
        {
            // act
            int id = 2;

            Trucks trucks = new Trucks();
            trucks.Id = 0;
            trucks.Model = null;
            trucks.ManufacturingYear = 1111;
            trucks.ModelYear = DateTime.Now.Year;

            // assert
            var result = (RedirectToActionResult)await _controller.Edit(id, trucks);
            Assert.Equal("Edit", result.ActionName);
        }

        [Fact]
        public async void Test_EditPost_ModelYearFalse()
        {
            // act
            int id = 2;
            Trucks trucks = new Trucks();
            trucks.Id = 0;
            trucks.Model = "FH";
            trucks.ManufacturingYear = 0;
            trucks.ModelYear = 2222;

            // assert
            var result = (RedirectToActionResult)await _controller.Edit(id, trucks);
            Assert.Equal("Edit", result.ActionName);
        }

        [Fact]
        public async void Test_DeleteGet()
        {
            // act
            int? id = -1;

            // assert
            await Assert.ThrowsAsync<Exception>(() => _controller.Delete(id));
        }

        [Fact]
        public async void Test_DeleteGet_Id_Null()
        {
            // act
            int? id = null;

            // assert
            await Assert.ThrowsAsync<Exception>(() => _controller.Delete(id));
        }

        [Fact]
        public void Test_CaminhaoExists()
        {
            // act
            int id = -1;

            // assert
            Assert.False(_controller.TrucksExists(id));
        }
    }
}

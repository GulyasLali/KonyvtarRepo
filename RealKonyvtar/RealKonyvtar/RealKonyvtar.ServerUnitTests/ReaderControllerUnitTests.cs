using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RealKonyvtar.Server.Controllers;
using RealKonyvtar.Server.Data;
using RealKonyvtar.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealKonyvtar.ServerUnitTests
{
    public class ReaderControllerUnitTests
    {
        private readonly DataContext _datakontekszt;

        public ReaderControllerUnitTests()
        {
            _datakontekszt = A.Fake<DataContext>();
        }


        [Fact]
        public void ReaderController_GetAllOlv_ReturnOK()
        {
            //Arrange
            var konyvek = A.Fake<ICollection<Reader>>();
            var konyvList = A.Fake<List<Reader>>();
            var cont = new ReaderController(_datakontekszt);

            //Act
            var res = cont.GetAllOlv();
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(OkObjectResult));

        }

        [Fact]
        public void ReaderController_GetOlv_ReturnOK()
        {
            //Arrange
            int id = 1;
            var konyvek = A.Fake<ICollection<Reader>>();
            var konyvList = A.Fake<List<Reader>>();
            var cont = new ReaderController(_datakontekszt);

            //Act
            var res = cont.GetOlv(id);
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(OkObjectResult));

        }

        [Fact]
        public void ReaderController_DeleteOlv_ReturnOK()
        {
            //Arrange
            int id = 1;
            var konyvek = A.Fake<ICollection<Reader>>();
            var konyvList = A.Fake<List<Reader>>();
            var cont = new ReaderController(_datakontekszt);

            //Act
            var res = cont.DeleteOlv(id);
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(OkObjectResult));

        }
    }
}

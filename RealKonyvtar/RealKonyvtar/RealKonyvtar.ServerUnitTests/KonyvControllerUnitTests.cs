using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using RealKonyvtar.Server.Controllers;
using RealKonyvtar.Server.Data;
using RealKonyvtar.Shared;

namespace RealKonyvtar.ServerUnitTests
{
    public class KonyvControllerUnitTests
    {
        private readonly DataContext _datakontekszt;

        public KonyvControllerUnitTests()
        {
            _datakontekszt = A.Fake<DataContext>();
        }


        [Fact]
        public void KonyvController_GetAllKonyv_ReturnOK()
        {
            //Arrange
            var konyvek = A.Fake<ICollection<Konyv>>();
            var konyvList = A.Fake<List<Konyv>>();
            var cont = new KonyvController(_datakontekszt);

            //Act
            var res = cont.GetAllKonyv();
            //Assert
            
            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(OkObjectResult));
            
        }

        [Fact]
        public void KonyvController_GetKonyv_ReturnOK()
        {
            //Arrange
            int id = 1;
            var konyvek = A.Fake<ICollection<Konyv>>();
            var konyvList = A.Fake<List<Konyv>>();
            var cont = new KonyvController(_datakontekszt);

            //Act
            var res = cont.GetKonyv(id);
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(OkObjectResult));

        }

        [Fact]
        public void KonyvController_DeleteKonyv_ReturnOK()
        {
            //Arrange
            int id = 1;
            var konyvek = A.Fake<ICollection<Konyv>>();
            var konyvList = A.Fake<List<Konyv>>();
            var cont = new KonyvController(_datakontekszt);

            //Act
            var res = cont.DeleteKonyv(id);
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(OkObjectResult));

        }
    }
}
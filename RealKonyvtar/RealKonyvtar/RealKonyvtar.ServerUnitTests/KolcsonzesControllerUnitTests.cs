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
    public class KolcsonzesControllerUnitTests
    {
        private readonly DataContext _datakontekszt;

        public KolcsonzesControllerUnitTests()
        {
            _datakontekszt = A.Fake<DataContext>();
        }


        [Fact]
        public void ReaderController_GetAllKolcs_ReturnOK()
        {
            //Arrange
            var konyvek = A.Fake<ICollection<Kolcsonzes>>();
            var konyvList = A.Fake<List<Kolcsonzes>>();
            var cont = new KolcsonzesController(_datakontekszt);

            //Act
            var res = cont.GetAllKolcs();
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(List<Kolcsonzes>));

        }

        [Fact]
        public void ReaderController_GetKolcs_ReturnOK()
        {
            //Arrange
            int id = 1;
            var konyvek = A.Fake<ICollection<Kolcsonzes>>();
            var konyvList = A.Fake<List<Kolcsonzes>>();
            var cont = new KolcsonzesController(_datakontekszt);

            //Act
            var res = cont.GetKolcs(id);
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(List<OkObjectResult>));

        }


        [Fact]
        public void ReaderController_DeleteKolcs_ReturnOK()
        {
            //Arrange
            int id = 1;
            var konyvek = A.Fake<ICollection<Kolcsonzes>>();
            var konyvList = A.Fake<List<Kolcsonzes>>();
            var cont = new KolcsonzesController(_datakontekszt);

            //Act
            var res = cont.DeleteKolcs(id);
            //Assert

            res.Should().NotBeNull();
            res.Should().BeOfType(typeof(List<OkObjectResult>));

        }
    }
}

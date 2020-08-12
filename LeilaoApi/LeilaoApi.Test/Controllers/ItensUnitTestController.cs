using LeilaoApi.Models;
using LeilaoApi.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LeilaoApi.Test.Controllers
{
    public class ItensUnitTestController
    {
        // Get by ID
        [Fact]
        public void GetItensById_Return_OkResult()
        {
            // arrange
            ItensLeilao item = new ItensLeilao()
            {
                Id = 1
            };
            ItensLeilaoRepository repo = new ItensLeilaoRepository();

            // act
            var resultado = repo.GetItemLeilao(item.Id);

            //Assert
            Assert.Equal(resultado.Id, item.Id);
        }

    }
}

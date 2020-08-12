using LeilaoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeilaoApi.Repository
{
    public interface IItensLeilaoRepository
    {
        Task<List<ItensLeilao>> GetItensLeilao();

        Task<ItensLeilao> GetItemLeilao(int? leilaoId);

        Task<int> AddItemLeilao(ItensLeilao item);

        Task<int> DeleteItemLeilao(int? leilaoId);

        Task UpdateItemLeilao(ItensLeilao item);
    }
}

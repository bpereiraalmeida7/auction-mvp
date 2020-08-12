using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeilaoApi.Models;

namespace LeilaoApi.Repository
{
    public class ItensLeilaoRepository : IItensLeilaoRepository
    {
        LeilaoContext db;
        public ItensLeilaoRepository(LeilaoContext _db)
        {
            db = _db;
        }

        public ItensLeilaoRepository()
        {
        }

        public async Task<List<ItensLeilao>> GetItensLeilao()
        {
            if (db != null)
            {
                return await db.ItensLeilao.ToListAsync();
            }

            return null;
        }

        public async Task<ItensLeilao> GetItemLeilao(int? itemId)
        {
            if (db != null)
            {
                var itensLeilao = await db.ItensLeilao.FindAsync(itemId);

                return itensLeilao;
            }

            return null;
        }

        public async Task<int> AddItemLeilao(ItensLeilao item)
        {
            if (db != null)
            {
                await db.ItensLeilao.AddAsync(item);
                await db.SaveChangesAsync();

                return item.Id;
            }

            return 0;
        }

        public async Task<int> DeleteItemLeilao(int? itemId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var post = await db.ItensLeilao.FirstOrDefaultAsync(x => x.Id == itemId);

                if (post != null)
                {
                    //Delete that post
                    db.ItensLeilao.Remove(post);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateItemLeilao(ItensLeilao item)
        {
            if (db != null)
            {
                //Delete that post
                db.ItensLeilao.Update(item);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}

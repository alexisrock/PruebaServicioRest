
using DataAccess.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StoreProcedureRepository : IStoreProcedureRepository
    {

        private readonly PruebaServiceDBContext _Context;
        

        public StoreProcedureRepository(PruebaServiceDBContext Context)
        {
            _Context = Context;
           
        }
       
        public async Task<List<Producto>> GetAll()
        {
            var list = await _Context.SpSelectAllProducts.FromSqlRaw(" EXEC  SpSelectAllProducts ").ToListAsync();
            return list;
        }

        public async Task<Producto> GetByIdProduct(int id)
        {
            var list = await _Context.SpSelectIdProducts.FromSqlRaw(" EXEC  SpSelectIdProducts @Id ", new SqlParameter("@Id", id)).ToListAsync();
            var result = list.FirstOrDefault();
            return result;
        }

        public  async Task Insert(ProductoAdd obj)
        {
            await _Context.Database.ExecuteSqlRawAsync("EXEC SpInsertProducts @Name, @Description, @Price, @Stock   ", new SqlParameter("@Name", obj.Name), new SqlParameter("@Description", obj.Description), new SqlParameter("@Price", obj.Price), new SqlParameter("@Stock", obj.Stock));

        }

        public async Task Update(Producto obj)
        {
            await _Context.Database.ExecuteSqlRawAsync("EXEC SpUpdateProducts @Id,  @Name, @Description, @Price, @Stock   ", new SqlParameter("@Id", obj.Id), new SqlParameter("@Name", obj.Name), new SqlParameter("@Description", obj.Description), new SqlParameter("@Price", obj.Price), new SqlParameter("@Stock", obj.Stock));

        }

        public async Task Delete(int id)
        {
            await _Context.Database.ExecuteSqlRawAsync("EXEC SpDeleteProducts @Id  ", new SqlParameter("@Id",id));

        }

    }
}

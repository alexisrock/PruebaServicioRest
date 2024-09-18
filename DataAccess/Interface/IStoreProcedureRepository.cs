using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IStoreProcedureRepository
    {

        Task<List<Producto>> GetAll();
     
        Task Insert(ProductoAdd obj);
        Task Update(Producto obj);
        Task Delete(int id);        
        Task<Producto> GetByIdProduct(int id);
    
    }
}

using CarDealerAPI.Config; 
using CarDealerAPI.Models.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealerAPI.Services
{
    public class ModeloServices
    {
        private readonly ApplicationDbContext _db;

        public ModeloServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Modelo>> GetAll()
        {
            return await _db.Modelos.ToListAsync();
        }

    }
}

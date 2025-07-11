using CarDealerAPI.Config;
using CarDealerAPI.Models.Es0Km; 
using Microsoft.EntityFrameworkCore;

namespace CarDealerAPI.Services
{
    public class CondicionesService
    {
        private readonly ApplicationDbContext _db;

        public CondicionesService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Condicion>> GetAll()
        {
            return await _db.Condicion.ToListAsync();
        }
    }
}
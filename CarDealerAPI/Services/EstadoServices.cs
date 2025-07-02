using AutoMapper;
using CarDealerAPI.Config;
using CarDealerAPI.Models.Estado;
using CarDealerAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarDealerAPI.Services
{
    public class EstadoServices
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        public EstadoServices(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        private async Task<Estado> GetOneByIdOrException(int id)
        {
            var estado = await _db.Estados.Where(h => h.Id == id).FirstOrDefaultAsync();

            if (estado == null)
            {
                throw new HttpError($"No se encontro el Estado con ID = {id}", HttpStatusCode.NotFound);
            }

            return estado;
        }

        public async Task<List<Estado>> GetAll()
        {
            var estados = await _db.Estados.ToListAsync();
            return estados;
        }

        public async Task<Estado> GetOneById(int id)
        {
            return await GetOneByIdOrException(id);
        }

        public async Task<Estado> GetOneByName(string nombre)
        {
            var estado = await _db.Estados.FirstOrDefaultAsync(e => e.Nombre == nombre);
            if (estado == null)
            {
                throw new HttpError($"No se encontro el Estado con Nombre = {nombre}", HttpStatusCode.NotFound);
            }
            return estado;
        }
    }
}

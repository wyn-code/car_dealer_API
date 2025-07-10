using AutoMapper;
using CarDealerAPI.Config;
using CarDealerAPI.Models.Auto.Dto;
using CarDealerAPI.Models.Tipo_Auto;
using CarDealerAPI.Models.Tipo_Auto.Dto;
using CarDealerAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarDealerAPI.Services
{
    public class TipoAutoServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TipoAutoServices(IMapper mapper, ApplicationDbContext db, ApplicationDbContext context)
        {
            _db = db;
            _mapper = mapper;
        }

        private async Task<TipoDeAuto> GetOneByIdOrException(int id)
        {
            var tipo_auto = await _db.TiposDeAuto.Where(h => h.Id_Tipo_Auto == id).FirstOrDefaultAsync();

            if (tipo_auto == null)
            {
                throw new HttpError($"No se encontro el Tipo de Auto con ID = {id}", HttpStatusCode.NotFound);
            }

            return tipo_auto;
        }

        // Crear un nuevo tipo de auto
        public async Task<TipoDeAuto> CrearTipoAutoAsync(TipoDeAuto tipoAuto)
        {
            _db.Add(tipoAuto);
            await _db.SaveChangesAsync();
            return tipoAuto;
        }
        public async Task<List<TipoDeAuto>> GetAllByIds(List<int> tipoautoId)
        {
            if (tipoautoId == null || !tipoautoId.Any())
            {
                throw new HttpError("La lista de IDs de Autos no puede estar vacía.", HttpStatusCode.BadRequest);
            }
            var tipoAuto = await _db.TiposDeAuto.Where(i => tipoautoId.Contains(i.Id_Tipo_Auto)).ToListAsync();
            return tipoAuto;
        }


        // Obtener todos los tipos de autos
        public async Task<List<TipoDeAuto>> ObtenerTiposAutosAsync()
        {
            return await _db.TiposDeAuto.ToListAsync();
        }

        public async Task<List<TipoDeAuto>> GetAll()
        {
            var tipo_autos = await _db.TiposDeAuto.ToListAsync();
            return tipo_autos;
        }
        public async Task<TipoDeAuto> CreateOne(CreateTipoAutoDTO tipoAuto)
        {

            var tipo_Auto = _mapper.Map<TipoDeAuto>(tipoAuto);

            await _db.TiposDeAuto.AddAsync(tipo_Auto);
            await _db.SaveChangesAsync();
            return tipo_Auto;
        }
    }
}

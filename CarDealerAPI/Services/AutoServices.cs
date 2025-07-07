using AutoMapper;
using Car_DealerShip_Proyect.Config;
using Car_DealerShip_Proyect.Models.Auto;
using Car_DealerShip_Proyect.Models.Auto.Dto;
using Car_DealerShip_Proyect.Models.Tipo_Auto;
using Car_DealerShip_Proyect.Utils;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Car_DealerShip_Proyect.Services
{
    public class AutoServices
    {
       
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        private readonly TipoAutoServices _tipoAutos;
            
        public AutoServices(IMapper mapper, ApplicationDbContext db,TipoAutoServices tipoAutos)
        {
            _db = db;
            _mapper = mapper;
            _tipoAutos = tipoAutos;

        }

        private async Task<Auto> GetOneByIdOrException(int id)
        {
            var auto = await _db.Autos
                .Where(h => h.Id_Autos == id)
                .Include(h => h.Tipo_Autos)
                .FirstOrDefaultAsync();

            if (auto == null)
            {
                throw new HttpError($"No se encontro el auto con ID = {id}", HttpStatusCode.NotFound);
            }

            return auto;
        }

        public async Task<List<AllAutoDTO>> GetAll()
        {
            var autosDb = await _db.Autos.Include(a => a.Disponible).ToListAsync();
            var autos = _mapper.Map<List<AllAutoDTO>>(autosDb);
            return autos;
        }

        public async Task<Auto> GetOneById(int id)
        {
            return await GetOneByIdOrException(id);
        }

        /*
        public Auto CreateOne(CreateAutoDTO auto)
        {
            var a = _mapper.Map<Auto>(auto);

            _db.auto.Add(a);
            _db.SaveChanges();
            return a;
        }
        
        public async Task DeleteOneById(int id)
        {
            var auto = await GetOneByIdOrException(id);
            _db.Autos.Remove(auto);
            await _db.SaveChangesAsync();
            if (await _db.Autos.AnyAsync(hel => auto.Id_Autos == id))
            {
                throw new HttpError($"No se pudo eliminar el auto con ID = {id}", HttpStatusCode.InternalServerError);
            }
        }
        
        public async Task<Auto> UpdateAuto(int id, UpdateAutoDTO autoDTO)
        {
            var autoToUpdate = await GetOneByIdOrException(id);

            var autoUpdate = _mapper.Map(autoDTO, autoToUpdate);

            if(autoDTO.Id_Tipo_Auto != null && autoDTO.Id_Tipo_Auto.Any())
            {
                var tipoAuto = await _tipoAutos.GetAllByIds(autoDTO.Id_Tipo_Auto);
                autoUpdate.Tipo_Autos = tipoAuto;
            }

            _db.Autos.Update(autoUpdate);
            await _db.SaveChangesAsync();

            return autoToUpdate;

        }

        */

    }
}

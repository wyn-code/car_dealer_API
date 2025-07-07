using AutoMapper;
using CarDealerAPI.Config;
using CarDealerAPI.Models.Auto;
using CarDealerAPI.Models.Auto.Dto;
using CarDealerAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarDealerAPI.Services
{
    public class AutoServices
    {
       
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
<<<<<<< HEAD
=======

        private readonly EstadoServices _estadoServices;

>>>>>>> b7ad0cc187f051b13476628383e04692b4704dd3
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

<<<<<<< HEAD
        

        public Auto CreateOne(CreateAutoDTO auto)
=======
        public async Task<Auto> CreateOne(CreateAutoDTO auto)
>>>>>>> b7ad0cc187f051b13476628383e04692b4704dd3
        {

            var a = _mapper.Map<Auto>(auto);
            var estado = await _estadoServices.GetOneByName("Pendiente");
            a.Estado = estado;

            await _db.Autos.AddAsync(a);
            await _db.SaveChangesAsync();
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



    }
}

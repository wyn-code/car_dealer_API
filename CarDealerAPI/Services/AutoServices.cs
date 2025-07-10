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
        private readonly EstadoServices _estadoServices;
        private readonly TipoAutoServices _tipoAutos;

        
        public AutoServices(IMapper mapper, ApplicationDbContext db, TipoAutoServices tipoAutos, EstadoServices estadoServices)
        {
            _db = db;
            _mapper = mapper;
            _tipoAutos = tipoAutos;
            _estadoServices = estadoServices;
        }

        private async Task<Auto> GetOneByIdOrException(int id)
        {
            var auto = await _db.Autos
                .Where(h => h.Id_Autos == id)          
                .Include(h => h.Tipo_Auto)
                .FirstOrDefaultAsync();

            if (auto == null)
            {
                throw new HttpError($"No se encontro el auto con ID = {id}", HttpStatusCode.NotFound);
            }

            return auto;
        }


        public async Task<List<AllAutoDTO>> GetAll()
        {
            var autosDb = await _db.Autos
                .Include(a => a.Estado)
                .Include(a => a.Tipo_Auto)
                .ToListAsync();
            var autos = _mapper.Map<List<AllAutoDTO>>(autosDb);
            return autos;
        }

        public async Task<Auto> GetOneById(int id)
        {
            return await GetOneByIdOrException(id);
        }

        public async Task<Auto> CreateOne(CreateAutoDTO auto)
        {

            var a = _mapper.Map<Auto>(auto);
            var estado = await _estadoServices.GetOneByName("Disponible");
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
            if (await _db.Autos.AnyAsync(h => h.Id_Autos == id))
            {
                throw new HttpError($"No se pudo eliminar el auto con ID = {id}", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Auto> UpdateAuto(int id, UpdateAutoDTO autoDTO)
        {
            var autoToUpdate = await GetOneByIdOrException(id);

            var autoUpdate = _mapper.Map(autoDTO, autoToUpdate);

            if (autoDTO.Id_Tipo_Auto != null && autoDTO.Id_Tipo_Auto.Any())
            {
                var tipoAuto = await _tipoAutos.GetAllByIds(autoDTO.Id_Tipo_Auto);
                autoUpdate.Tipo_Auto = tipoAuto.FirstOrDefault(); // Selecciona el primer elemento de la lista
            }

            _db.Autos.Update(autoUpdate);
            await _db.SaveChangesAsync();

            return autoToUpdate;
        }
        //public async Task<Auto> UpdateAuto(int id, UpdateAutoDTO autoDto)
        //{
        //    var auto = await GetOneByIdOrException(id); // Obtiene el auto existente o lanza una excepción si no se encuentra
        //    auto.Marca = autoDto.Marca;
        //    auto.Precio = autoDto.Precio;
        //    auto.Disponible = autoDto.Disponible;
        //    auto.Motor = autoDto.Motor;
        //    auto.Año_Modelo = autoDto.Año_Modelo;

        //    if (autoDto.Id_Tipo_Auto != null)      
        //    {
        //        auto.Tipo_Auto = (await _tipoAutos.GetAllByIds(autoDto.Id_Tipo_Auto)).FirstOrDefault(); // Actualiza el tipo de auto
        //    }

        //    _db.Autos.Update(auto);
        //    await _db.SaveChangesAsync();
        //    return auto;
        //}
    }
}

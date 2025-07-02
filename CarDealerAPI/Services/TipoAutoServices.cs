using Car_DealerShip_Proyect.Config;
using Car_DealerShip_Proyect.Models.Tipo_Auto;
using Car_DealerShip_Proyect.Utils;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Car_DealerShip_Proyect.Services
{
    public class TipoAutoServices
    {
        private readonly ApplicationDbContext _context;

        public TipoAutoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear un nuevo tipo de auto
        public async Task<TipoDeAuto> CrearTipoAutoAsync(TipoDeAuto tipoAuto)
        {
            _context.Add(tipoAuto);
            await _context.SaveChangesAsync();
            return tipoAuto;
        }

        public async Task<List<TipoDeAuto>> GetAllByIds(List<int> tipoautoId)
        {
            if (tipoautoId == null || !tipoautoId.Any())
            {
                throw new HttpError("La lista de IDs de Autos no puede estar vacía.", HttpStatusCode.BadRequest);
            }
            var tipoAuto = await _context.TiposDeAuto.Where(i => tipoautoId.Contains(i.Id_Tipo_Auto)).ToListAsync();
            return tipoAuto;
        }


        // Obtener todos los tipos de autos
        public async Task<List<TipoDeAuto>> ObtenerTiposAutosAsync()
        {
            return await _context.TiposDeAuto.ToListAsync();
        }
    }
}

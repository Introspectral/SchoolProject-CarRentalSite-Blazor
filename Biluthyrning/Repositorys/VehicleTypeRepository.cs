using Biluthyrning.Data;
using Biluthyrning.Interface;

namespace Biluthyrning.Repositorys
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly RentalDbContext dbC;
        public VehicleTypeRepository(RentalDbContext dbC)
        {
            this.dbC = dbC;
        }
        public async Task<bool> CreateVehicleType(VehicleType vehicleType)
        {
            try
            {
                dbC.VehicleType.Add(vehicleType);
                await dbC.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task DeleteVehicleType(VehicleType vehicleType)
        {
            dbC.VehicleType.Remove(vehicleType);
            await dbC.SaveChangesAsync();
        }

        public List<VehicleType> GetAll()
        {
            List<VehicleType> vehicleType = dbC.VehicleType.OrderBy(x => x.VehicleTypeId).ToList();
            return vehicleType;
        }

        public VehicleType GetById(int vehicleTypeId)
        {
            VehicleType vehicleType = dbC.VehicleType.First(x => x.VehicleTypeId == vehicleTypeId);
            return vehicleType;
        }

        public async Task UpdateVehicleType(VehicleType vehicleType)
        {
            dbC.VehicleType.Update(vehicleType);
            await dbC.SaveChangesAsync();
        }
    }
}

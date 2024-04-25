using Biluthyrning.Data;
using Biluthyrning.Interface;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Biluthyrning.Repositorys
{
    public class VehicleRepository : IVehicleRepository
    {
		private readonly RentalDbContext dbC;

		public VehicleRepository(RentalDbContext dbC)
        {
			this.dbC = dbC;
		}
        public async Task CreateVehicle(Vehicle vehicle)
        {
			dbC.Vehicle.Add(vehicle);
			await dbC.SaveChangesAsync();
		}

        public Vehicle GetVehicleById(int vehicleId)
        {
			Vehicle vehicle = dbC.Vehicle.First(x => x.VehicleId == vehicleId);
            return vehicle;
		}

        public async Task UpdateVehicle(Vehicle vehicle)
        {
			dbC.Vehicle.Update(vehicle);
			await dbC.SaveChangesAsync();
		}

        public async Task DeleteVehicle(Vehicle vehicle)
        {
            dbC.Remove(vehicle);
            await dbC.SaveChangesAsync();
        }

        public List<Vehicle> GetAll()
        {
			List<Vehicle> vehicle = dbC.Vehicle.OrderBy(x => x.VehicleId).ToList();
			return vehicle;
		}
    }
}   


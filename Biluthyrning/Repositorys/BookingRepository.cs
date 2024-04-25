using Biluthyrning.Data;
using Biluthyrning.Interface;
using Microsoft.EntityFrameworkCore;


namespace Biluthyrning.Repositorys
{
	public class BookingRepository : IBookingRepository
	{
		private readonly RentalDbContext dbC;
		private readonly IDbContextFactory<RentalDbContext> dbContextFactory;

		public BookingRepository(RentalDbContext dbC, IDbContextFactory<RentalDbContext> dbContextFactory)
		{
			this.dbC = dbC;
			this.dbContextFactory = dbContextFactory;
		}

		public async Task CreateBooking(Booking bokning)
		{
			dbC.Booking.Add(bokning);
			await dbC.SaveChangesAsync();
		}

		public async Task<Booking> ReadBookingById(int BokningId)
		{
			Booking bokning = await dbC.Booking.FirstAsync(x => x.BookingId == BokningId);
			return bokning;
		}

		public async Task UpdateBooking(Booking bokning)
		{
			dbC.Booking.Update(bokning);
			dbC.SaveChangesAsync();
		}

		public async Task DeleteBooking(Booking bokning)
		{
			dbC.Booking.Remove(bokning);
			dbC.SaveChangesAsync();
		}

		public List<Booking> GetAllBookings()
		{
			using (RentalDbContext ctx = dbContextFactory.CreateDbContext())
			{
				List<Booking> bokning = ctx.Booking.OrderBy(x => x.BookingId).ToList();
				return bokning;
			}
		}
	}
}

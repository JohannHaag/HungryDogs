using System;
using System.Threading.Tasks;
using HungryDogs.Contracts.Modules.Common;
using HungryDogs.Logic.Entities.Persistence;

namespace HungryDogs.ConApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("HungryDogs");

			await CreateModelAsync();
		}

		static async Task CreateModelAsync()
		{
			using var restCtrl = Logic.Factory.CreateRestaurant();
			using var ohCtrl = Logic.Factory.CreateOpeningHour(restCtrl);
			using var sohCtrl = Logic.Factory.CreateSpecialOpeningHour();

			var model = await restCtrl.CreateAsync();
			model.Name = $"TestRestaurant";
			model.OwnerName = $"Herbert";
			model.UniqueName = $"HerbertUnique";
			model.Email = $"herbert@gmail.com";
			model.State = Contracts.Modules.Common.RestaurantState.Active;

			var rr = await restCtrl.InsertAsync(model);
			await restCtrl.SaveChangesAsync();

			var model2 = await restCtrl.CreateAsync();
			model2.Name = $"MaxRestaurant";
			model2.OwnerName = $"Max";
			model2.UniqueName = $"MaxUniqu";
			model2.Email = $"max@gmail.com";
			model2.State = Contracts.Modules.Common.RestaurantState.Active;

			var rr2 = await restCtrl.InsertAsync(model2);
			await restCtrl.SaveChangesAsync();

			var model3 = await restCtrl.CreateAsync();
			model3.Name = $"HansRestaurant";
			model3.OwnerName = $"Hans";
			model3.UniqueName = $"HansUni";
			model3.Email = $"hans@gmail.com";
			model3.State = Contracts.Modules.Common.RestaurantState.Active;

			var rr3 = await restCtrl.InsertAsync(model3);
			await restCtrl.SaveChangesAsync();

			var model4 = await restCtrl.CreateAsync();
			model4.Name = $"LeoRestaurant";
			model4.OwnerName = $"Leo";
			model4.UniqueName = $"LeoUn";
			model4.Email = $"leo@gmail.com";
			model4.State = Contracts.Modules.Common.RestaurantState.Active;

			var rr4 = await restCtrl.InsertAsync(model4);
			await restCtrl.SaveChangesAsync();

			var model5 = await restCtrl.CreateAsync();
			model5.Name = $"ChrisRestaurant";
			model5.OwnerName = $"Chris";
			model5.UniqueName = $"ChrisCU";
			model5.Email = $"chris@gmail.com";
			model5.State = Contracts.Modules.Common.RestaurantState.Closed;

			var rr5 = await restCtrl.InsertAsync(model5);
			await restCtrl.SaveChangesAsync();

			var oh = await ohCtrl.CreateAsync();

			oh.RestaurantId = rr.Id;
			oh.OpenFrom = new TimeSpan(10, 00, 00);
			oh.OpenTo = new TimeSpan(22, 00, 00);
			oh.Weekday = (int)DayOfWeek.Monday;
			oh.Notes = "Notes";

			await ohCtrl.InsertAsync(oh);
			await ohCtrl.SaveChangesAsync();

			var oh2 = await ohCtrl.CreateAsync();

			oh2.RestaurantId = rr2.Id;
			oh2.OpenFrom = new TimeSpan(10, 00, 00);
			oh2.OpenTo = new TimeSpan(22, 00, 00);
			oh2.Weekday = (int)DayOfWeek.Tuesday;
			oh2.Notes = "Notes";

			await ohCtrl.InsertAsync(oh2);
			await ohCtrl.SaveChangesAsync();

			var oh3 = await ohCtrl.CreateAsync();

			oh3.RestaurantId = rr3.Id;
			oh3.OpenFrom = new TimeSpan(10, 00, 00);
			oh3.OpenTo = new TimeSpan(22, 00, 00);
			oh3.Weekday = (int)DayOfWeek.Wednesday;
			oh3.Notes = "Notes";

			await ohCtrl.InsertAsync(oh3);
			await ohCtrl.SaveChangesAsync();

			var oh4 = await ohCtrl.CreateAsync();

			oh4.RestaurantId = rr4.Id;
			oh4.OpenFrom = new TimeSpan(10, 00, 00);
			oh4.OpenTo = new TimeSpan(22, 00, 00);
			oh4.Weekday = (int)DayOfWeek.Thursday;
			oh4.Notes = "Notes";

			await ohCtrl.InsertAsync(oh4);
			await ohCtrl.SaveChangesAsync();

			var oh5 = await ohCtrl.CreateAsync();

			oh5.RestaurantId = rr5.Id;
			oh5.OpenFrom = new TimeSpan(10, 00, 00);
			oh5.OpenTo = new TimeSpan(22, 00, 00);
			oh5.Weekday = (int)DayOfWeek.Friday;
			oh5.Notes = "Notes";

			await ohCtrl.InsertAsync(oh5);
			await ohCtrl.SaveChangesAsync();

			var soh = await sohCtrl.CreateAsync();

			soh.RestaurantId = rr.Id;
			soh.From = new DateTime(2020, 03, 08, 10, 00, 00);
			soh.To = new DateTime(2020, 03, 08, 12, 00, 00);
			soh.Notes = "Notes";
			soh.State = SpecialOpenState.Closed;

			await sohCtrl.InsertAsync(soh);
			await sohCtrl.SaveChangesAsync();

			var soh2 = await sohCtrl.CreateAsync();

			soh2.RestaurantId = rr2.Id;
			soh2.From = new DateTime(2020, 03, 08, 10, 00, 00);
			soh2.To = new DateTime(2020, 03, 08, 12, 00, 00);
			soh2.Notes = "Notes";
			soh2.State = SpecialOpenState.Open;

			await sohCtrl.InsertAsync(soh2);
			await sohCtrl.SaveChangesAsync();

			var soh3 = await sohCtrl.CreateAsync();

			soh3.RestaurantId = rr3.Id;
			soh3.From = new DateTime(2020, 03, 08, 10, 00, 00);
			soh3.To = new DateTime(2020, 03, 08, 12, 00, 00);
			soh3.Notes = "Notes";
			soh3.State = SpecialOpenState.IsBusy;

			await sohCtrl.InsertAsync(soh3);
			await sohCtrl.SaveChangesAsync();

			var soh4 = await sohCtrl.CreateAsync();

			soh4.RestaurantId = rr4.Id;
			soh4.From = new DateTime(2020, 03, 08, 10, 00, 00);
			soh4.To = new DateTime(2020, 03, 08, 12, 00, 00);
			soh4.Notes = "Notes";
			soh4.State = SpecialOpenState.ClosedPermanent;

			await sohCtrl.InsertAsync(soh4);
			await sohCtrl.SaveChangesAsync();

			var soh5 = await sohCtrl.CreateAsync();

			soh5.RestaurantId = rr5.Id;
			soh5.From = new DateTime(2020, 03, 08, 10, 00, 00);
			soh5.To = new DateTime(2020, 03, 08, 12, 00, 00);
			soh5.Notes = "Notes";
			soh5.State = SpecialOpenState.ClosedState;

			await sohCtrl.InsertAsync(soh5);
			await sohCtrl.SaveChangesAsync();

		}
	}
}

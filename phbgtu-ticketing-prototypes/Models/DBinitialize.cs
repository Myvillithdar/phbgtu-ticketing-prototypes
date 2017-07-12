using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace phbgtu_ticketing_prototypes.Models
{
	public static class DBinitialize
	{
		public static void EnsureCreated(IServiceProvider serviceProvider)
		{
			var context = new phbgtu_ticketing_prototypes_Context(
				serviceProvider.GetRequiredService<DbContextOptions<phbgtu_ticketing_prototypes_Context>>());
			context.Database.EnsureCreated();
		}
	}
}
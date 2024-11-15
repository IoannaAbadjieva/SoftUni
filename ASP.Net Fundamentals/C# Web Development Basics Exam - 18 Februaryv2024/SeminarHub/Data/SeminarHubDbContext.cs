﻿namespace SeminarHub.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using Configurations;
	using Models;

	public class SeminarHubDbContext : IdentityDbContext
	{
		public SeminarHubDbContext(DbContextOptions<SeminarHubDbContext> options)
			: base(options)
		{

		}

		public DbSet<Seminar> Seminars { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<SeminarParticipant> SeminarsParticipants { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CategoryConfiguration());
			builder.ApplyConfiguration(new SeminarParticipantConfiguration());

			base.OnModelCreating(builder);
		}
	}
}
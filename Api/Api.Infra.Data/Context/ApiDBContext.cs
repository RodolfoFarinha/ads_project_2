using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Api.Infra.Data.Context
{
    public class ApiDBContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassShift> ClassShifts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUnit> CourseUnits { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomProperty> RoomProperties { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Unit> Units { get; set; }

        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add all entity configs on EntityFramework Core
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDBContext).Assembly);

            // Limited all string properties with 250 max lenght 
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                    property.SetMaxLength(250);
            }

            // Filter all queries if entity is not deleted
            modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => !x.Deleted);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().BaseType.Name == "BaseEntity"))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateUser").CurrentValue = "PublicUser";
                    entry.Property("CreateDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    if (Convert.ToBoolean((entry.Property("Deleted").CurrentValue)))
                    {
                        entry.Property("CreateUser").IsModified = false;
                        entry.Property("CreateDate").IsModified = false;

                        entry.Property("ModifyUser").IsModified = false;
                        entry.Property("ModifyDate").IsModified = false;

                        entry.Property("DeleteUser").CurrentValue = "PublicUser";
                        entry.Property("DeleteDate").CurrentValue = DateTime.Now;
                    }
                    else
                    {
                        entry.Property("CreateUser").IsModified = false;
                        entry.Property("CreateDate").IsModified = false;

                        entry.Property("ModifyUser").CurrentValue = "PublicUser";
                        entry.Property("ModifyDate").CurrentValue = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}

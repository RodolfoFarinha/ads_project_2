using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Api.Infra.Data.Context
{
    /// <summary>
    /// Application database context
    /// </summary>
    public class ApiDBContext : DbContext
    {
        /// <summary>
        /// Building context
        /// </summary>
        public DbSet<Building> Buildings { get; set; }

        /// <summary>
        /// Class context
        /// </summary>
        public DbSet<Class> Classes { get; set; }

        /// <summary>
        /// Class shift context
        /// </summary>
        public DbSet<ClassShift> ClassShifts { get; set; }

        /// <summary>
        /// Configuration context
        /// </summary>
        public DbSet<Configuration> Configurations { get; set; }

        /// <summary>
        /// Course context
        /// </summary>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// Course unit context
        /// </summary>
        public DbSet<CourseUnit> CourseUnits { get; set; }

        /// <summary>
        /// Property context
        /// </summary>
        public DbSet<Property> Properties { get; set; }

        /// <summary>
        /// Room context
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// Room property context
        /// </summary>
        public DbSet<RoomProperty> RoomProperties { get; set; }

        /// <summary>
        /// Quality schedule context
        /// </summary>
        public DbSet<QualitySchedule> QualitySchedules { get; set; }

        /// <summary>
        /// Session context
        /// </summary>
        public DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// Shift context
        /// </summary>
        public DbSet<Shift> Shifts { get; set; }

        /// <summary>
        /// Slot context
        /// </summary>
        public DbSet<Slot> Slots { get; set; }

        /// <summary>
        /// Unit context
        /// </summary>
        public DbSet<Unit> Units { get; set; }

        /// <summary>
        /// Application database context constructor
        /// </summary>
        /// <param name="options"></param>
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) {}

        /// <summary>
        /// Method to creating model application database context
        /// </summary>
        /// <param name="modelBuilder"></param>
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

        /// <summary>
        /// Method to save application database context 
        /// </summary>
        /// <returns></returns>
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

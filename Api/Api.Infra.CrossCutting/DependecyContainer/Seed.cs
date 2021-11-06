using Api.Domain.Entities;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Api.Infra.CrossCutting.DependecyContainer
{
    /// <summary>
    /// Seed static data
    /// </summary>
    public static class Seed
    {
        /// <summary>
        /// Method to add static data in database
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IHost DbSeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApiDBContext>();
            context.Database.Migrate();

            SeedData(context).Wait();

            return host;
        }

        /// <summary>
        /// Method to create new entities to add database
        /// </summary>
        /// <param name="dataCtx"></param>
        /// <returns></returns>
        private static async Task SeedData(ApiDBContext dataCtx)
        {
           
            if (!await dataCtx.Configurations.AnyAsync())
            {
                dataCtx.Buildings.Add(new Building() { ScheduleKey = Guid.NewGuid(), ScheduleVersion = 1, BuildingKey = Guid.NewGuid(), BuildingName = "Test", CreateUser = "Unknow", CreateDate = DateTime.Now });


                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "BuildingName", Value = "Edifício" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "RoomName", Value = "Nome sala" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "NormalCapacity", Value = "Capacidade Normal" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "ExamCapacity", Value = "Capacidade Exame" });

                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "CourseName", Value = "Curso" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "UnitName", Value = "Unidade de execução" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "ShiftName", Value = "Turno" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "ClassName", Value = "Turma" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "StartDate", Value = "Início" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "EndDate", Value = "Fim" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "Day", Value = "Dia" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "PropertyName", Value = "Características da sala pedida" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, Key = "EnrolledStudents", Value = "Inscritos no turno" });

                await dataCtx.SaveChangesAsync();
            }
        }
    }
}

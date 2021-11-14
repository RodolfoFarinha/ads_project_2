using Api.Domain.Entities;
using Api.Domain.Enum;
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
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.PropertyName, Value = "Nome Características" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.PropertyDescription, Value = "Descrição" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.PropertyStatus, Value = "Activa" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.AvailableManagement, Value = "Disponível na Gestão de Aulas" }); 
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.AvailableRequest, Value = "Disponível no Pedido de Sala de Aula" });

                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.BuildingName, Value = "Edifício" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.RoomName, Value = "Nome sala" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.NormalCapacity, Value = "Capacidade Normal" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.ExamCapacity, Value = "Capacidade Exame" });

                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.CourseName, Value = "Curso" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.UnitName, Value = "Unidade de execução" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.ShiftName, Value = "Turno" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.ClassName, Value = "Turma" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.StartDate, Value = "Início" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.EndDate, Value = "Fim" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.Day, Value = "Dia" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.PropertySessionName, Value = "Características da sala pedida para a aula" });
                dataCtx.Configurations.Add(new Configuration() { ConfigurationKey = Guid.NewGuid(), CreateUser = "Unknow", CreateDate = DateTime.Now, ConfigurationType = ConfigurationEnum.EnrolledStudents, Value = "Inscritos no turno (no 1º semestre é baseado em estimativas)" });

                await dataCtx.SaveChangesAsync();
            }
        }
    }
}

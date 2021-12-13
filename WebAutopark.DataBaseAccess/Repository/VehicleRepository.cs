using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class VehicleRepository : RepositoryBase, IRepository<Vehicle>
    {
        private readonly string QueryCreate = "INSERT INTO Vehicles (VehicleTypeId, Model, RegistrationNumber, Weight, Year, Mileage, Color) " +
                                              "VALUES (@VehicleTypeId, @Model, @RegistrationNumber, @Weight, @Year, @Mileage, @Color)";

        private readonly string QueryDelete = "DELETE FROM Vehicles WHERE VehicleId = @id";

        private readonly string QueryGet = "SELECT * FROM Vehicles WHERE VehicleId = @id";

        private readonly string QueryGetAll = "SELECT * FROM Vehicles";

        private readonly string QueryUpdate = "UPDATE Vehicle SET " +
                                              "VehicleTypeId = @VehicleTypeId, " +
                                              "Model = @Model, " +
                                              "RegistrationNumber = @RegistrationNumber, " +
                                              "Weight = @Weight, " +
                                              "Year = @Year, " +
                                              "Mileage = @Mileage, " +
                                              "Color = @Color" +
                                              "WHERE VehicleId = @VehicleId";

        public VehicleRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(Vehicle item) => Connection.Execute(QueryCreate, item);
        public void Delete(int id) => Connection.Execute(QueryDelete, id);
        public IEnumerable<Vehicle> GetAllItems() => Connection.Query<Vehicle>(QueryGetAll).AsList();
        public Vehicle GetItem(int id) => Connection.QueryFirstOrDefault<Vehicle>(QueryGet, new { id });
        public void Update(Vehicle item) => Connection.Execute(QueryUpdate, item);
    }
}

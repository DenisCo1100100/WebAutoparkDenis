using Dapper;
using System.Collections.Generic;
using System.Linq;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class VehicleRepository : RepositoryBase, IRepository<Vehicle>
    {
        private readonly string QueryCreate = "INSERT INTO Vehicles (VehicleTypeId, Model, RegistrationNumber, Weight, Year, Mileage, FuelConsumption, TankCapacity, Color) " +
                                              "VALUES (@VehicleTypeId, @Model, @RegistrationNumber, @Weight, @Year, @Mileage, @FuelConsumption, @TankCapacity, @Color)";

        private readonly string QueryDelete = "DELETE FROM Vehicles WHERE VehicleId = @id";

        private readonly string QueryGet = "SELECT V.*, VT.VehicleTypeId AS VTId, VT.Name, VT.TaxCoefficient " +
                                           "FROM Vehicles AS V " +
                                           "INNER JOIN VehicleTypes AS VT ON V.VehicleTypeId = VT.VehicleTypeId " +
                                           "WHERE V.VehicleId = @id";

        private readonly string QueryGetAll = "SELECT V.*, VT.VehicleTypeId AS VTId, VT.Name, VT.TaxCoefficient " +
                                              "FROM Vehicles AS V " +
                                              "INNER JOIN VehicleTypes AS VT ON V.VehicleTypeId = VT.VehicleTypeId";

        private readonly string QueryUpdate = "UPDATE Vehicles SET " +
                                              "VehicleTypeId = @VehicleTypeId, " +
                                              "Model = @Model, " +
                                              "RegistrationNumber = @RegistrationNumber, " +
                                              "Weight = @Weight, " +
                                              "Year = @Year, " +
                                              "Mileage = @Mileage, " +
                                              "FuelConsumption = @FuelConsumption, " +
                                              "TankCapacity = @TankCapacity, " +
                                              "Color = @Color " +
                                              "WHERE VehicleId = @VehicleId";

        public VehicleRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(Vehicle item) => Connection.Execute(QueryCreate, item);
        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });
        public IEnumerable<Vehicle> GetAllItems() => 
            Connection.Query<Vehicle, VehicleType, Vehicle>
            (
                QueryGetAll, (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    return vehicle;
                },
                splitOn: "VTId"
            );

        public Vehicle GetItem(int id)
        {
            var collection = Connection.Query<Vehicle, VehicleType, Vehicle>(QueryGet,
                (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    return vehicle;
                },
                splitOn: "VTId",
                param: new { id }
            );

            return collection.First();
        }

        public void Update(Vehicle item) => Connection.Execute(QueryUpdate, item);
    }
}

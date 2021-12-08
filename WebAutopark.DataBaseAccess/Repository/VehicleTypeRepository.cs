using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class VehicleTypeRepository : ConnectionRepository, IRepository<VehicleType>
    {
        private readonly string QueryCreate = "INSERT INTO VehicleTypes (Name) VALUES (@Name)";

        private readonly string QueryDelete = "DELETE FROM VehicleTypes WHERE VehicleTypeId = @id";

        private readonly string QueryGet = "SELECT * FROM VehicleTypes WHERE VehicleTypeId = @id";

        private readonly string QueryGetAll = "SELECT * FROM VehicleTypes";

        private readonly string QueryUpdate = "UPDATE VehicleTypes SET Name = @Name WHERE VehicleTypeId = @VehicleTypeId";

        public VehicleTypeRepository(string connectionString) : base(connectionString) {}

        public void Create(VehicleType item) => DataBaseConnection.Execute(QueryCreate, item);
        public void Delete(int id) => DataBaseConnection.Execute(QueryDelete, id);
        public IEnumerable<VehicleType> GetAllItems() => DataBaseConnection.Query<VehicleType>(QueryGetAll).AsList();
        public VehicleType GetItem(int id) => DataBaseConnection.QueryFirstOrDefault<VehicleType>(QueryGet, new { id });
        public void Update(VehicleType item) => DataBaseConnection.Execute(QueryUpdate, item);
    }
}

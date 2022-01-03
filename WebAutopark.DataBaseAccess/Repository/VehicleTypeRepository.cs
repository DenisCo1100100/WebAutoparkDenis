using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class VehicleTypeRepository : RepositoryBase, IRepository<VehicleType>
    {
        private readonly string QueryCreate = "INSERT INTO VehicleTypes (Name) VALUES (@Name)";

        private readonly string QueryDelete = "DELETE FROM VehicleTypes WHERE VehicleTypeId = @id";

        private readonly string QueryGet = "SELECT * FROM VehicleTypes WHERE VehicleTypeId = @id";

        private readonly string QueryGetAll = "SELECT * FROM VehicleTypes";

        private readonly string QueryUpdate = "UPDATE VehicleTypes SET Name = @Name WHERE VehicleTypeId = @VehicleTypeId";

        public VehicleTypeRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(VehicleType item) => Connection.Execute(QueryCreate, item);
        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });
        public IEnumerable<VehicleType> GetAllItems() => Connection.Query<VehicleType>(QueryGetAll).AsList();
        public VehicleType GetItem(int id) => Connection.QueryFirstOrDefault<VehicleType>(QueryGet, new { id });
        public void Update(VehicleType item) => Connection.Execute(QueryUpdate, item);
    }
}

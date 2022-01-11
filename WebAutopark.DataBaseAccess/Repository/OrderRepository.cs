using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        private readonly string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES (@VehicleId)";

        private readonly string QueryCreateOrder = "INSERT INTO Orders(VehicleId) OUTPUT Inserted.OrderId, Inserted.VehicleId VALUES(@VehicleId) ";

        private readonly string QueryDelete = "DELETE FROM Orders WHERE OrderId = @id";

        private readonly string QueryGet = "SELECT * FROM Orders WHERE OrderId = @id";

        private readonly string QueryGetAll = "SELECT * FROM Orders";

        private readonly string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrderId = @OrderId";

        public OrderRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(Order item) => Connection.Execute(QueryCreate, item);

        public Order Create(int vehicleId)
        {
            var order = new
            {
                VehicleId = vehicleId
            };

            return Connection.QueryFirstOrDefault<Order>(QueryCreateOrder, order);
        }

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });
        public IEnumerable<Order> GetAllItems() => Connection.Query<Order>(QueryGetAll);
        public Order GetItem(int id) => Connection.QueryFirstOrDefault<Order>(QueryGet, new { id });
        public void Update(Order item) => Connection.Execute(QueryUpdate, item);
    }
}
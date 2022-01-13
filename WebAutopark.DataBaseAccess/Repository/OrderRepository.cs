using Dapper;
using System;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        private const string QueryCreate = "INSERT INTO Orders (VehicleId, Date) VALUES (@VehicleId, @Date)";

        private const string QueryCreateOrder = "INSERT INTO Orders(VehicleId, Date) OUTPUT Inserted.OrderId, Inserted.VehicleId, Inserted.Date VALUES(@VehicleId, @Date) ";

        private const string QueryDelete = "DELETE FROM Orders WHERE OrderId = @id";

        private const string QueryGet = "SELECT * FROM Orders WHERE OrderId = @id";

        private const string QueryGetAll = "SELECT * FROM Orders";

        private const string QueryUpdate = "UPDATE Orders SET VehicleId, Date = @VehicleId, @Date WHERE OrderId = @OrderId";

        public OrderRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(Order item) => Connection.Execute(QueryCreate, item);

        public Order Create(int vehicleId)
        {
            var order = new
            {
                VehicleId = vehicleId,
                Date = DateTime.UtcNow
            };

            return Connection.QueryFirstOrDefault<Order>(QueryCreateOrder, order);
        }

        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });
        public IEnumerable<Order> GetAllItems() => Connection.Query<Order>(QueryGetAll);
        public Order GetItem(int id) => Connection.QueryFirstOrDefault<Order>(QueryGet, new { id });
        public void Update(Order item) => Connection.Execute(QueryUpdate, item);
    }
}
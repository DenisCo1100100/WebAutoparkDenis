using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class OrderRepository : ConnectionRepository, IRepository<Order>
    {
        private readonly string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES (@VehicleId)";

        private readonly string QueryDelete = "DELETE FROM Orders WHERE OrdersId = @id";

        private readonly string QueryGet = "SELECT * FROM Orders WHERE OrdersId = @id";

        private readonly string QueryGetAll = "SELECT * FROM Orders";

        private readonly string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrdersId = @OrdersId";

        public OrderRepository(string connectionString) : base(connectionString) {}

        public void Create(Order item) => DataBaseConnection.Execute(QueryCreate, item);
        public void Delete(int id) => DataBaseConnection.Execute(QueryDelete, id);
        public IEnumerable<Order> GetAllItems() => DataBaseConnection.Query<Order>(QueryGetAll).AsList();
        public Order GetItem(int id) => DataBaseConnection.QueryFirstOrDefault<Order>(QueryGet, new { id });
        public void Update(Order item) => DataBaseConnection.Execute(QueryUpdate, item);
    }
}
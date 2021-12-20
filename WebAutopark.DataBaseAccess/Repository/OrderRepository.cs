using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class OrderRepository : RepositoryBase, IRepository<Order>
    {
        private readonly string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES (@VehicleId)";

        private readonly string QueryDelete = "DELETE FROM Orders WHERE OrdersId = @id";

        private readonly string QueryGet = "SELECT * FROM Orders WHERE OrdersId = @id";

        private readonly string QueryGetAll = "SELECT * FROM Orders";

        private readonly string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrdersId = @OrdersId";

        public OrderRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(Order item) => Connection.Execute(QueryCreate, item);
        public void Delete(int id) => Connection.Execute(QueryDelete, id);
        public IEnumerable<Order> GetAllItems() => Connection.Query<Order>(QueryGetAll).AsList();
        public Order GetItem(int id) => Connection.QueryFirstOrDefault<Order>(QueryGet, new { id });
        public void Update(Order item) => Connection.Execute(QueryUpdate, item);
    }
}
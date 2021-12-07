using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.DataBaseAccess.Repository
{
    class OrderRepository : BaseRepository, IRepository<Order>
    {
        private readonly string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES (@VehicleId)";

        private readonly string QueryDelete = "DELETE FROM Orders WHERE OrdersId = @id";

        private readonly string QueryGet = "SELECT * FROM Orders WHERE OrdersId = @id";

        private readonly string QueryGetAll = "SELECT * FROM Orders";

        private readonly string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrdersId = @OrdersId";

        public OrderRepository(string connectionString) : base(connectionString) {}

        public void Create(Order item) => DataBase.Execute(QueryCreate, item);
        public void Delete(int id) => DataBase.Execute(QueryDelete, id);
        public IEnumerable<Order> GetAllItems() => DataBase.Query<Order>(QueryGetAll).AsList();
        public Order GetItem(int id) => DataBase.QueryFirstOrDefault<Order>(QueryGet, new { id });
        public void Update(Order item) => DataBase.Execute(QueryUpdate, item);
    }
}
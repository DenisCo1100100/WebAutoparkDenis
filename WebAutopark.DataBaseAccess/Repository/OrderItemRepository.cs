using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.DataBaseAccess.Repository
{
    class OrderItemRepository : BaseRepository, IRepository<OrderItem>
    {
        private readonly string QueryCreate = "INSERT INTO OrderItems (OrderId, ComponentId, Quantity) " +
                                              "VALUES (@OrderId, @ComponentId, @Quantity)";

        private readonly string QueryDelete = "DELETE FROM OrderItems WHERE OrderItemId = @id";

        private readonly string QueryGet = "SELECT * FROM OrderItems WHERE OrderItemId = @id";

        private readonly string QueryGetAll = "SELECT * FROM OrderItems";

        private readonly string QueryUpdate = "UPDATE OrderItems SET " +
                                              "OrderId = @OrderId, " +
                                              "ComponentId = @ComponentId, " +
                                              "Quantity = @Quantity " +
                                              "WHERE OrderItemId = @OrderItemId";

        public OrderItemRepository(string connectionString) : base(connectionString) {}

        public void Create(OrderItem item) => DataBase.Execute(QueryCreate, item);
        public void Delete(int id) => DataBase.Execute(QueryDelete, id);
        public IEnumerable<OrderItem> GetAllItems() => DataBase.Query<OrderItem>(QueryGetAll).AsList();
        public OrderItem GetItem(int id) => DataBase.QueryFirstOrDefault<OrderItem>(QueryGet, new { id });
        public void Update(OrderItem item) => DataBase.Execute(QueryUpdate, item);
    }
}
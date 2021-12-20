using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class OrderItemRepository : RepositoryBase, IRepository<OrderItem>
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

        public OrderItemRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(OrderItem item) => Connection.Execute(QueryCreate, item);
        public void Delete(int id) => Connection.Execute(QueryDelete, id);
        public IEnumerable<OrderItem> GetAllItems() => Connection.Query<OrderItem>(QueryGetAll).AsList();
        public OrderItem GetItem(int id) => Connection.QueryFirstOrDefault<OrderItem>(QueryGet, new { id });
        public void Update(OrderItem item) => Connection.Execute(QueryUpdate, item);
    }
}
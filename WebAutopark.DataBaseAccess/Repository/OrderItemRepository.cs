using Dapper;
using System.Collections.Generic;
using System.Linq;
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

        private readonly string QueryGetAll = "SELECT OrderItems.*, Components.* " +
                                              "FROM OrderItems INNER JOIN Components " +
                                              "ON OrderItems.ComponentId = Components.ComponentId " +
                                              "ORDER BY OrderItemId";

        private readonly string QueryUpdate = "UPDATE OrderItems SET " +
                                              "OrderId = @OrderId, " +
                                              "ComponentId = @ComponentId, " +
                                              "Quantity = @Quantity " +
                                              "WHERE OrderItemId = @OrderItemId";

        public OrderItemRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public void Create(OrderItem item) => Connection.Execute(QueryCreate, item);
        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });
        public IEnumerable<OrderItem> GetAllItems() => 
            Connection.Query<OrderItem, Component, OrderItem>
            (
                QueryGetAll, (orderItem, component) => 
                {
                    orderItem.Component = component;
                    return orderItem;
                },
                splitOn: "ComponentId"
            );

        public OrderItem GetItem(int id)
        {
            var collection = Connection.Query<OrderItem, Component, OrderItem>
            (
                QueryGet, (orderItem, component) =>
                {
                    orderItem.Component = component;
                    return orderItem;
                },
                splitOn: "ComponentId",
                param: new { id }
            );

            return collection.First();
        }
        public void Update(OrderItem item) => Connection.Execute(QueryUpdate, item);
    }
}
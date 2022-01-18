using Dapper;
using System.Collections.Generic;
using System.Linq;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class OrderItemRepository : RepositoryBase, IOrderItemRepository
    {
        private const string QueryCreate = "INSERT INTO OrderItems (OrderId, ComponentId, Quantity) " +
                                              "VALUES (@OrderId, @ComponentId, @Quantity)";

        private const string QueryDelete = "DELETE FROM OrderItems WHERE OrderItemId = @id";

        private const string QueryGet = "SELECT * FROM OrderItems WHERE OrderItemId = @id";

        private const string QueryGetAll = "SELECT OrderItems.*, Components.* " +
                                              "FROM OrderItems INNER JOIN Components " +
                                              "ON OrderItems.ComponentId = Components.ComponentId " +
                                              "ORDER BY OrderItemId";

        private const string QueryGetAllItems = "SELECT OrderItems.*, Components.* " +
                                              "FROM OrderItems INNER JOIN Components " +
                                              "ON OrderItems.ComponentId = Components.ComponentId " +
                                              "WHERE OrderId = @orderId " +
                                              "ORDER BY OrderItemId";

        private const string QueryUpdate = "UPDATE OrderItems SET " +
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

        public IEnumerable<OrderItem> GetAllItems(int orderId) =>
            Connection.Query<OrderItem, Component, OrderItem>
            (
                QueryGetAllItems, (orderItem, component) =>
                {
                    orderItem.Component = component;
                    return orderItem;
                },
                splitOn: "ComponentId",
                param: new { orderId }
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
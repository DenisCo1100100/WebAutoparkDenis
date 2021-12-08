using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class ComponentRepository : ConnectionRepository, IRepository<Component>
    {
        private readonly string QueryCreate = "INSERT INTO Components (Name) VALUES (@Name)";

        private readonly string QueryDelete = "DELETE FROM Components WHERE ComponentId = @id";

        private readonly string QueryGet = "SELECT * FROM Components WHERE ComponentId = @id";

        private readonly string QueryGetAll = "SELECT * FROM Components";

        private readonly string QueryUpdate = "UPDATE Components SET Name = @Name WHERE ComponentId = @ComponentId";

        public ComponentRepository(string connectionString) : base(connectionString) {}

        public void Create(Component item) => DataBaseConnection.Execute(QueryCreate, item);
        public void Delete(int id) => DataBaseConnection.Execute(QueryDelete, id);
        public IEnumerable<Component> GetAllItems() => DataBaseConnection.Query<Component>(QueryGetAll).AsList();
        public Component GetItem(int id) => DataBaseConnection.QueryFirstOrDefault<Component>(QueryGet, new { id });
        public void Update(Component item) => DataBaseConnection.Execute(QueryUpdate, item);
    }
}
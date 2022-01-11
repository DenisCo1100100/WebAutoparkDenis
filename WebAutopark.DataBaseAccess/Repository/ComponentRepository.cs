using Dapper;
using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository
{
    public class ComponentRepository : RepositoryBase, IRepository<Component>
    {
        private readonly string QueryCreate = "INSERT INTO Components (Name) VALUES (@Name)";

        private readonly string QueryDelete = "DELETE FROM Components WHERE ComponentId = @id";

        private readonly string QueryGet = "SELECT * FROM Components WHERE ComponentId = @id";

        private readonly string QueryGetAll = "SELECT * FROM Components";

        private readonly string QueryUpdate = "UPDATE Components SET Name = @Name WHERE ComponentId = @ComponentId";

        public ComponentRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) {}

        public void Create(Component item) => Connection.Execute(QueryCreate, item);
        public void Delete(int id) => Connection.Execute(QueryDelete, new { id });
        public IEnumerable<Component> GetAllItems() => Connection.Query<Component>(QueryGetAll).AsList();
        public Component GetItem(int id) => Connection.QueryFirstOrDefault<Component>(QueryGet, new { id });
        public void Update(Component item) => Connection.Execute(QueryUpdate, item);
    }
}
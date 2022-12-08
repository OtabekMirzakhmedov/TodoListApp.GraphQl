using TodoListApp.GraphQl.Data;
using TodoListApp.GraphQl.Models;
using HotChocolate;

namespace TodoListApp.GraphQl.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList([ScopedService] ApiDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetItems([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }
    }
}

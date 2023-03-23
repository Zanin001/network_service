using System.Linq.Expressions;

namespace NetworkService.Data
{
    public class QueryService
    {
        private readonly NetworkServiceDbContext _context;

        public QueryService(NetworkServiceDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateItem<TData>(TData item) where TData : class
        {
            int result = default;

            try
            {
                await _context.AddAsync(item);
                result = await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }
        public async Task<TData> ReadItem<TData>(Expression<Func<TData, bool>> where = null) where TData : class
        {
            TData result = default;
            try
            {
                var dbSet = _context.Set<TData>();

                if (where != null)
                    result = dbSet.FirstOrDefault(where);
                if (where == null)
                    result = dbSet.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }
        public async Task<TData[]> ReadList<TData>(Expression<Func<TData, bool>> where) where TData : class
        {
            var dbSet =_context.Set<TData>();

            return dbSet.Where(where).ToArray();
        }
        public async Task<int> UpdateItem<TData>(TData item) where TData : class
        {
            int result = default;

            try
            {
                _context.Update(item);
                result = await _context.SaveChangesAsync();
            }
            catch(Exception ex) { Console.WriteLine(); }

            return result;
        }
        public async Task<int> DeleteItem<TData>(TData item) where TData : class
        {
            int result = default;

            try
            {
                _context.Remove(item);
                result = await _context.SaveChangesAsync();
            }
            catch(Exception ex) { Console.WriteLine(); }

            return result;
        }


    }
}

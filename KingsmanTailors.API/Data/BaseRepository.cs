namespace KingsmanTailors.API.Data
{
    public class BaseRepository
    {
        private DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        internal DataContext DbContext => _context;
    }

    public class BaseRepository<T>
    {
        private DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        internal DataContext DbContext => _context;

        //public T Data { get; set; }
    }
}

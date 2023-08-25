namespace ProductsWithMongo.DAL.DBContexts
{
    public class ApplicationDBContext
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string ProductCollectionName { get; set; }
    }
}

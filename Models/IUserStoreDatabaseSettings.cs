namespace UserManagement.Models
{
    public interface IUserStoreDatabaseSettings
    {
        public string UserProfileCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

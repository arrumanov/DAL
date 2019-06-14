namespace Garden.Core.DAL.Repository
{
    public interface IBaseRepository
    {
        void SetStorageContext(IStorageContext storageContext);
    }
}

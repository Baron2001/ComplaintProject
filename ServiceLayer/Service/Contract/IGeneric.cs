namespace ServiceLayer.Service.Contract
{
    public interface IGeneric<T>
    {
        Task<List<T>> GetAllAsync(long? userId = 0, long? adminId = 0);
        Task<T> GetByIdAsync(long id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> UpdateStatusAsync(long complaintId, int newStatusId, long adminId);
        Task<T> DeleteAsync(long id);
    }
}

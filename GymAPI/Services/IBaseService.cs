namespace GymAPI.Services;

public interface IBaseService<T> {
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task<T> Delete(int id);
}
namespace Service.Base
{
    public interface IBaseService<T, D> where T : class 
                                        where D : class
    {
        Task Insert(D dto);
        Task Update(D dto);
        Task Delete(int id);
        Task<IEnumerable<D>> GetAll();
        Task<D> GetById(int id);

    }
}

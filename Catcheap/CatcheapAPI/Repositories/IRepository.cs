using Microsoft.AspNetCore.Mvc;

namespace CatcheapAPI.Repositories;

public interface IRepository<T1, T2> where T1 : class
{
    Task<ActionResult<IEnumerable<T1>>> GetAll();
    Task<ActionResult<T1>> GetById(T2 id);
    Task<IActionResult> Put(T2 id, T1 entity);
    Task<ActionResult<T1>> Post(T1 entity);
    Task<IActionResult> Delete(T2 id);
    bool Exists(T2 id);
}

namespace Catcheap.Models.FileIO_Classes.Interfaces
{
    public interface ILoader<in T>
    {

        public void Load(T t, string fileName);

    }
}

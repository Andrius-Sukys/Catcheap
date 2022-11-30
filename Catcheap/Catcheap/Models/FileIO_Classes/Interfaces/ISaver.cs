namespace Catcheap.Models.FileIO_Classes.Interfaces
{
    public interface ISaver<in T>
    {

        public void Save(T t, string fileName);

    }
}

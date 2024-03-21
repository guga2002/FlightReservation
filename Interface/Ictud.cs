namespace Webia.Interface
{
    public interface Ictud<T>where T:class
    {
        void Add(T entity);

        void Update(T entity);
    }
}

namespace Beata.Medrek
{
    public interface IApplicationCache<T>
        where T:class
    {

        /// <summary>
        /// Object in Cache
        /// </summary>
        T Object { get; set; }

        /// <summary>
        /// Return The Cached Object
        /// </summary>
        /// <returns></returns>
        T GetObject();

        /// <summary>
        /// Set The Value Of the cache Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        void SetObject(T obj);

        /// <summary>
        /// Clear The Cache
        /// </summary>
        void ClearCache();

    }
}

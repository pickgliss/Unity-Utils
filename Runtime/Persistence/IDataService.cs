using System.Collections.Generic;

namespace Persistence {
    public interface IDataService<T> where T : IData{
        void Save(T data, bool overwrite = true);
        T Load(string name);
        void Delete(string name);
        void DeleteAll();
        IEnumerable<string> ListSaves();
    }

    public interface IData
    {
        string Name { get; }
    }
}
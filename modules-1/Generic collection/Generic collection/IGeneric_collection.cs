using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_collection
{
    internal interface IGeneric_collection<T> : IEnumerable<T>
    {
        void Add(T arrayValue);

        bool Remove(T value);

        bool RemoveAt(int index);

        void AddRange(T[] array);

        bool Contain(T item);

        int IndexOf(T item);

        int LastIndexOf(T item);

        T[] Sort();

        new IEnumerator<T> GetEnumerator();
    }
}

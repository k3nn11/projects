using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generic_collection
{
    public class NewList<T> :IGeneric_collection<T>
    {
        private T[] _array;

        public NewList(int length)
        {
            _array = new T[length];
            Count = 0;
        }

        public NewList()
        {
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public T this[int index]
        {
            set { _array[index] = value; }
            get { return _array[index]; }
        }

        public void Add(T arrayValue)
        {
            if (Count >= Capacity)
            {
                Array.Resize(ref _array, Capacity * 2);
            }

            _array[Count] = arrayValue;
            IncrementArraySize();
        }

        public void AddRange(T[] array)
        {
            int requiredLength = Count + array.Length;
            if (requiredLength >= Capacity)
            {
                Array.Resize(ref _array, requiredLength + 1);
            }

            for (int i = 0; i < array.Length; i++)
            {
                _array[Count] = array[i];
                IncrementArraySize();
            }
        }

        public bool Contain(T item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i] != null && _array[i].Equals(item))
                {
                    index = i;
                    break;
                }

                if (i == _array.Length - 1)
                {
                    throw new Exception("The name is not available in the list");
                }
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            int index = default(int);
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i] != null && _array[i].Equals(item))
                {
                    index = Count - 1;
                }
            }

            return index;
        }

        public bool RemoveAt(int index)
        {
            while (_array != null)
            {
                if (index < Capacity)
                {
                    Array.Copy(_array, index + 1, _array, index, Count - index);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T value)
        {
            int index = IndexOf(value);
            Array.Copy(_array, index + 1, _array, index, Count - index);
            Count--;
            return true;
        }

        public T[] Sort()
        {
            for (int i = 0; i < _array.Length; i++)
                for (int j = 0; j < _array.Length - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(_array[j], _array[j + 1]) < 0)
                    {
                        T temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }

            return _array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        private void IncrementArraySize()
        {
            Count++;
        }
    }
}

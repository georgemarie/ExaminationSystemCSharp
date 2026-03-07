using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Data
{
    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        private T[] _items = new T[0];

        public void Add(T item)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = item;
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(_items, item);
            if (index < 0) return;

            for (int i = index; i < _items.Length - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            Array.Resize(ref _items, _items.Length - 1);
        }

        public void Sort()
        {
            Array.Sort(_items);
        }

        public T[] GetAll() => (T[])_items.Clone();
    }
}

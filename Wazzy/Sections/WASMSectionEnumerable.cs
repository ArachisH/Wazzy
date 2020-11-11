using System.Collections;
using System.Collections.Generic;

namespace Wazzy.Sections
{
    public abstract class WASMSectionEnumerable<T> : WASMSection, IList<T>
    {
        protected List<T> Subsections { get; }

        protected WASMSectionEnumerable(WASMSectionId id)
            : base(id)
        {
            Subsections = new List<T>();
        }

        #region IList<T> Implementation
        public T this[int index]
        {
            get => Subsections[index];
            set => Subsections[index] = value;
        }
        public int Count => Subsections.Count;
        bool ICollection<T>.IsReadOnly => false;

        public int IndexOf(T item) => Subsections.IndexOf(item);
        public void RemoveAt(int index) => Subsections.RemoveAt(index);
        public void Insert(int index, T item) => Subsections.Insert(index, item);

        public void Clear() => Subsections.Clear();
        public void Add(T item) => Subsections.Add(item);
        public bool Remove(T item) => Subsections.Remove(item);
        public bool Contains(T item) => Subsections.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => Subsections.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Subsections).GetEnumerator();
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Subsections).GetEnumerator();
        #endregion
    }
}
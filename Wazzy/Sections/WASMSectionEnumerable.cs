using System.Collections;

namespace Wazzy.Sections;

public abstract class WASMSectionEnumerable<T> : WASMSection, IList<T>
{
    private readonly List<T> _subsections;
    private readonly Dictionary<T, int> _indices;

    protected int Capacity
    {
        get => _subsections.Capacity;
        set
        {
            _subsections.Capacity = value;
            if (_indices != null)
            {
                _indices.EnsureCapacity(value);
            }
        }
    }

    protected WASMSectionEnumerable(WASMSectionId id)
        : base(id)
    {
        _subsections = new List<T>();
        if (!typeof(T).IsValueType)
        {
            // These objects can't be trusted, as duplicate values may appear.
            _indices = new Dictionary<T, int>();
        }
    }

    protected virtual void Cleared()
    { }
    protected virtual void Added(int index, T subsection)
    { }
    protected virtual void Removed(int index, T subsection)
    { }

    #region IList<T> Implementation
    public T this[int index]
    {
        get => _subsections[index];
        set
        {
            T oldSubsection = _subsections[index];
            _subsections[index] = value;

            Removed(index, oldSubsection);
            Added(index, value);
        }
    }
    public int Count => _subsections.Count;
    bool ICollection<T>.IsReadOnly => false;

    public int Add(T item)
    {
        int index = _subsections.Count;
        _subsections.Add(item);
        if (_indices != null)
        {
            _indices.Add(item, index);
        }
        Added(index, item);
        return index;
    }
    void ICollection<T>.Add(T item) => Add(item);

    public int Remove(T item)
    {
        int index = IndexOf(item);
        if (index != -1)
        {
            RemoveAt(index);
        }
        return index;
    }
    bool ICollection<T>.Remove(T item) => Remove(item) != -1;

    public int IndexOf(T item)
    {
        if (_indices == null)
        {
            return _subsections.IndexOf(item);
        }
        else return _indices.TryGetValue(item, out int index) ? index : -1;
    }
    public void RemoveAt(int index)
    {
        T subsection = _subsections[index];
        _subsections.RemoveAt(index);
        if (_indices != null)
        {
            _indices.Remove(subsection);
            for (int i = index; i < _subsections.Count; i++)
            {
                T a = _subsections[i];
                _indices[a]--;
            }
        }
        Removed(index, subsection);
    }
    public void Insert(int index, T item)
    {
        _subsections.Insert(index, item);
        if (_indices != null)
        {
            _indices.Add(item, index);
            for (int i = index + 1; i < _subsections.Count; i++)
            {
                T subsection = _subsections[i];
                _indices[subsection]++;
            }
        }
        Added(index, item);
    }

    public void Clear()
    {
        _subsections.Clear();
        _indices.Clear();
        Cleared();
    }
    public bool Contains(T item) => IndexOf(item) != -1;
    public void CopyTo(T[] array, int arrayIndex) => _subsections.CopyTo(array, arrayIndex);

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_subsections).GetEnumerator();
    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_subsections).GetEnumerator();
    #endregion
}
﻿using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Library.Extensions;

public static class ObservableCollectionExtensions
{
    /// <summary>
    /// Inserts an item into a list in the correct place, based on the provided key and key comparer. Use like OrderBy(o => o.PropertyWithKey).
    /// </summary>
    public static void InsertInPlace<TItem, TKey>(this ObservableCollection<TItem> collection, TItem itemToAdd, Func<TItem, TKey> keyGetter, IComparer<TKey> comparer = null)
    {
        int index = 0;
        if (comparer is not null)
        {
            index = collection.ToList().BinarySearch(keyGetter(itemToAdd), comparer, keyGetter);
        }
        else
        {
            index = collection.ToList().BinarySearch(keyGetter(itemToAdd), Comparer<TKey>.Default, keyGetter);
        }
        collection.Insert(index, itemToAdd);
    }
    /// <summary>
    /// Binary search.
    /// </summary>
    /// <returns>Index of item in collection.</returns> 
    /// <notes>This version tops out at approximately 25% faster than the equivalent recursive version. This 25% speedup is for list
    /// lengths more of than 1000 items, with less performance advantage for smaller lists.</notes>
    public static int BinarySearch<TItem, TKey>(this IList<TItem> collection, TKey keyToFind, IComparer<TKey> comparer, Func<TItem, TKey> keyGetter)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        int lower = 0;
        int upper = collection.Count - 1;

        while (lower <= upper)
        {
            int middle = lower + (upper - lower) / 2;
            int comparisonResult = comparer.Compare(keyToFind, keyGetter.Invoke(collection[middle]));
            if (comparisonResult == 0)
            {
                return middle;
            }
            else if (comparisonResult < 0)
            {
                upper = middle - 1;
            }
            else
            {
                lower = middle + 1;
            }
        }

        // If we cannot find the item, return the item below it, so the new item will be inserted next.
        return lower;
    }
}


public class SortedObservableCollection<T> : ObservableCollection<T>
{
    private readonly List<T> _list;

    public SortedObservableCollection(List<T> list) : base()
    {
        _list = list;
        foreach (var item in list)
        {
            this.InsertInPlace(item, o => o);
        }
    }
    public SortedObservableCollection(List<T> list, Func<T, string> keyGetter) : base()
    {
        _list = list;
        foreach (var item in list)
        {
            this.InsertInPlace(item, keyGetter);
        }
    }

    public SortedObservableCollection(List<T> list, IComparer<T> comparer)
    {
        foreach (var item in list)
        {
            this.InsertInPlace(item, o => o, comparer);
        }
    }

    public new void Add(T item)
    {
        this.InsertInPlace(item, o => o);
    }
    public void Add(T item, Func<T, string> keyGetter)
    {
        this.InsertInPlace(item, keyGetter);
    }
    public void Sort()
    {
        CheckReentrancy();
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}
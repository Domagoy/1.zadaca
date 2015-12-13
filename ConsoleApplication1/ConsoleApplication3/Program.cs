using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public interface IGenericList<X> : IEnumerable<X>
    {
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        void Add(X item);
        /// <summary>
        /// Removes the first occurrence of an item from the collection.
        /// If the item was not found, method does nothing.
        /// </summary>
        bool Remove(X item);
        /// <summary>
        /// Removes the item at the given index in the collection.
        /// </summary>
        bool RemoveAt(int index);
        /// <summary>
        /// Returns the item at the given index in the collection.
        /// </summary>
        X GetElement(int index);
        /// <summary>
        /// Returns the index of the item in the collection.
        /// If item is not found in the collection, method returns -1.
        /// </summary>
        int IndexOf(X item);
        /// <summary>
        /// Readonly property. Gets the number of items contained in the collection.
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        void Clear();
        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        bool Contains(X item);
        ///<summary>
        ///foreach GetEnumerator 
        /// </summary>
    }

    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        IGenericList<X> _collection;
        int position = 0;


        public GenericListEnumerator(IGenericList<X> collection)
        {
            _collection = collection;
        }
        public bool MoveNext()
        {
            if (position<_collection.Count)
            {
                position++;
                return true;

            }
            return false;

            // Zove se prije svake iteracije. 
            // Vratite true ako treba ući u iteraciju, false ako ne 
            // Hint: čuvajte neko globalno stanje po kojem pratite gdje se
            // nalazimo u kolekciji 

        }
public X Current
        {
            get
            {
                return _collection.GetElement(position - 1); 
              // Zove se na svakom ulasku u iteraciju 
              // Hint: Koristite stanje postavljeno u MoveNext() dijelu 
              // kako bi odredili što se zapravo vraća u ovom koraku 
            }
        }
       object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
public void Dispose()
        { // Ignorirajte }
public void Reset()
        { // Ignorirajte } }
        }

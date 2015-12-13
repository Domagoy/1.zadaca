using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public interface IGenericList<X>
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
    }

    public class GenericList<X> : IGenericList<X>
    {
        int counter = 0;
        public X[] _internalStorage;
        public GenericList()
        {
            _internalStorage = new X[4];


        }
        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];

        }
        private X[] list2;
        public void Add(X item)
        {
            if (counter + 1 > _internalStorage.Length)
            {
                list2 = new X[(_internalStorage.Length) * 2];
                for (int i = 0; i < counter; i++)
                {
                    list2[i] = _internalStorage[i];
                }
                list2[counter] = item;
                _internalStorage = list2;
                list2 = null;
            }
            else
            {
                _internalStorage[counter] = item;
            }
            counter++;
        }

        public bool RemoveAt(int index)
        {
            if (index > counter)
            {
                return false;
            }
            for (int i = index + 1; i < (counter - 1); i++)
            {
                _internalStorage[i - 1] = _internalStorage[i];
            }
            counter--;
            return true;
        }

        public bool Remove(X item)
        {

            for (int i = 0; i <= counter; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }

            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index < counter)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new System.IndexOutOfRangeException();
            }

        }

        public int Count
        {
            get
            {
                return counter;
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (_internalStorage[i].Equals(item)
                    )
                    return i;
            }
            return -1;

        }

        public void Clear()
        {
            int len = _internalStorage.Length;
            _internalStorage = null;
            _internalStorage = new X[len];
            counter = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (_internalStorage[i].Equals(item))
                    return true;
            }

            return false;
        }

    }
    public class Main_program
    { 
         static void Main()
        {
            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("!");
            Console.WriteLine(stringList.Count); // 3
            Console.WriteLine(stringList.Contains("Hello")); // true
            Console.WriteLine(stringList.IndexOf("Hello")); // 0
            Console.WriteLine(stringList.GetElement(1)); // World
            IGenericList<double> doubleList = new GenericList<double>();
            doubleList.Add(0.2);
            doubleList.Add(0.7);

        }

       
    }
}

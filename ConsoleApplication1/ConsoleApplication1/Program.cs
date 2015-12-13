using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IIntegerList
    {
        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        void Add(int item);

        /// <summary>
        /// Removes the first occurence of an item  from the collection.
        /// If the item was not found, method does nothing.
        /// </summary>
        bool Remove(int item);

        /// <summary>
        /// Removes the item at the given index in the collection.
        /// </summary>
        bool RemoveAt(int index);

        /// <summary>
        /// Returns the item at the given index in the collection.
        /// </summary>
        int GetElement(int index);

        /// <summary>
        /// Returns the index of the item in the collection.
        /// if item is not found in the collection, the method returns -1
        /// </summary>
        int IndexOf(int item);

        /// <summary>
        /// Read-only property. Gets the number of items contained in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Removes all items from the collection.
        /// </summay>
        void Clear();

        /// <summary>
        /// Determines wether the collection contains a specific value.
        /// </summary>
        bool Contains(int item);
    }


    public class IntegerList : IIntegerList
    {
        int counter = 0;
        public int[] _internalStorage;
        public IntegerList()
        {
            _internalStorage = new int[4];


        }
        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];

        }
        private int[] list2;
        public void Add(int item)
        {
            if (counter + 1 > _internalStorage.Length)
            {
                list2 = new int[(_internalStorage.Length) * 2];
                for (int i = 0; i <counter; i++)
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
            for (int i = index+1 ; i <( counter - 1); i++)
            {
                _internalStorage[i-1] = _internalStorage[i];
            }
            counter--;
            return true;
        }

        public bool Remove(int item)
        {

            for (int i = 0; i <=counter; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return RemoveAt(i);
                }

            }
            return false;
        }

        public int GetElement(int index)
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

        public int IndexOf(int item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (_internalStorage[i] == item)
                    return i;
            }
            return -1;

        }

        public void Clear()
        {
            int len = _internalStorage.Length;
            _internalStorage = null;
            _internalStorage = new int[len];
            counter = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (_internalStorage[i] == item)
                    return true;
            }

            return false;
        }



        static void Main()
        {
            IntegerList Lista = new IntegerList();
            Lista.Add(1);
            Lista.Add(2);
            Lista.Add(3);
            Lista.Add(4);
            Lista.Add(5);
            // lista je [1,2,3,4,5]
            // Mičemo prvi element liste.
           // for (int i = 0; i < Lista._internalStorage.Length; i++)
            //{
            //    Console.WriteLine(Lista._internalStorage[i]);
            //}
            Lista.RemoveAt(0);
            // Lista je [2,3,4,5]
            //for (int i = 0; i < Lista._internalStorage.Length; i++)
            //{
              //  Console.WriteLine(Lista._internalStorage[i]);
            //}
            // Mičemo element liste čija je vrijednost "5".
            Lista.Remove(5);
            // Lista je [2,3,4]
            Console.WriteLine(Lista.Count);
            // 3
           // for (int i = 0; i < Lista._internalStorage.Length; i++)
            //{
            //    Console.WriteLine(Lista._internalStorage[i]);
            //}
            Console.WriteLine(Lista.Remove(100));
            // false, nemamo element u vrijednosti 100
            Console.WriteLine(Lista.RemoveAt(5));
            // false, nemamo ništa na poziciji 5
            // Brišemo sav sadržaj kolekcije
            Lista.Clear();
            Console.WriteLine(Lista.Count);
            // 0
            Console.ReadLine();

        }
    }
}

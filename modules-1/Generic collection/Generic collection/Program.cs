using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Generic_collection
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Adding new elements to the array.
            // NewList<string> list = new NewList<string>(4);
            IGeneric_collection<string> mylist = new NewList<string>(4)
            {
                "ken",
                "John",
                "apple",
                "beans",
                "sugar"
            };

            // adding a Range of values
            string[] strArray = { "jim", "corey", "ye", "ken", "john" };
            mylist.AddRange(strArray);

            // listing all added items
            Console.WriteLine("unsorted list:");

            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }

            // checking if list contains an element
            bool ifContains = mylist.Contain("apple");
            Console.WriteLine(ifContains + "\n");

            // checking index of an element.
            int indexOf = mylist.IndexOf("john");
            Console.WriteLine(indexOf + "\n");

            // checking last index of
            int lastIndexOf = mylist.LastIndexOf("john");
            Console.WriteLine(lastIndexOf + "\n");

            // removes the item element from the list, and if the removal was successful, then returns true;
            bool isRemove = mylist.Remove("john");
            Console.WriteLine(isRemove + "\n");

            // removal of the element at the specified index;
            bool isRemoveAt = mylist.RemoveAt(0);
            Console.WriteLine(isRemoveAt + "\n");

            // sorted list
            mylist.Sort();
            Console.WriteLine("sorted list: ");
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }
        }
    }
}

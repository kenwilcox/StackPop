using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackPop
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToList();
            var copy = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                copy.AddRange(items.ToList());
                copy.AddRange(items.ToList());
                copy.AddRange(items.ToList());
                copy.AddRange(items.ToList());
                copy.AddRange(items.ToList());
                copy.AddRange(items.ToList());
            }
            copy.Add(0); // to make sure we're odd

            const int max = 10;
            var stack = new Stack(copy);

            while (stack.Count > 0)
            {
                var remove = stack.Pop(max);
                Console.WriteLine("Pop Count: {0}", remove.Count());
                Console.WriteLine("Stack Count: {0}", stack.Count);
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.ReadKey();
            }
        }
    }

    public static class StackExt
    {
        public static IEnumerable<object> Pop(this Stack stack, int count)
        {
            var real = Math.Min(stack.Count, count);
            var ret = new List<object>(real);
            for (var i = 0; i < real; i++)
            {
                // if we do an add, then the return is reversed
                //ret.Add(stack.Pop());
                ret.Insert(0, stack.Pop());
            }
            return ret.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Parallax.Extensions
{
    public static class Extensions
    {
        public static void Call<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach(T item in collection)
            {
                action(item);
            }
        }
    }
}
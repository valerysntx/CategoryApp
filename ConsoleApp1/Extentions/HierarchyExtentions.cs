using System;
using System.Collections.Generic;
using System.Linq;
using CategoriesApp.Model;

namespace CategoriesApp.Extentions
{
    /// <summary>
    /// Flatten Hierarchize transformations
    /// </summary>
    /// 
    public static class HierarchyExtentions
    {

        // process flat-representation etc.

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public static IEnumerable<Node<T>> Hierarchize<T, TKey>(
            this IEnumerable<T> elements,
            TKey topMostKey,
            Func<T, TKey> keySelector,
            Func<T, TKey> parentKeySelector)
        {
            var families = elements.ToLookup(parentKeySelector);
            var childrenFetcher = default(Func<TKey, IEnumerable<Node<T>>>);
            childrenFetcher = parentId => families[parentId]
                .Select(x => new Node<T>(x, childrenFetcher(keySelector(x))));

            return childrenFetcher(topMostKey);
        }


        public static IEnumerable<T> Flatten<T>(
            this IEnumerable<T> items,
            Func<T, IEnumerable<T>> getChildren)
        {
            var stack = new Stack<T>();
            foreach (var item in items)
                stack.Push(item);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;

                var children = getChildren(current);
                if (children == null) continue;

                foreach (var child in children)
                    stack.Push(child);
            }
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }


        public static IEnumerable<Tuple<T, int>> FlattenWithLevel<T>(
            this IEnumerable<T> items,
            Func<T, IEnumerable<T>> getChilds)
        {
            var stack = new Stack<Tuple<T, int>>();
            foreach (var item in items)
                stack.Push(new Tuple<T, int>(item, 1));

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;

                foreach (var child in getChilds(current.Item1))
                {
                    stack.Push(new Tuple<T, int>(child, current.Item2 + 1));
                }

            }
        }
    }
}
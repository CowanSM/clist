using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CList {
    delegate void Func<T>(T item);

    public class CList<T> : List<T> {
        public CList(int capacity)
            : base(capacity) {
        }

        public CList()
            : base() {
        }

        /// <summary>
        /// Applies the given function to each element in the list.
        /// </summary>
        /// <param name="f">Function that takes in and returns an item. Covariance can be used for more derived types.</param>
        /// <returns>A list with each element having applied to the function</returns>
        public CList<T> map(Func<T,T> f) {
            CList<T> outList = new CList<T>(this.Capacity);
            foreach (T item in this) {
                outList.Add(f(item));
            }
            return outList;
        }

        /// <summary>
        /// Applies the given function to each element in the list.
        /// </summary>
        /// <param name="f">Function that takes in an item. The function has a return type of void.</param>
        public void forEach(Func<T> f) {
            foreach (T item in this) {
                f(item);
            }
        }

        /// <summary>
        /// Filters the list based on the match item provided. The returned list will only contain items that are equal
        /// to the matchItem.
        /// </summary>
        /// <param name="matchItem">Item to use for matching.</param>
        /// <returns>A list of items from the original list that are equal to the match item.</returns>
        public CList<T> filter(T matchItem) {
            CList<T> outList = new CList<T>();
            foreach (T item in this) {
                if (System.Object.Equals(matchItem, item))
                    outList.Add(item);
            }
            return outList;
        }

        /// <summary>
        /// Filters the list based on the weed item provided. The returned list will only contain items that are not
        /// equal to the weedItem.
        /// </summary>
        /// <param name="weedItem">Item to weed out of the list.</param>
        /// <returns>A list of items from the original list that are not equal to the weed item.</returns>
        public CList<T> filterOut(T weedItem) {
            CList<T> outList = new CList<T>();
            foreach (T item in this) {
                if (!System.Object.Equals(weedItem, item))
                    outList.Add(item);
            }
            return outList;
        }
    }
}

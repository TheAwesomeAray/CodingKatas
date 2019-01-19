using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public class PaginationHelper<T>
    {
        private IList<T> _collection { get; }
        private int _itemsPerPage { get; }
        public int PageCount { get; }
        public int ItemCount => _collection.Count;

        public PaginationHelper(IList<T> collection, int itemsPerPage)
        {
            _collection = collection;
            _itemsPerPage = itemsPerPage;
            PageCount = (int)Math.Ceiling((double)collection.Count / itemsPerPage);
        }

        public int PageItemCount(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex >= PageCount)
                return -1;

            return _collection.Skip(pageIndex * _itemsPerPage).Take(_itemsPerPage).Count();
        }

        public int PageIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex > _collection.Count - 1)
                return -1;

            return itemIndex / _itemsPerPage;
        }
    }
}

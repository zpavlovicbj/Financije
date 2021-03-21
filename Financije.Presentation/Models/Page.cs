using System.Collections.Generic;

namespace Financije.Presentation.Models
{
    public class Page<T>
    {
        public List<T> Items { get; private set; }
        public int Total { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasNext { get; private set; }
        public bool HasPrevious { get; private set; }
        public bool HasFirst { get; private set; }
        public bool HasLast { get; private set; }

        public Page(List<T> items, int total, int page, int pageSize)
        {
            Items = items;
            Total = total;
            CurrentPage = page;
            PageSize = pageSize;

            Init();
        }

        public Page(List<T> items, int total, int page)
        {
            Items = items;
            Total = total;
            CurrentPage = page;

            Init();
        }

        public Page(int total)
        {
            Total = total;
            Init();
        }

        private void Init()
        {
            CalculatePages();
            ResolveButtonLogic();
        }

        private void ResolveButtonLogic()
        {
            if (CurrentPage > 1)
            {
                HasPrevious = true;
                HasFirst = true;
            }
            else
            {
                HasPrevious = false;
            }

            if (CurrentPage == TotalPages)
            {
                HasNext = false;
            }
            else
            {
                HasNext = true;
                HasLast = true;
            }

            if (TotalPages == 1)
            {
                HasPrevious = false;
                HasFirst = false;
                HasNext = false;
                HasLast = false;
            }
        }

        public void CalculatePages()
        {
            int tempRetValue = Total / PageSize;
            int pCount = tempRetValue * PageSize;

            if (pCount < Total)
            {
                TotalPages = ++tempRetValue;
            }
            else
            {
                TotalPages = tempRetValue;
            }
        }
    }
}

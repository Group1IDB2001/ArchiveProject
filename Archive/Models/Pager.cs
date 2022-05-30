namespace Archive.Models
{
    public class Pager
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }



        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public Pager() { }
        public Pager(int totalitems ,int page , int pageSize = 12)
        {
            //Ceiling Возвращает наименьшее целое число, которое больше или равно указанному числу. 7,03 => 8
            int totalpages = (int)Math.Ceiling((decimal)totalitems / (decimal)pageSize);
            int currentPage = page ;

            int startPage = CurrentPage - 1;
            int endPage = CurrentPage + 1;

            if(StartPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if(endPage > totalpages)
            {
                endPage = totalpages;
                if (endPage > 3)
                {
                    startPage = endPage - 2;
                }
            }


            TotalPages = totalpages;
            CurrentPage = currentPage;
            TotalItems = totalitems;
            PageSize = pageSize;
            StartPage = startPage;
            EndPage = endPage;

        }
    }
}

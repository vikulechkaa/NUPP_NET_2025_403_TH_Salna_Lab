using Library.Common.Models;

namespace Library.Common.Extensions
{
    public static class LibraryExtensions
    {
        // метод розширення
        public static bool IsOld(this LibraryItem item, int olderThanYear)
        {
            return item.Year < olderThanYear;
        }
    }
}

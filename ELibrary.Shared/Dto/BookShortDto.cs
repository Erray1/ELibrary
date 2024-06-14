using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto
{
    public class BookShortDto
    {
		public string BookId { get; set; } = "1";
		public List<string> Authors { get; set; } = new() { "Пелевин" };

        public string BookName { get; set; } = "Поколение П";
        public string Description { get; set; } = "Отличная книга";
        public List<string> CategoryName { get; set; } = new() { "Постмодернизм" };

        public int YearWritten { get; set; } = 1999;

        public string ImageName { get; set; } = "pelevin.png";
        public string ImageURL => Path.Combine("img", ImageName);
    }
}

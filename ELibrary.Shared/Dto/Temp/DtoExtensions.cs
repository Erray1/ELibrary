using ELibrary.Shared.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Temp
{
    public static class DtoExtensions
    {
        public static AccountDto Test()
        {
            return new AccountDto()
            {
                Name = "Дементьев Егор Павлович",
                TakenBooks = new() {
                    new TakenBook() {
                        Id = "1",
                        ExpirationDate = DateOnly.MaxValue,
                        LibraryName = "Красик",
                        Name = "Поколение П",
                        Authors = ["Пелевин"],
                        RecieveTime = DateTime.Now
                    },
                    new TakenBook() {
                        Id = "2",
                        ExpirationDate = DateOnly.MaxValue.AddYears(-1000),
                        LibraryName = "Красик",
                        Name = "Поколение ПППппПпп",
                        Authors = ["Пелевин"],
                        RecieveTime = DateTime.Now
                    },
                    new TakenBook() {
                        Id = "3",
                        ExpirationDate = DateOnly.MinValue,
                        LibraryName = "Красик",
                        Name = "Омон Ра",
                        Authors = ["Пелевин"],
                        RecieveTime = DateTime.Now
                    }
                },
                BookedBooks = new()
                {
                    new BookedBook()
                    {
                        Id = "4",
                        Authors = ["Пелевин"],
                        Name = "T",
                        ExpirationDate = DateTime.MaxValue,
                        LibraryName = "Красик",
                        Status = BookBookingStatus.WaitingForReceiving
                    },
                    new BookedBook()
                    {
                        Id = "5",
                        Authors = ["Пелевин"],
                        Name = "SNUFF",
                        ExpirationDate = DateTime.MaxValue,
                        LibraryName = "Красик",
                        Status = BookBookingStatus.Processing
                    }
                }
            };
        }
    }
}

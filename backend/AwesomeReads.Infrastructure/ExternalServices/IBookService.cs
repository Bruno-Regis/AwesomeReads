using AwesomeReads.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Infrastructure.ExternalServices
{
    public interface IBookService
    {
        Task<BookServiceViewModel> ConsultBookByIsbnAsync(string isbn);
    }
}

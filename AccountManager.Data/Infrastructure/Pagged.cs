using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Infrastructure
{
    public class Pagged<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public object Request { get; set; }
    }
}

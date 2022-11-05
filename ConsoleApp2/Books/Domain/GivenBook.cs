using System;

namespace Books.Domain
{
    public class GivenBook
    {
        public DateTime GivenDate { get; set; }
        public string Customer { get; set; }
        public int GivenPeriod { get; set; }
        public Book Book { get; set; }
    }
}

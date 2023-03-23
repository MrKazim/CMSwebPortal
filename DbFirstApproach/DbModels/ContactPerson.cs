using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class ContactPerson
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
    }
}

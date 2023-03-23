using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class Official
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Message { get; set; }
        public string? Path { get; set; }
        public string? Contact { get; set; }
        public bool? IsHome { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Type { get; set; }
        public string? CreatedBy { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

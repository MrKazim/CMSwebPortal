using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class Work
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
        public string? Date { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class Header
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}

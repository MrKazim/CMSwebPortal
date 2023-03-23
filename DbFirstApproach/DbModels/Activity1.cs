using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class Activity1
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ActivityType { get; set; }
        public string? Date { get; set; }
        public string? Path { get; set; }
        public string? Link { get; set; }
        public bool IsHome { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

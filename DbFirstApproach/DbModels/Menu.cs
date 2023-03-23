using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class Menu
    {
        public long Id { get; set; }
        public string? Label { get; set; }
        public string? Title { get; set; }
        public string? Action { get; set; }
        public string? Controller { get; set; }
        public long? ParentId { get; set; }
        public string? Footer { get; set; }
        public string? Admin { get; set; }
        public string? Detail { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class SecurityCommittee
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string ModifiedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

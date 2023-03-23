using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class App
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string HeaderLogo { get; set; } = null!;
        public string SlideImg { get; set; } = null!;
        public string LandingImg { get; set; } = null!;
        public string VideoPath { get; set; } = null!;
        public string Polisy { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Mission { get; set; } = null!;
        public string Vision { get; set; } = null!;
        public string Call { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gov { get; set; } = null!;
        public string TermCondition { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string ModifiedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}

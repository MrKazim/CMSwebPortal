using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.Models.DbModels
{
    public class App
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }
        public string HeaderLogo { get; set; }
        public string SlideImg { get; set; }
        public string LandingImg { get; set; }
        public string VideoPath { get; set; }
        public string Polisy { get; set; }
        public string Summary { get; set; }
        public string Mission { get; set; }
        public string Vision { get; set; }
        public string Call { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gov { get; set; }
        public string TermCondition { get; set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Timestamp]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}

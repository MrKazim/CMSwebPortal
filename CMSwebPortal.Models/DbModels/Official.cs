using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.Models.DbModels
{
    public class Official
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string? Name { get; set; }
        public string? Position { get; set; }

        public string? Message { get; set; }
        public string? Path { get; set; }
        public string? Contact { get; set; }
        public bool? isHome { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Type { get; set; }

        public string? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Timestamp]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

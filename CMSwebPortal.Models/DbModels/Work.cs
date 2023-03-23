using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.Models.DbModels
{
    public class Work
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
        public string? Date { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        [Timestamp]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public DateTime? DateT { get; set; }
    }
}

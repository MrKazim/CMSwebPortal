using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.Models.DbModels
{
    public class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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
        [Timestamp]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? isActive { get; set; }
    }
}

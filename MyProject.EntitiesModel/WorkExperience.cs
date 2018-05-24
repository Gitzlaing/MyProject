using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.EntitiesModel
{
    [Table("WorkExperience")]
    public partial class WorkExperience
    {
        [Key]
        public int WorkId { get; set; }
        public int Uid { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string Position { get; set; }
        [StringLength(1000)]
        [DisplayName("描述")]
        public string Description { get; set; }


        public virtual UserInfo UserInfo { get; set; }
    }
}

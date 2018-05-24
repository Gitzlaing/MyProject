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
    [Table("ProjectExperience")]
    public partial class ProjectExperience
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public int Uid { get; set; }

        [StringLength(100)]
        public string ProjectName { get; set; }

        [DisplayName("开发时间")]
        public int Duration { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("描述")]
        public string Description { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}

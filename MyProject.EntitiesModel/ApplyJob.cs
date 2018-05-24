using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.EntitiesModel
{
    [Table("ApplyJob")]
    public partial class ApplyJob
    {
        [Key]
        public int ApplyJobId { get; set; }

        public int Uid { get; set; }
        public int JobId { get; set; }

        public int CompanyId { get; set; }
        public int Status { get; set; }

        public DateTime Date { get; set; }

       


        /// <summary>
        /// 导航属性,外键所对应的表
        /// </summary>
        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual Jobs Jobs { get; set; }

        public virtual UserInfo UserInfo { get; set; }

    }
}


namespace MyProject.EntitiesModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jobs
    {
        public Jobs(){
            this.ApplyJob = new HashSet<ApplyJob>();
        }
        [Key]
        public int JobId { get; set; }

        public int CompanyId { get; set; }
        
        public int TypeId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="请输入职位名称")]
        public string JobName { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="职位描述不能为空")]
        public string Describe { get; set; }

        [RegularExpression(@"\d+",ErrorMessage ="请输入数字")]
        [Required(ErrorMessage ="请输入需求人数")]
        [DisplayName("需求人数")]
        public int? DemandNum { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "请输入工资上限")]
        [RegularExpression(@"^\d+([.]{1}[0-9]+)?$", ErrorMessage = "工资上限应输入数字")]
        public decimal SalaryUpper { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "请输入工资下限")]
        [RegularExpression(@"\d+([.]{1}[0-9]+)?", ErrorMessage = "工资下限应输入数字")]
        public decimal SalaryLower { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<ApplyJob> ApplyJob { get; set; }

        //外键导航属性

        public virtual CompanyInfo CompanyInfo { get; set; }

        public virtual JobType JobType { get; set; }
    }
}

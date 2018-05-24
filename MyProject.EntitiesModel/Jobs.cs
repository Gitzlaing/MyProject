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
        [Required(ErrorMessage ="������ְλ����")]
        public string JobName { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="ְλ��������Ϊ��")]
        public string Describe { get; set; }

        [RegularExpression(@"\d+",ErrorMessage ="����������")]
        [Required(ErrorMessage ="��������������")]
        [DisplayName("��������")]
        public int? DemandNum { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "�����빤������")]
        [RegularExpression(@"^\d+([.]{1}[0-9]+)?$", ErrorMessage = "��������Ӧ��������")]
        public decimal SalaryUpper { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "�����빤������")]
        [RegularExpression(@"\d+([.]{1}[0-9]+)?", ErrorMessage = "��������Ӧ��������")]
        public decimal SalaryLower { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<ApplyJob> ApplyJob { get; set; }

        //�����������

        public virtual CompanyInfo CompanyInfo { get; set; }

        public virtual JobType JobType { get; set; }
    }
}

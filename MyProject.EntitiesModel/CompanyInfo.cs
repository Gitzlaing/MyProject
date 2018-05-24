namespace MyProject.EntitiesModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("CompanyInfo")]
    public partial class CompanyInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyInfo()
        {
            Jobs = new HashSet<Jobs>();
            ApplyJob = new HashSet<ApplyJob>();
        }

        [Key]
        public int CompanyId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "*请输入账号")]
        [Remote("CheckUsername", "Home", "Company", ErrorMessage = "*已存在的用户名！")]
        public string Username { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*请输入账号")]
        public string PassWord { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "*邮箱格式错误")]
        public string Email { get; set; }

        [StringLength(20)]
        public string Manager { get; set; }

        public int? Click { get; set; }

        [StringLength(100)]
        public string ImgUrl { get; set; }

        [StringLength(200)]
        public string ThumbUrl { get; set; }

        [StringLength(100)]
        public string LicenseUrl { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Describe { get; set; }

        public bool IsIdentify { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jobs> Jobs { get; set; }

        public virtual ICollection<ApplyJob> ApplyJob { get; set; }
    }
}

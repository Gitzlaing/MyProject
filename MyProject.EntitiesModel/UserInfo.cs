namespace MyProject.EntitiesModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.ApplyJob = new HashSet<ApplyJob>();
            this.WorkExperience = new HashSet<WorkExperience>();
            this.ProjectExperience = new HashSet<ProjectExperience>();
        }

        [Key]
        public int Uid { get; set; }
        [Required(ErrorMessage = "*�������û���")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "*����Ϊ4~10λ")]
        [Remote("CheckUsername", "User", AreaReference.UseRoot, ErrorMessage = "*���û��Ѵ���!", HttpMethod = "post")]
        [RegularExpression(@"^[a-zA-Z0-9_-]*$", ErrorMessage = "*�����Ƿ��ַ�,�����֡���ĸ���»������")]
        public string Username { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*����������")]
        public string Password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*����������")]
        public string Name { get; set; }

        [DisplayName("�û�ͷ��")]
        public byte[] Avatar { get; set; }

        public bool? Sex { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(100)]
        public string School { get; set; }

        [StringLength(100)]
        public string Specialty { get; set; }

        [StringLength(50)]
        public string Knowledge { get; set; }

        [StringLength(50)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "*�����ʽ����")]
        public string Tel { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "*�����ʽ����")]
        public string Email { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Describe { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }



        public ICollection<ApplyJob> ApplyJob { get; set; }

        public ICollection<ProjectExperience> ProjectExperience { get; set; }

        public ICollection<WorkExperience> WorkExperience { get; set; }
    }
}

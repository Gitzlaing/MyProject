//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyProject.EntitiesModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompanyInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyInfo()
        {
            this.Jobs = new HashSet<Jobs>();
        }
    
        public int CompanyId { get; set; }
        public string PassWord { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Manager { get; set; }
        public string Username { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> Click { get; set; }
        public string ImgUrl { get; set; }
        public string ThumbUrl { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string LicenseUrl { get; set; }
        public string Describe { get; set; }
        public bool IsIdentify { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jobs> Jobs { get; set; }
    }
}

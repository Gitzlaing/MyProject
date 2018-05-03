namespace MyProject.EntitiesModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jobs
    {
        public int Id { get; set; }

        public int? CompanyId { get; set; }

        [StringLength(50)]
        public string JobName { get; set; }

        [StringLength(1000)]
        public string Describe { get; set; }

        public int? DemandNum { get; set; }

        [StringLength(50)]
        public string DemandType { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalaryUpper { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalaryLower { get; set; }

        public virtual CompanyInfo CompanyInfo { get; set; }
    }
}

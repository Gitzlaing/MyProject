namespace MyProject.EntitiesModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Operator")]
    public partial class Operator
    {
        public int OperatorId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="*«Î ‰»Î’À∫≈")]
        public string OperatName { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="*«Î ‰»Î√‹¬Î")]
        public string Password { get; set; }
    }
}

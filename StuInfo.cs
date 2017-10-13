namespace MVCDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StuInfo")]
    public partial class StuInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SID { get; set; }

        [StringLength(20)]
        public string SName { get; set; }

        public int? ClassID { get; set; }
    }
}

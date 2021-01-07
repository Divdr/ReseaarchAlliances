namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblresearchfollower")]
    public partial class tblresearchfollower
    {
        [Key]
        public int ResearchFollowerID { get; set; }

        public int ResearchID { get; set; }

        public int UserID { get; set; }

        public virtual tblresearch tblresearch { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

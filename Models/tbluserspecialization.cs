namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbluserspecialization")]
    public partial class tbluserspecialization
    {
        [Key]
        public int UserSpecializationID { get; set; }

        public int UserID { get; set; }

        public int SpecializationID { get; set; }

        public virtual tblspecialization tblspecialization { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

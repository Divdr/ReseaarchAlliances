namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblresearchupdatelike")]
    public partial class tblresearchupdatelike
    {
        [Key]
        public int ResearchUpdateLikeID { get; set; }

        public int ResearchUpdateID { get; set; }

        public int UserID { get; set; }

        public DateTime _createdDt = DateTime.Now;

        public DateTime CreatedDt
        {
            get
            {
                return _createdDt;
            }
            set
            {
                _createdDt = value;
            }
        }

        public virtual tblresearchupdate tblresearchupdate { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

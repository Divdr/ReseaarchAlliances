namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblresearchrequest")]
    public partial class tblresearchrequest
    {
        [Key]
        public int ResearchRequestID { get; set; }

        public int ResearchID { get; set; }

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

        public int UserID { get; set; }

        public byte Status { get; set; }

        public virtual tblresearch tblresearch { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

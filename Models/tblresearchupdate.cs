namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblresearchupdate")]
    public partial class tblresearchupdate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblresearchupdate()
        {
            tblresearchupdatelikes = new HashSet<tblresearchupdatelike>();
        }

        [Key]
        public int ResearchUpdateID { get; set; }

        public int ResearchID { get; set; }

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

        [Required]
        [StringLength(500)]
        public string UpdateDescription { get; set; }

        public virtual tblresearch tblresearch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchupdatelike> tblresearchupdatelikes { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

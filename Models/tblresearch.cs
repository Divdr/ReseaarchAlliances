namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblresearch")]
    public partial class tblresearch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblresearch()
        {
            tblresearchfollowers = new HashSet<tblresearchfollower>();
            tblresearchrequests = new HashSet<tblresearchrequest>();
            tblresearchupdates = new HashSet<tblresearchupdate>();
        }

        [Key]
        public int ResearchID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int UserID { get; set; }

        public int SubCategoryID { get; set; }

        [Required]
        [StringLength(500)]
        public string FeaturedImage { get; set; }

        public byte Status { get; set; }

        public int NoOfViews { get; set; }

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

        public virtual tblsubcategory tblsubcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchfollower> tblresearchfollowers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchrequest> tblresearchrequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchupdate> tblresearchupdates { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

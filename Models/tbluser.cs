namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbluser")]
    public partial class tbluser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbluser()
        {
            tblarticles = new HashSet<tblarticle>();
            tblarticlecomments = new HashSet<tblarticlecomment>();
            tblarticlelikes = new HashSet<tblarticlelike>();
            tblresearches = new HashSet<tblresearch>();
            tblresearchfollowers = new HashSet<tblresearchfollower>();
            tblresearchrequests = new HashSet<tblresearchrequest>();
            tblresearchupdates = new HashSet<tblresearchupdate>();
            tblresearchupdatelikes = new HashSet<tblresearchupdatelike>();
            tbluserspecializations = new HashSet<tbluserspecialization>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public byte Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string ProfilePic { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        public byte Status { get; set; }

        [Required]
        [StringLength(10)]
        public string MoNumber { get; set; }

        public int CityID { get; set; }

        public DateTime _createdDt = DateTime.Now;

        public DateTime CreatedDt {
            get {
                return _createdDt;
            }
            set {
                _createdDt = value;
            } 
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblarticle> tblarticles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblarticlecomment> tblarticlecomments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblarticlelike> tblarticlelikes { get; set; }

        public virtual tblcity tblcity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearch> tblresearches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchfollower> tblresearchfollowers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchrequest> tblresearchrequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchupdate> tblresearchupdates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearchupdatelike> tblresearchupdatelikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbluserspecialization> tbluserspecializations { get; set; }
    }
}

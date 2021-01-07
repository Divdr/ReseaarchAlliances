namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblarticle")]
    public partial class tblarticle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblarticle()
        {
            tblarticlecomments = new HashSet<tblarticlecomment>();
            tblarticlelikes = new HashSet<tblarticlelike>();
        }

        [Key]
        public int ArticleID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int SubCategoryID { get; set; }

        public int UserID { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblarticlecomment> tblarticlecomments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblarticlelike> tblarticlelikes { get; set; }

        public virtual tblsubcategory tblsubcategory { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

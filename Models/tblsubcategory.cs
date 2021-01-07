namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblsubcategory")]
    public partial class tblsubcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblsubcategory()
        {
            tblarticles = new HashSet<tblarticle>();
            tblresearches = new HashSet<tblresearch>();
            tblspecializations = new HashSet<tblspecialization>();
        }

        [Key]
        public int SubCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }

        public byte Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblarticle> tblarticles { get; set; }

        public virtual tblcategory tblcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblresearch> tblresearches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblspecialization> tblspecializations { get; set; }
    }
}

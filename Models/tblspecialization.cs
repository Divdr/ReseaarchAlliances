namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblspecialization")]
    public partial class tblspecialization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblspecialization()
        {
            tbluserspecializations = new HashSet<tbluserspecialization>();
        }

        [Key]
        public int SpecializationID { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialization { get; set; }

        public int SubCategoryID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbluserspecialization> tbluserspecializations { get; set; }

        public virtual tblsubcategory tblsubcategory { get; set; }
    }
}

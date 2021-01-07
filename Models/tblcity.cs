namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblcity")]
    public partial class tblcity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblcity()
        {
            tblusers = new HashSet<tbluser>();
        }

        [Key]
        public int CityID { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        public int StateID { get; set; }

        public byte Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbluser> tblusers { get; set; }

        public virtual tblstate tblstate { get; set; }
    }
}

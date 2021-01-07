namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblarticlecomment")]
    public partial class tblarticlecomment
    {
        [Key]
        public int ArticleCommentID { get; set; }

        public int ArticleID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(150)]
        public string Comment { get; set; }

        public byte Status { get; set; }

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

        public virtual tblarticle tblarticle { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

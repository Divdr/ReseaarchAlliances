namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblarticlelike")]
    public partial class tblarticlelike
    {
        [Key]
        public int ArticleLikeID { get; set; }

        public int ArticleID { get; set; }

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

        public virtual tblarticle tblarticle { get; set; }

        public virtual tbluser tbluser { get; set; }
    }
}

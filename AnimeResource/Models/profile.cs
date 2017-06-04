namespace AnimeResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animedb.profile")]
    public partial class profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_user { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string sername { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birth { get; set; }

        [StringLength(100)]
        public string avatar { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string about { get; set; }

        public int? id_sex { get; set; }

        public int? id_country { get; set; }

        public virtual country country { get; set; }

        public virtual sex sex { get; set; }

        public virtual user user { get; set; }
    }
}

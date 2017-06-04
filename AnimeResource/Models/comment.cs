namespace AnimeResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animedb.comments")]
    public partial class comment
    {
        [Key]
        public int id_comment { get; set; }

        public int id_user { get; set; }

        public int id_anime { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string text { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public virtual anime anime { get; set; }

        public virtual user user { get; set; }
    }
}

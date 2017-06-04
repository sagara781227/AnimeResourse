namespace AnimeResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animedb.marks")]
    public partial class mark
    {
        [Key]
        public int id_mark { get; set; }

        public int id_user { get; set; }

        public int id_anime { get; set; }

        [Column("mark")]
        public int mark1 { get; set; }

        public virtual anime anime { get; set; }

        public virtual user user { get; set; }
    }
}

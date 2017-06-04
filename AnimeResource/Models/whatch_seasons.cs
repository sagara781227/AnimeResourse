namespace AnimeResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animedb.whatch_seasons")]
    public partial class whatch_seasons
    {
        [Key]
        public int id_ws { get; set; }

        public bool? wotch { get; set; }

        public int id_user { get; set; }

        public int id_anime { get; set; }

        public int id_serii { get; set; }

        public virtual serii serii { get; set; }

        public virtual users_anime users_anime { get; set; }
    }
}

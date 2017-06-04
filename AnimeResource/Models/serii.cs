namespace AnimeResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animedb.serii")]
    public partial class serii
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public serii()
        {
            whatch_seasons = new HashSet<whatch_seasons>();
        }

        [Key]
        public int id_serii { get; set; }

        public int id_anime { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string link { get; set; }

        public int id_typeser { get; set; }

        public virtual anime anime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<whatch_seasons> whatch_seasons { get; set; }

        public virtual typeser typeser { get; set; }
    }
}

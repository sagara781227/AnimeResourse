namespace AnimeResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animedb.anime")]
    public partial class anime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public anime()
        {
            comments = new HashSet<comment>();
            marks = new HashSet<mark>();
            seriis = new HashSet<serii>();
            users_anime = new HashSet<users_anime>();
            types = new HashSet<type>();
        }

        [Key]
        public int id_anime { get; set; }

        [Required]
        [StringLength(150)]
        public string nameanim { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string about { get; set; }

        [StringLength(20)]
        public string year { get; set; }

        public int? kolser { get; set; }

        public int? kolova { get; set; }

        public int? kolmov { get; set; }

        public int? kolsp { get; set; }

        public int? id_sound { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string image { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mark> marks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<serii> seriis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users_anime> users_anime { get; set; }

        public virtual sound sound { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<type> types { get; set; }
    }
}

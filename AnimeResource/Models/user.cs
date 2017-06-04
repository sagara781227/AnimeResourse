namespace AnimeResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animedb.users")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            comments = new HashSet<comment>();
            marks = new HashSet<mark>();
            users_anime = new HashSet<users_anime>();
        }

        [Key]
        public int id_user { get; set; }

        [Required]
        
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [StringLength(20)]
        public string pasword { get; set; }

        [Required]
        [StringLength(80)]
        public string e_mail { get; set; }

        public bool? confirmed { get; set; }

        public int id_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mark> marks { get; set; }

        public virtual profile profile { get; set; }

        public virtual role role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users_anime> users_anime { get; set; }
    }
}

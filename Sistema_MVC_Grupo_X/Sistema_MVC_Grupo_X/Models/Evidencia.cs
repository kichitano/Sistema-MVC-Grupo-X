namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evidencia")]
    public partial class Evidencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evidencia()
        {
            Criterio = new HashSet<Criterio>();
            EvidenciaCriterio = new HashSet<EvidenciaCriterio>();
        }

        [Key]
        public int evidencia_id { get; set; }

        public int semestre_id { get; set; }

        public int modelo_id { get; set; }

        [StringLength(30)]
        public string archivoRuta { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [Required]
        [StringLength(250)]
        public string categoria { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Criterio> Criterio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaCriterio> EvidenciaCriterio { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual Semestre Semestre { get; set; }
    }
}

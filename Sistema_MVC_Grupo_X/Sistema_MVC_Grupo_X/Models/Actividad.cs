namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Actividad")]
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            EvidenciaActividad = new HashSet<EvidenciaActividad>();
        }

        [Key]
        public int actividad_id { get; set; }

        public int semestre_id { get; set; }

        public int criterio_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        [StringLength(250)]
        public string urlactividad { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Semestre Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaActividad> EvidenciaActividad { get; set; }
    }
}

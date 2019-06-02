namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EvidenciaActividad")]
    public partial class EvidenciaActividad
    {
        [Key]
        public int evidenciaactividad_id { get; set; }

        public int evidencia_id { get; set; }

        public int actividad_id { get; set; }

        [Required]
        [StringLength(250)]
        public string archivo { get; set; }

        [Required]
        [StringLength(10)]
        public string tamanio { get; set; }

        [Required]
        [StringLength(10)]
        public string tipo { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Evidencia Evidencia { get; set; }
    }
}

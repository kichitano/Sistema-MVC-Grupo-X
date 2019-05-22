namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("ControlAsignacion")]
    public partial class ControlAsignacion
    {
        [Key]
        public int controlasignacion_id { get; set; }

        public int control_id { get; set; }

        public int docente_id { get; set; }

        public int criterio_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaasignacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaculminacion { get; set; }

        [StringLength(30)]
        public string duracion { get; set; }

        [Required]
        [StringLength(2)]
        public string sustento { get; set; }

        [Required]
        [StringLength(4)]
        public string porcentaje { get; set; }

        [Required]
        [StringLength(30)]
        public string condicion { get; set; }

        [Required]
        [StringLength(250)]
        public string archivo { get; set; }

        [Column(TypeName = "text")]
        public string observacion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Control Control { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Docente Docente { get; set; }
    }
}

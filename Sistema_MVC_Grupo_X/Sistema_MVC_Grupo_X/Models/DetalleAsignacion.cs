namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("DetalleAsignacion")]
    public partial class DetalleAsignacion
    {
        [Key]
        public int detalleasignacion_id { get; set; }

        public int asignacion_id { get; set; }

        public int docente_id { get; set; }

        public int criterio_id { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Asignacion Asignacion { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Docente Docente { get; set; }
    }
}

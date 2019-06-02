namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using System.Web.Script.Serialization;

    [Table("ControlAsignacion")]
    public partial class ControlAsignacion
    {
        [Key]
        public int controlasignacion_id { get; set; }

        public int detalleasignacion_id { get; set; }

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

        public virtual Criterio Criterio { get; set; }

        public virtual DetalleAsignacion DetalleAsignacion { get; set; }

        public virtual Docente Docente { get; set; }
        //-----------------------------------------------------------------//

        //metodo listar
        public List<ControlAsignacion> Listar() //Retorna un collection
        {
            var objControlAsignacion = new List<ControlAsignacion>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objControlAsignacion = db.ControlAsignacion
                        .Include("Control")
                        .Include("Docente")
                        .Include("Criterio")
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objControlAsignacion;
        }

        //metodo obtener
        public ControlAsignacion Obtener(int id) //retorna solo un objeto
        {
            var objControlAsignacion = new ControlAsignacion();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objControlAsignacion = db.ControlAsignacion
                        .Include("Control")
                        .Include("Docente")
                        .Include("Criterio")
                    .Where(x => x.controlasignacion_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objControlAsignacion;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.controlasignacion_id > 0)
                    { //si existe un valor mayor a 0 es x que existe el registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    { //sino existe el registro lo graba (nuevo)
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
        }

        //metodo eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

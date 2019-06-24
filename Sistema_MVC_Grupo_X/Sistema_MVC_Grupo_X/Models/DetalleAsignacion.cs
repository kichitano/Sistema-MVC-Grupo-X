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

        //-----------------------------------------------------------------//

        //metodo listar
        public List<DetalleAsignacion> Listar() //Retorna un collection
        {
            var objDetalleAsignacion = new List<DetalleAsignacion>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objDetalleAsignacion = db.DetalleAsignacion
                        .Include("Asignacion")
                        .Include("Docente")
                        .Include("Criterio")
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetalleAsignacion;
        }

        //metodo obtener
        public DetalleAsignacion Obtener(int id) //retorna solo un objeto
        {
            var objDetalleAsignacion = new DetalleAsignacion();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objDetalleAsignacion = db.DetalleAsignacion
                        .Include("Asignacion")
                        .Include("Docente")
                        .Include("Criterio")
                    .Where(x => x.detalleasignacion_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetalleAsignacion;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.detalleasignacion_id > 0)
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
            catch (Exception ex)
            {
                throw;
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

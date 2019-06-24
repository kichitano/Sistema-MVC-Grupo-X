namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Actividad")]
    public partial class Actividad
    {
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

        //-----------------------------------------------------------------//

        //metodo listar
        public List<Actividad> Listar() //Retorna un collection
        {
            var objActividad = new List<Actividad>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objActividad = db.Actividad
                        .Include("Semestre")
                        .Include("Criterio")
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objActividad;
        }

        //metodo obtener
        public Actividad Obtener(int id) //retorna solo un objeto
        {
            var objActividad = new Actividad();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objActividad = db.Actividad
                        .Include("Semestre")
                        .Include("Criterio")
                    .Where(x => x.actividad_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objActividad;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.actividad_id > 0)
                    { //si existe un valor mayor a 0 es x que existe el registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    { //sino existe el registro lo graba (nuevo)
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    var row = actividad_id;
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

namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Criterio")]
    public partial class Criterio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Criterio()
        {
            Actividad = new HashSet<Actividad>();
            ControlAsignacion = new HashSet<ControlAsignacion>();
            EvidenciaActividad = new HashSet<EvidenciaActividad>();
            EvidenciaCriterio = new HashSet<EvidenciaCriterio>();
            DetalleAsignacion = new HashSet<DetalleAsignacion>();
        }

        [Key]
        public int criterio_id { get; set; }

        public int modelo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_spanish { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_english { get; set; }

        [StringLength(250)]
        public string urlcriterio { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlAsignacion> ControlAsignacion { get; set; }

        public virtual Modelo Modelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaActividad> EvidenciaActividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaCriterio> EvidenciaCriterio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAsignacion> DetalleAsignacion { get; set; }

        //-----------------------------------------------------------------//

        //metodo listar
        public List<Criterio> Listar() //Retorna un collection
        {
            var objCriterio = new List<Criterio>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objCriterio = db.Criterio.Include("Modelo").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCriterio;
        }

        //metodo obtener
        public Criterio Obtener(int id) //retorna solo un objeto
        {
            var objCriterio = new Criterio();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objCriterio = db.Criterio.Include("Modelo")
                    .Where(x => x.criterio_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCriterio;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.modelo_id > 0)
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

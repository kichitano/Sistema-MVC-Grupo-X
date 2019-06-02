namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Evidencia")]
    public partial class Evidencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evidencia()
        {
            EvidenciaCriterio = new HashSet<EvidenciaCriterio>();
            EvidenciaActividad = new HashSet<EvidenciaActividad>();
        }

        [Key]
        public int evidencia_id { get; set; }

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
        public virtual ICollection<EvidenciaCriterio> EvidenciaCriterio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaActividad> EvidenciaActividad { get; set; }
        //-----------------------------------------------------------------//

        //metodo listar
        public List<Evidencia> Listar() //Retorna un collection
        {
            var objSemestre = new List<Evidencia>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objSemestre = db.Evidencia.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //metodo obtener
        public Evidencia Obtener(int id) //retorna solo un objeto
        {
            var objEvidencia = new Evidencia();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEvidencia = db.Evidencia
                    .Where(x => x.evidencia_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidencia;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.evidencia_id > 0)
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

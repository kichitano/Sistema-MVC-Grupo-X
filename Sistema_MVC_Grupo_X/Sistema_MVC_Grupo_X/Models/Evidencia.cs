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
        }

        [Key]
        public int evidencia_id { get; set; }

        public int semestre_id { get; set; }

        public int modelo_id { get; set; }

        public int categoria_id { get; set; }

        [Required]
        [StringLength(100)]
        public string archivo_evidencia { get; set; }

        [StringLength(100)]
        public string descripcion_evidencia { get; set; }

        [Required]
        [StringLength(1)]
        public string estado_evidencia { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual Semestre Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaCriterio> EvidenciaCriterio { get; set; }

        //-----------------------------------------------------------------//

        //metodo listar
        public List<Evidencia> Listar() //Retorna un collection
        {
            var objEvidencia = new List<Evidencia>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEvidencia = db.Evidencia
                        .Include("Semestre")
                        .Include("Modelo")
                        .Include("Categoria")
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidencia;
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
                        .Include("Semestre")
                        .Include("Modelo")
                        .Include("Categoria")
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

namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("EvidenciaCriterio")]
    public partial class EvidenciaCriterio
    {
        [Key]
        public int evidenciaCriterio_id { get; set; }

        public int evidencia_id { get; set; }

        public int criterio_id { get; set; }

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
        //-----------------------------------------------------------------//

        //metodo listar
        public List<EvidenciaCriterio> Listar() //Retorna un collection
        {
            var objEvidenciaCriterio = new List<EvidenciaCriterio>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEvidenciaCriterio = db.EvidenciaCriterio.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaCriterio;
        }

        //metodo obtener
        public EvidenciaCriterio Obtener(int id) //retorna solo un objeto
        {
            var objEvidenciaCriterio = new EvidenciaCriterio();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEvidenciaCriterio = db.EvidenciaCriterio
                    .Where(x => x.evidenciaCriterio_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaCriterio;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.evidenciaCriterio_id > 0)
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

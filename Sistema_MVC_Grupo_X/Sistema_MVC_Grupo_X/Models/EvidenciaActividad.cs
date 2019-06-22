namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("EvidenciaActividad")]
    public partial class EvidenciaActividad
    {
        [Key]
        public int evidenciaactividad_id { get; set; }

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

        public virtual Actividad Actividad { get; set; }

        public virtual Criterio Criterio { get; set; }

        //-----------------------------------------------------------------//

        //metodo listar
        public List<EvidenciaActividad> Listar() //Retorna un collection
        {
            var objEvidenciaActividad = new List<EvidenciaActividad>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEvidenciaActividad = db.EvidenciaActividad
                        .Include("Actividad")
                        .Include("Criterio")
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaActividad;
        }

        //metodo obtener
        public EvidenciaActividad Obtener(int id) //retorna solo un objeto
        {
            var objEvidenciaActividad = new EvidenciaActividad();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEvidenciaActividad = db.EvidenciaActividad
                        .Include("Actividad")
                        .Include("Criterio")
                    .Where(x => x.evidenciaactividad_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaActividad;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.evidenciaactividad_id > 0)
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

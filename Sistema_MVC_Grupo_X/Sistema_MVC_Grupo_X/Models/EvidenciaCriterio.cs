namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Runtime.Serialization;

    [Table("EvidenciaCriterio")]
    public partial class EvidenciaCriterio
    {
        [Key]
        [Column(Order = 0)]
        public int evidencia_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int criterio_id { get; set; }

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
                    objEvidenciaCriterio = db.EvidenciaCriterio
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaCriterio;
        }

        public List<EvidenciaCriterio> ListarPorEvidencia(int evidencia_id) //Retorna un collection
        {
            var objEvidenciaCriterio = new List<EvidenciaCriterio>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEvidenciaCriterio = db.EvidenciaCriterio
                        .Where(x => x.evidencia_id == evidencia_id)
                        .ToList();
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
                    .Where(x => x.evidencia_id == id)
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
        public void Guardar()//EvidenciaCriterio evidenciaCriterio)
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    //db.EvidenciaCriterio.Add(evidenciaCriterio);
                    if (this.evidencia_id > 0)
                    { //si existe un valor mayor a 0 es x que existe el registro
                        db.Entry(this).State = EntityState.Added;

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
        //metodo eliminar2
        public void Eliminar2(int evidencia_id,int criterio_id)
        {
            var objEvidenciaCriterio = new EvidenciaCriterio();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    string query = "delete from EvidenciaCriterio where evidencia_id='"+ evidencia_id+ "' and criterio_id='" + criterio_id + "'";
                    db.Database.ExecuteSqlCommand(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

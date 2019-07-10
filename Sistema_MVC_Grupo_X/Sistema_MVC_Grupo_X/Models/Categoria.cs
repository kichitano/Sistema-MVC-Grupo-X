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

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Evidencia = new HashSet<Evidencia>();
        }

        [Key]
        public int categoria_id { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion_categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evidencia> Evidencia { get; set; }

        //-----------------------------------------------------------------//

        //metodo listar
        public List<Categoria> Listar() //Retorna un collection
        {
            var objCategoria = new List<Categoria>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objCategoria = db.Categoria
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCategoria;
        }

        //metodo obtener
        public Categoria Obtener(int id) //retorna solo un objeto
        {
            var objCategoria = new Categoria();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objCategoria = db.Categoria
                    .Where(x => x.categoria_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCategoria;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.categoria_id > 0)
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

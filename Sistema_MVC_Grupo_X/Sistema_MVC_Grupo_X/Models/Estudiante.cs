namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int estudiante_id { get; set; }

        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int estudiante_codigo { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(250)]
        public string direccion { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }
        public List<Estudiante> Listar()
        {
            var objEstudiante = new List<Estudiante>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEstudiante = db.Estudiante.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEstudiante;
        }
        //Metodo Obtener
        public Estudiante Obtener(int id) //retorna solo un objeto
        {
            var objEstudiante = new Estudiante();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objEstudiante = db.Estudiante
                    .Where(x => x.estudiante_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEstudiante;
        }

        //Metodo Guardar y Modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.estudiante_id > 0)
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

        //Metodo Eliminar
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

namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using Helper;
    
    [Table("Estudiante")]
    public partial class Estudiante: IValidatableObject
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
        [MaximaCantidadPalabras(2)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        [MaximaCantidadPalabras(2)]
        public string nombre { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(250)]
        public string direccion { get; set; }

        [StringLength(15)]
        [RegularExpression("[0-9]{3}?\\[0-9]{3}?\\[0-9]{3}")]
        public string celular { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }
        //-----------------------------------------------------------------//
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (estado == null && foto == null)
            {
                yield return new ValidationResult("No, puedes dejar tantos campos vacios");
            }
        }
        //metodo listar
        public List<Estudiante> Listar() //Retorna un collection
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

        //metodo obtener
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
        //metodo guardar y modificar
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

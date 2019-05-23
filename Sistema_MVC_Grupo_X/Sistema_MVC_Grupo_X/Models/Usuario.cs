namespace Sistema_MVC_Grupo_X.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int docente_id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string clave { get; set; }

        [Required]
        [StringLength(20)]
        public string nivel { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Docente Docente { get; set; }

        //-----------------------------------------------------------------//
        //metodo listar
        public List<Usuario> Listar() //Retorna un collection
        {
            var objUsuario = new List<Usuario>();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objUsuario = db.Usuario.Include("Docente").ToList();        //      INCLUDE PARA TABLAS RELACIONADAS
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }

        //metodo obtener
        public Usuario Obtener(int id) //retorna solo un objeto
        {
            var objUsuario = new Usuario();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    objUsuario = db.Usuario.Include("Docente")      //  INNER JOIN PARA TABLAS RELACIONADAS
                    .Where(x => x.usuario_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }
        //metodo guardar y modificar
        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    if (this.usuario_id > 0)
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

        //metodo validar login
        public ResponseModel validarLogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new Modelo_Sistema())
                {
                    Password = HashHelper.SHA1(Password);

                    var usuario = db.Usuario.Where(x => x.nombre == Usuario)
                                            .Where(x => x.clave == Password)
                                            .SingleOrDefault();
                    if(usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.usuario_id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false,"Usuario o Password incorrectos...");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rm;
        }
    }
}

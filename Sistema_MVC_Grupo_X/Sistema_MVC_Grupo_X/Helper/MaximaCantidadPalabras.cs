using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_MVC_Grupo_X.Helper
{
    public class MaximaCantidadPalabras : ValidationAttribute
    {
        private readonly int _maximaCantidadPalabras;
        public MaximaCantidadPalabras(int maximaCantidadPalabras) 
            :base("{0} exceso de cantidad de palabras")
        {
            _maximaCantidadPalabras = maximaCantidadPalabras;
        }
        protected override ValidationResult IsValid(object valor, ValidationContext validationContext)
        {
            if(valor != null)
            {
                var valorComoCadena = valor.ToString();
                if(valorComoCadena.Split(' ').Length > _maximaCantidadPalabras)
                {
                    var errorMensaje = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMensaje);
                }
            }
            return ValidationResult.Success;
        }
    }
}
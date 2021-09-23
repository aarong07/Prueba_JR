using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Prueba_JR.Models.modelos
{
    public class producto
    {
        [Display (Name = "")]
        public int Id_prod { get; set; }
        [StringLength(15)]
        [Required]
        [Display(Name = "Nombre del Producto")]
        public string ProdNombre { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Descripcion del Producto")]
        public string ProdDescripcion { get; set; }
        [Required]
        public int Id_cat { get; set; }
        [Display(Name = "Categoria")]
        public string CatNombre { get; set; }
        //public List<Productos> CategoriasList { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;

namespace PWABlog.Models.Blog.Categoria
{
    public class CategoriaEntity
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]public int Id { get; set; }

        [MaxLength(128)] [Required] public string Nome { get; set; }
        
        public ICollection<PostagemEntity> Postagens { get; set; }

        [CascadingParameter]
        public ICollection<EtiquetaEntity> Etiquetas { get; set; }


        public CategoriaEntity()
        
        {
            Postagens = new List<PostagemEntity>();
            Etiquetas = new List<EtiquetaEntity>();
        }
    }
}
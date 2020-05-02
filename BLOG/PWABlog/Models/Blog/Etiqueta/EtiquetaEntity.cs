using PWABlog.Models.Blog.Postagem;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PWABlog.Models.Blog.Categoria;

namespace PWABlog.Models.Blog.Etiqueta
{
    public class EtiquetaEntity
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [MaxLength(128)] [Required] public string Nome { get; set; }

        [Required] public CategoriaEntity Categoria { get; set; }

        public List<PostagemEtiquetaEntity> PostagensEtiquetas { get; set; }

        public EtiquetaEntity()
        {
            PostagensEtiquetas = new List<PostagemEtiquetaEntity>();
        }
    }
}

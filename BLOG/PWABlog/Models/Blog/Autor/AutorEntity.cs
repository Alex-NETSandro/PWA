using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PWABlog.Models.Blog.Autor
{
    public class AutorEntity
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]public int Id { get; set; }

        [MaxLength(128)][Required] public string Nome { get; set; }
    }
}

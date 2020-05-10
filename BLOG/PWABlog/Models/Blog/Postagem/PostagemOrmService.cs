using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PWABlog.Models.Blog.Postagem
{
    public class PostagemOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEntity> ObterPostagens()
        {
            return _databaseContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisoes)
                .Include(p=>p.Autor)
                .Include(p => p.Comentarios)
                .ToList();
        }

        public List<PostagemEntity> ObterPostagensPopulares()
        {
            return _databaseContext.Postagens.Include(p => p.Categoria).ToList();
        }
        
        public PostagemEntity ObterPostagemPorId(int idPostagem)
        {
            var postagem = _databaseContext.Postagens.Find(idPostagem);

            return postagem;
        }
        public PostagemEntity AddPostagem(PostagemEntity postagem)
        {
            var post = new PostagemEntity();
            post = postagem;
            _databaseContext.Postagens.Add(post);
            _databaseContext.SaveChanges();

            return post;
        }
        public async Task<PostagemEntity> AsyncAddPostagem(PostagemEntity postagem)
        {
            var post = new PostagemEntity();
            post = postagem; 
            _databaseContext.Postagens.AddAsync(post);
            _databaseContext.SaveChangesAsync();
            return post;
        }

        public PostagemEntity UpdatePostagem(PostagemEntity post)
        {
            var postagem = _databaseContext.Postagens.Where(c => c.Id == post.Id).FirstOrDefault();
            postagem = post;
            _databaseContext.Postagens.Update(postagem);
            _databaseContext.SaveChanges();
            return postagem;
        }
        public PostagemEntity RemovePostagem(int id)
        {
            var post = _databaseContext.Postagens.Find(id);
            _databaseContext.Postagens.Remove(post);
            _databaseContext.SaveChanges();
            return post;
        }
    }
}
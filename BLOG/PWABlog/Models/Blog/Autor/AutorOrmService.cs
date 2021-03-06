﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.Models.Blog.Autor
{
    public class AutorOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public AutorOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<AutorEntity> ObterAutores()
        {
            // INÍCIO DOS EXEMPLOS
            
            /**********************************************************************************************************/
            /*** OBTER UM ÚNICO OBJETO                                                                                */
            /**********************************************************************************************************/
            
            // First = Obter a primeira categoria retornada pela consulta
            //var primeiraCategoria = _databaseContext.Categorias.First();
            
            // FirstOrDefault = Mesmo do First, porém retorna nulo caso não encontre nenhuma
            var primeiroAutorOuNulo = _databaseContext.Autores.FirstOrDefault();
            
            // Single = Obter um único registro do banco de dados
           // var algumaCategoriaEspecifica = _databaseContext.Categorias.Single(c => c.Id == 3);
            
            // SingleOrDefault = Mesmo do Sigle, porém retorna nulo caso não encontre nenhuma
            var algumAutorOuNulo = _databaseContext.Autores.SingleOrDefault(c => c.Id == 3);
            
            // Find = Equivalente ao SingleOrDefault, porém fazendo uma busca por uma propriedade chave
            var encontrarAutor = _databaseContext.Autores.Find(3);
            
            
            /**********************************************************************************************************/
            /*** OBTER MÚLTIPLOS OBJETOS                                                                              */
            /**********************************************************************************************************/
     
            // ToList
            var todosAutores = _databaseContext.Autores.ToList();
            
            
            /***********/
            /* FILTROS */
            /***********/

            var autoresComALetraG = _databaseContext.Autores.Where(c => c.Nome.StartsWith("G")).ToList();
            var autoresComALetraMouL = _databaseContext.Autores
                .Where(c => c.Nome.StartsWith("M") || c.Nome.StartsWith("L"))
                .ToList();
            
            
         
            /*************/
            /* ORDENAÇÃO */
            /*************/

            var autoresEmOrdemAlfabetica = _databaseContext.Autores.OrderBy(c => c.Nome).ToList();
            var autoresEmOrdemAlfabeticaInversa = _databaseContext.Autores.OrderByDescending(c => c.Nome).ToList();
            
            
            /**************************/
            // FIM DOS EXEMPLOS
            
            
            
            // Código de fato necessário para o método
            return _databaseContext.Autores
                .ToList();
        }

        public AutorEntity ObterAutorPorId(int idAutor)
        {
            var autor = _databaseContext.Autores.Find(idAutor);

            return autor;
        }

        public List<AutorEntity> PesquisarAutorPorNome(string nomeAutor)
        {
            return _databaseContext.Autores.Where(c => c.Nome.Contains(nomeAutor)).ToList();
        }
        
        public AutorEntity AddAutor(string nomeAutor)
        {
            var autor = new AutorEntity{Nome=nomeAutor};
            _databaseContext.Autores.Add(autor);
            _databaseContext.SaveChanges();

            return autor;
        }

        public AutorEntity UpdateAutor(AutorEntity author)
        {
            var aut = _databaseContext.Autores.Where(c => c.Id == author.Id).FirstOrDefault();
            aut.Id = author.Id;
            aut.Nome = author.Nome;
            _databaseContext.Autores.Update(aut);
            _databaseContext.SaveChanges();
            return aut;
        }
        public AutorEntity RemoveAutor(int id)
        {
            var author = _databaseContext.Autores.Find(id);
            _databaseContext.Autores.Remove(author);
            _databaseContext.SaveChanges();
            return author;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BibliotecaApiGoogleBooks.DTO;
using BibliotecaApiGoogleBooks.Models;
using BibliotecaApiGoogleBooks.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BibliotecaApiGoogleBooks.Controllers
{
    [Produces("application/json", "text/plain")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILivroRepository _repository;

        public LivrosController(IConfiguration config, ILivroRepository repository)
        {
            _config = config;
            _repository = repository;
        }

        /// <summary>
        /// Retona o livros api google books.
        /// </summary>
        /// <param name="stringPesquisa"></param>
        /// <returns></returns>
        [HttpGet("BuscaLivro/{stringPesquisa}")]
        public async Task<IActionResult> BuscaLivro(string stringPesquisa)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri urlRequisicao = new Uri(_config.GetSection("Urls").GetSection("UrlBase").Value + _config.GetSection("Urls").GetSection("PesquisaLivro").Value + stringPesquisa);
                HttpResponseMessage responseMessage = await client.GetAsync(urlRequisicao);
                string response = await responseMessage.Content.ReadAsStringAsync();

                List<ResponseLivroDTO> listaLivrosDTO = new List<ResponseLivroDTO>();
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ResponseLivroDTO livrosResponse = JsonConvert.DeserializeObject<ResponseLivroDTO>(response);

                    if (livrosResponse != null)
                    {
                        List<Livro> listaLivros = new List<Livro>();

                        foreach (var l in livrosResponse.items)
                        {
                            Livro livro = new Livro()
                            {
                                Id = l.id,
                                Titulo = !(l.volumeInfo.description is null) ? l.volumeInfo.title : "",
                                Descricao = !(l.volumeInfo.description is null) ? l.volumeInfo.description : "",
                                Etag = !(l.etag is null) ? l.etag : "",
                                CapaLivro = !(l.volumeInfo.imageLinks is null) ? l.volumeInfo.imageLinks.thumbnail : null,
                            };

                            if (l.volumeInfo.categories != null)
                                foreach (var c in l.volumeInfo.categories)
                                {
                                    livro.Categorias += c + " ";
                                }

                            if (l.volumeInfo.authors != null)
                                foreach (var a in l.volumeInfo.authors)
                                {
                                    livro.Autores += a + " ";
                                }

                            listaLivros.Add(livro);
                        }

                        return Ok(listaLivros);
                    }
                    return NoContent();
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Favorita livro.
        /// </summary>
        /// <param name="livro"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> AdicionaLivroFavorito([FromBody] Livro livro)
        {
            try
            {
                bool cadastrado = false;
                List<Livro> livros = (List<Livro>)_repository.Livros;

                foreach (var item in livros)
                {
                    if (item.Id.Equals(livro.Id))
                    {
                        cadastrado = true;
                        break;
                    }
                }

                if (!cadastrado)
                {
                    _repository.SalvarLivroFavorito(livro);

                    return Ok();
                }

                return UnprocessableEntity("Esse livro já está favoritado! :)");
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Litas todos os Livros favoritados na base.
        /// </summary>
        /// <returns></returns>
        [HttpGet("LivrosFavoritos")]
        public async Task<IActionResult> ListaLivrosFavoritos()
        {
            try
            {
                List<Livro> livros = (List<Livro>)_repository.Livros;

                if (livros != null && livros.Count > 0)
                    return Ok(livros);

                return NoContent();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Remove livro da lista de livros favoritados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("RemoverLivro/{id}")]
        public async Task<IActionResult> RemoverLivroFavorito(string id)
        {
            try
            {
                Livro livro = _repository.GetByID(id);
                _repository.ExcluirLivro(livro);

                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}

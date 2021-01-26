using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api")]
    public class AutorController : ControllerBase
    {
        private readonly NoticiaDBContext _noticiaDbContext;
        public AutorController(NoticiaDBContext noticiaDbContext)
        {
            _noticiaDbContext = noticiaDbContext;
        }

        [HttpGet]
        [Route("Autor")]
        public List<Autor> ListaTodo(){
            var autor = _noticiaDbContext.Autor.ToList();
            return autor;
        }

        [HttpGet]
        [Route("Autor/{id}")]
        public List<Autor> ListaAutor(int id){
            var autor = _noticiaDbContext.Autor.Where(y => y.AutorID == id).ToList();
            return autor;
        }
    }
}
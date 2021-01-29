using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("Noticia")]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaDBContext _noticiaDbContext;
        public NoticiaController(NoticiaDBContext noticiaDbContext)
        {
            _noticiaDbContext = noticiaDbContext;
        }

        [HttpGet]
        public List<Noticia> ListarTodo()
        {
            var noticia = _noticiaDbContext.Noticia.Include(n => n.A).ToList();
            return noticia;
        }

        [HttpGet]
        [Route("{id}")]
        public List<Noticia> ListarNoticia(int id)
        {
            var noticia = _noticiaDbContext.Noticia.Include(n => n.A).Where(n => n.NoticiaID == id).ToList();
            return noticia;
        }

        [HttpGet]
        [Route("Autor/{id}")]
        public List<Noticia> ListarTodoPorAutor(int id)
        {
            var noticia = _noticiaDbContext.Noticia.Include(n => n.A).Where(n => n.AutorID == id).ToList();
            return noticia;
        }

        [HttpPost]
        public ActionResult Registrar(Noticia n)
        {
            _noticiaDbContext.Noticia.Add(n);
            _noticiaDbContext.SaveChanges();
            return Ok(new
            {
                Status = 1,
                Message = "Noticia registrada",
                Noticia = n
            });
        }

        [HttpDelete]
        public ActionResult Delete(Noticia n)
        {
            try
            {
                _noticiaDbContext.Noticia.Remove(n);
                _noticiaDbContext.SaveChanges();
                return Ok(new
                {
                    Status = 1,
                    Message = "Noticia eliminada"
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Status = 0,
                    Message = "No se pudo eliminar",
                    Detail = ex.Message
                });
            }
        }

        [HttpPut]
        public ActionResult Update(Noticia n)
        {
            try
            {
                _noticiaDbContext.Entry(n).State = EntityState.Modified;
                _noticiaDbContext.SaveChanges();
                return Ok(new
                {
                    Status = 1,
                    Message = "Noticia actualizada"
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Status = 0,
                    Message = "No se pudo actualizar",
                    Detail = ex.Message
                });
            }
        }
    }
}
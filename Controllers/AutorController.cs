using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("autor")]
    public class AutorController : ControllerBase
    {
        private readonly NoticiaDBContext _noticiaDbContext;
        public AutorController(NoticiaDBContext noticiaDbContext)
        {
            _noticiaDbContext = noticiaDbContext;
        }

        [HttpGet]
        public List<Autor> ListaTodo()
        {
            var autor = _noticiaDbContext.Autor.ToList();
            return autor;
        }

        [HttpGet]
        [Route("{id}")]
        public List<Autor> ListaAutor(int id)
        {
            var autor = _noticiaDbContext.Autor.Where(y => y.AutorID == id).ToList();
            return autor;
        }

        [HttpPost]
        public ActionResult Registrar(Autor a)
        {
            try
            {
                _noticiaDbContext.Autor.Add(a);
                _noticiaDbContext.SaveChanges();
                return Ok(new
                {
                    Status = 1,
                    Message = "Autor registrado",
                    Autor = a
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Status = 0,
                    Message = "No se pudo registrar",
                    Detail = ex.Message
                });
            }
        }

        [HttpPut]
        public ActionResult Update(Autor a)
        {
            try
            {
                _noticiaDbContext.Entry(a).State = EntityState.Modified;
                _noticiaDbContext.SaveChanges();
                return Ok(new
                {
                    Status = 1,
                    Message = "Autor actualizado",
                    Autor = a
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

        [HttpDelete]
        public ActionResult Delete(Autor a)
        {
            try
            {
                _noticiaDbContext.Autor.Remove(a);
                _noticiaDbContext.SaveChanges();
                return Ok(new
                {
                    Status = 1,
                    Message = "Eliminado con Exito"
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
    }
}
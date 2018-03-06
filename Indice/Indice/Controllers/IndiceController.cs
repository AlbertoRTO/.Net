using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indice.Repositorio;
using Indice.Models;

namespace Indice.Controllers
{
    public class IndiceController : Controller
    {
        // GET: Indice

        private UsuarioRepositorio _repostorio;


        [HttpGet]
        public ActionResult ObterUsuarios()
        {
            _repostorio = new UsuarioRepositorio();


            _repostorio.ObterUsuarios();
            ModelState.Clear();
            
            return View(_repostorio.ObterUsuarios());
        }

        [HttpGet]
        public ActionResult IncluirUsuario()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Incluirusuario(Usuarios usuarioObj )
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _repostorio = new UsuarioRepositorio();

                    if (_repostorio.AdicionarUsuario(usuarioObj))
                    {
                        ViewBag.Mensagem = "Usuario cadastrado com sucesso ";
                    }
                }

                return View();
            }

            catch (Exception)
            {
                 return View("ObterUsuarios"); 
            }
        }



        [HttpGet]
        public ActionResult EditarUsuario(int id)
        {
            _repostorio = new UsuarioRepositorio();
            return View(_repostorio.ObterUsuarios().Find(t => t.UsuariosId == id));

        }

        [HttpPost]
        public ActionResult EditarUsuario(int id, Usuarios usuarioObj)
        {
           try
            {
                _repostorio = new UsuarioRepositorio();
                _repostorio.AdicionarUsuario(usuarioObj);
                return RedirectToAction("ObterUsuarios");
            }

            catch (Exception)
            {
                return View("ObterUsuarios");
            }
        }


        public ActionResult ExcluirUsuario (int id )

        {
            try
            {
                _repostorio = new UsuarioRepositorio();
                if(_repostorio.ExluirUsuario(id))
                {
                    ViewBag.Mensagem = "Usuario excluido com sucesso";
                }

                return RedirectToAction("ObterUsuarios"); 
            }

            catch (Exception)
            {
                return View("ObterUsuarios");
            }
        }

    }
}
using LogicaNegocio.Dominio;
using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.VOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioUsuarios : IRepositorioUsuarios {
        public LibreriaContext Contexto { get; set; }

        public RepositorioUsuarios(LibreriaContext ctx) {
            Contexto = ctx;
        }

        public Usuario Login(string email, string password) {
            MailUsuario mailUsuario = new MailUsuario(email);
            if(mailUsuario == null) {
                throw new Exception("Mail Inválido");
            }
            return Contexto.Usuarios
                            .Where(usu => usu.Mail.Value == mailUsuario.Value && usu.PasswordEncrypted == password)
                            .SingleOrDefault();
        }

        public bool EsValidoMailUsuario(string mail) {
            MailUsuario mailUsuario = new MailUsuario(mail);
            return !Contexto.Usuarios.Any(usu => usu.Mail == mailUsuario);
        }
        public void Add(Usuario item) {
            bool correoExistente = Contexto.Set<Usuario>().Any(u => u.Mail.Value == item.Mail.Value);
            if (correoExistente) {
                throw new DatosInvalidosException("Ya existe un Usuario con el mismo correo electrónico.");
            }
            Contexto.Add(item);
            Contexto.SaveChanges();
        }
        public List<Usuario> FindAll() {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id) {
            return Contexto.Usuarios
                .Where(usu => usu.Id == id)
                .SingleOrDefault();
        }


        public void Remove(int id) {
            Usuario aBorrar = FindById(id);
            if (aBorrar != null) {
                Contexto.Usuarios.Remove(aBorrar);
                Contexto.SaveChanges();
            } else {
                throw new NotFoundException("No existe un usuario con ésta ID");
            }
        }

        public void Update(Usuario item) {
            Contexto.Usuarios.Update(item);
            Contexto.SaveChanges();
        }
        public Usuario FindByMail(string mail) {
            Usuario user = Contexto.Usuarios
                .Where(art => art.Mail.Value.Equals(mail))
                .SingleOrDefault();
            return user;
        }
    }
}

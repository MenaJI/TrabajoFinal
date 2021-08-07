using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.DTOs;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IUsuariosService
    {
        List<Usuarios> GetAll();
        Task<TokenModel> Login(Login_DTO model);
        Task<Response> RegistrarUsuario(Registro_DTO model);
        void BorrarUsuario(Usuario_DTO usuario);
    }
}
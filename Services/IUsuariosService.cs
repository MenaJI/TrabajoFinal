using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;


namespace ApiREST.Services
{
    public interface IUsuariosService
    {
        List<Usuarios> GetAll();
        Task<TokenModel> Login(LoginModel model);
        Task<Response> RegistrarUsuario(RegistroModel model, string rol);
        void BorrarUsuario(UsuarioModel usuario);
        Task<bool> VerificarUsuario(string userCode);
    }
}
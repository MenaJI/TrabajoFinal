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
        Task<Response> RegistrarUsuario(RegistroModel registroModel);
        void EditarUsuario(Usuarios usuario);
        void BorrarUsuario(Usuarios usuario);
        void SaveChanges();
    }
}
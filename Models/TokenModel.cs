using System;

namespace ApiREST.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
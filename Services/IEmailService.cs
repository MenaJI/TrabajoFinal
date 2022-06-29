using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;


namespace ApiREST.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
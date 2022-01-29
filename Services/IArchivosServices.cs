using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IArchivosServices : IBaseServices<Archivos>
    {
        Archivos Insert(ArchivoModel model);
        ArchivoModel ObtenerArchivo(string tipoArchivo, string AlumnoUserName);
        ArchivoModel MapearArchivoModel(Archivos model);
        void UpdateArchivo(ArchivoModel model);
    }
}

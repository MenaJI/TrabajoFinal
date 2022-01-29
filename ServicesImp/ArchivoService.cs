using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class ArchivoService : BaseServicesImp<Archivos>, IArchivosServices
    {
        public SecurityDbContext dataProvider;

        public ArchivoService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }

        public Archivos Insert(ArchivoModel model)
        {
            var result = dataProvider.Archivos.FirstOrDefault(a => a.AlumnoUserName == model.AlumnoUserName && a.TipoArchivo == model.TipoArchivo);

            if (result != null)
            {
                result.FileBase64 = model.Base64;
                result.Nombre = model.Nombre;
                Update(result);
                return result;
            }

            var alumno = new Archivos()
            {
                Nombre = model.Nombre,
                TipoArchivo = model.TipoArchivo,
                FileBase64 = model.Base64,
                AlumnoUserName = model.AlumnoUserName
            };

            dataProvider.Archivos.Add(alumno);
            dataProvider.SaveChanges();
            return alumno;
        }

        public void UpdateArchivo(ArchivoModel model)
        {
            var archivo = Get(a => a.AlumnoUserName == model.AlumnoUserName && a.TipoArchivo == model.TipoArchivo, "").FirstOrDefault();

            archivo.FileBase64 = model.Base64;
        }

        public ArchivoModel ObtenerArchivo(string tipoArchivo, string AlumnoUserName)
        {
            var result = dataProvider.Archivos.FirstOrDefault(a => a.AlumnoUserName == AlumnoUserName && a.TipoArchivo == tipoArchivo);
            return MapearArchivoModel(result);
        }

        public ArchivoModel MapearArchivoModel(Archivos model)
        {
            if (model == null)
                return null;
            var result = new ArchivoModel()
            {
                Nombre = model.Nombre,
                TipoArchivo = model.TipoArchivo,
                Base64 = model.FileBase64,
                AlumnoUserName = model.AlumnoUserName
            };

            return result;
        }
    }
}
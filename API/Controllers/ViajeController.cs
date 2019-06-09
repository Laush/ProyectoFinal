using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Services;
using Genericas;

namespace API.Controllers
{
    public class ViajeController : ApiController
    {
        private TokenManager TokenManager = new TokenManager();
        [HttpPost]
        public HttpResponseMessage alta(ViajeRequestModel RequestModel)
        {
            Viaje NuevoViaje = new Viaje();
            string JwtToken = Request.Headers.First(h => h.Key == "Authorization").Value.First();
            long IdUsuario = TokenManager.GetUserId(JwtToken);

            NuevoViaje.Aerolinea = RequestModel.Aerolinea;
            NuevoViaje.Alojamiento = RequestModel.Alojamiento;
            NuevoViaje.FechaDesde = RequestModel.FechaDesde;
            NuevoViaje.FechaHasta = RequestModel.FechaHasta;
            NuevoViaje.IdDestino = RequestModel.Destino;
            NuevoViaje.IdOrigen = RequestModel.Origen;
            NuevoViaje.IdUsuario = IdUsuario;
            NuevoViaje.InteresActividades = RequestModel.InteresActividades;
            NuevoViaje.InteresAlojamiento= RequestModel.InteresAlojamiento;
            NuevoViaje.InteresAmistades = RequestModel.InteresAmistades;
            NuevoViaje.InteresExcursiones = RequestModel.InteresExcursiones;
            NuevoViaje.InteresOtros = RequestModel.InteresOtros;
            NuevoViaje.InteresTraslados = RequestModel.InteresTraslados;

            return null;
        }
    }
}

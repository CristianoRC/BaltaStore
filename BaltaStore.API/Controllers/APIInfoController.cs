using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.API.Controllers
{
    public class APIInfoController : Controller
    {
        //Controller criada para teste de Cache


        /*[ResponseCache(Location = ResponseCacheLocation.Client ,Duration = 60)]
        *
        *  Cache no lado do Cliente, requisição não chega no server;
        *  Cache apenas em dados que não mutam muito;
        *
        */
 
        [HttpGet]
        [Route("v1/info")]
        [ResponseCache(Duration = 60)] //1h
        public object GetInfo()
        {
            return new
            {
                Version = "1.0",
                Developer = "Cristiano Raffi Cunha"
            };
        }
    }
}
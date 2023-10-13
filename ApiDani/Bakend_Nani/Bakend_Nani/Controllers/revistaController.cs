using Bakend_Nani.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;

namespace Bakend_Nani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class revistaController : ControllerBase
    {
        private IConfiguration _Config;

        public revistaController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Revista>>> Getrevista()
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var orevista = conexion.Query<Revista>("MosRevista", commandType: System.Data.CommandType.StoredProcedure);
            return Ok(orevista);
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Revista>>> GetrevistaId(int revistaId)
        {


            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", revistaId);
            var orevista = conexion.Query<Revista>("MosRevista", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(orevista);
        }
        [HttpPost]
        public async Task<ActionResult<List<Revista>>> InsertRevista(Revista rev)
        {
            {
                using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
                conexion.Open();
                var param = new DynamicParameters();
                param.Add("@numero", rev.numero);
                param.Add("@titulo", rev.titulo);
                param.Add("@ayo", rev.ayo);
                param.Add("@inss", rev.inss);
                param.Add("@precio", rev.precio);
                param.Add("@Horaventa", rev.Horaventa);
                var oRevista = conexion.Query<Revista>("InRevista", param, commandType: System.Data.CommandType.StoredProcedure)
                .SingleOrDefault();
                return Ok(oRevista);
            }
        }

        [HttpPut]
            public async Task<ActionResult<List<Revista>>> ActRevista(Revista rev)
            {
                using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
                conexion.Open();
                var param = new DynamicParameters();
                param.Add("@numero", rev.numero);
                param.Add("@titulo", rev.titulo);
                param.Add("@ayo", rev.ayo);
                param.Add("@inss", rev.inss);
                param.Add("@precio", rev.precio);
                param.Add("@Horaventa", rev.Horaventa);
                var oRevista = conexion.Query<Revista>("UpdRevista", param, commandType: System.Data.CommandType.StoredProcedure)
                .SingleOrDefault();
                return Ok(oRevista);
            }
           /* [HttpDelete("{ID}")]
            public async Task<ActionResult<List<Revista>>> Delrevista(int revistaId)
            {
                using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
                conexion.Open();
                var param = new DynamicParameters();
                param.Add("@id", revistaId);
                var oRevista = conexion.Query<Revista>("DeJugador", param, commandType: System.Data.CommandType.StoredProcedure)
                .SingleOrDefault();
                return Ok(oRevista);
            }*/
            [HttpDelete("{ID}")]
            public async Task<ActionResult<List<Revista>>> DelRevista(int RevistaId)
            {
                using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
                conexion.Open();
                var param = new DynamicParameters();
                param.Add("@id", RevistaId);
                var oRevista = conexion.Query<Revista>("DelRevista", param, commandType: System.Data.CommandType.StoredProcedure)
                .SingleOrDefault();
                return Ok(oRevista);
            }

        }
    }


    


using ApiRecibo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using System.Transactions;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace ApiRecibo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NombreClase : ControllerBase
    {

        "ConnectionStrings": {
        "DefaultConnection": "Server=DESKTOP-CQ049J0\\MSSQLSERVER01;Database=pruebas;Trusted_Connection=True;"
        }
         
        private readonly string _configuration;

        public constructor(IConfiguration configuration )
        {
          _configuration= configuration.GetConnectionString("DefaultConnection");

        }
        //public IActionResult Index()
        //{
        //    return View();

        //}

          public static string EncriptarContrasena(string contrasena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contrasena);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Función para comparar una contraseña encriptada con una contraseña no encriptada
        public static bool CompararContrasenas(string contrasenaEncriptada, string contrasenaNoEncriptada)
        {
            string contrasenaEncriptadaUsuario = EncriptarContrasena(contrasenaNoEncriptada);
            return contrasenaEncriptada == contrasenaEncriptadaUsuario;
        }


        [HttpPost("NombreRuta")]

        public async Task<IActionResult> NombreMetodo([FromBody] NombreClaseModelo objeto)
        {

            using (var conn = new SqlConnection(_configuration))
            {
                await conn.OpenAsync();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var NombreVariableDetalle = new DataTable();
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(string));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(string));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(string));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(DateTime));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(int));

                        foreach (var nombreDetalle in objeto.nombreDetalleEnModelo)
                        {
                            NombreVariableDetalle.Rows.Add(nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo);
                        }

                        var parameters = new DynamicParameters();
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", NombreVariableDetalle.AsTableValuedParameter("nombreDeTipoTabla"));
                        await conn.ExecuteAsync(
                            "NombreProcedimientoEnBD",
                            parameters,
                            transaction,
                            commandType: CommandType.StoredProcedure);
                        transaction.Commit();
                        return Ok();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    }
                }

            }

        }



        [HttpPut("{id}",Name ="NombreRuta")]

        public async Task<IActionResult> NombreMetodo(int id, [FromBody] Clase objeto)
        {
            

                using (var conn=new SqlConnection(_configuration))
                {
                    await conn.OpenAsync();
                    using (var transaction = conn.BeginTransaction())
                    {
                    try
                    {
                        var NombreVariableDetalle = new DataTable();
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(string));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(string));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(string));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(DateTime));
                        NombreVariableDetalle.Columns.Add("noombreColumnaEnBD", typeof(int));

                        foreach (var nombreDetalle in objeto.nombreDetalleEnModelo)
                        {
                            NombreVariableDetalle.Rows.Add(nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo, nombreDetalle.NombreEnModelo);
                        }

                        
                        var parameters = new DynamicParameters();
                        parameters.Add("@id", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", NombreVariableDetalle.AsTableValuedParameter("nombreDeTipoTabla"));
                        await conn.ExecuteAsync(
                            "NombreProcedimientoEnBD",
                            parameters,
                            transaction,
                            commandType: CommandType.StoredProcedure);
                        transaction.Commit();
                        return Ok();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                    }

                    }

                }

            
           
            }


            [HttpGet("nombreRuta")]

            public async Task<IActionResult> NombreMetodo()
            {
                using (var conn= new SqlConnection(_configuration))
                {
                    await conn.OpenAsync();
                    var parameters = new DynamicParameters();
                    var results = await conn.QueryAsync<Empleado>("NombreMetodo", parameters, commandType: CommandType.StoredProcedure);
                    return Ok(results);
                }
            }


        [HttpPost("NuevoUsuario")]

        public async Task<IActionResult> NuevoUsuario([FromBody] Usuario usuario)
        {

            using (var conn = new SqlConnection(_configuration))
            {
                await conn.OpenAsync();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string contrasenaEncriptada = EncriptarContrasena(usuario.contrasena);                    
                        var parameters = new DynamicParameters();
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);
                        parameters.Add("@parametroEnBD", objeto.propiedad);                                           
                        await conn.ExecuteAsync(
                            "nombreMetodo",
                            parameters,
                            transaction,
                            commandType: CommandType.StoredProcedure);
                        transaction.Commit();
                        return Ok();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); 
                        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    }
                }

            }

        }


         [HttpPost("InicioSesion")]

        public async Task<IActionResult> InicioSesion([FromBody] InicioSesion usuario)
        {

            string consulta = "select contrasena,usuarioID from usuarios where correo=@correo";

            using (SqlConnection conn=new SqlConnection(_configuration))
            {
                SqlCommand command = new SqlCommand(consulta, conn);
                command.Parameters.AddWithValue("@correo", usuario.correo);
                try
                {
                    await conn.OpenAsync();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string contrasenaObtenida=reader.GetString(0).Trim();
                        int usuarioID = reader.GetInt32(1);


                        if (CompararContrasenas(contrasenaObtenida, usuario.contrasena))
                        {
                            var claims = new[]
                            {
                                new Claim(ClaimTypes.NameIdentifier, usuarioID.ToString()),
                                new Claim(ClaimTypes.Name, usuario.correo),
                            };

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key50505050"));
                            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                            var token = new JwtSecurityToken(
                                issuer: "my_issuer",
                                audience: "my_audience",
                                claims: claims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: creds);

                            return Ok(new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token)
                            });
                        }
                       
                        reader.Close();

                    }
                    return Ok();
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
        }


        


    }
}






using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using BankApi.Api.Dtos;
using Microsoft.Extensions.Configuration;

namespace BankApi.Api.Services
{
    public class AuthService
    {
        readonly SqlConnectionStringBuilder builderSqlServer = new SqlConnectionStringBuilder();
        private readonly IConfiguration configuration;

        /// <summary>
        /// Constructor del AuthService
        /// </summary>
        public AuthService()
        {
            

            // builderSqlServer.DataSource = config["DataSource"];
            // builderSqlServer.UserID = config["User"];
            // builderSqlServer.Password = config["Password"];
            // builderSqlServer.InitialCatalog = config["InitialCatalog"];
        }

        /// <summary>
        /// Consulta información de la base de datos 
        /// </summary>
        /// <param name="queryDto">Dto con la consulta y los parámetros</param>
        /// <returns>Dto con el estado de la petición y los datos en
        /// caso de éxito</returns>
        public ResultDto Login(LoginDto loginDto)
        {
            try
            {
                string Username = loginDto.Username;
                string Password = loginDto.Password;

                // string result = "";

                // foreach (var item in queryDto.Params)
                // {
                //     query = query.Replace("@" + item.key, item.value);

                // }
                string query = "SELECT * FROM public.t_user WHERE use_email = '452'";
                string result = "";

                using (SqlConnection connection = new SqlConnection(builderSqlServer.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(reader);
                            result = JsonConvert.SerializeObject(dataTable);
                        }
                    }
                }
        
                // Console.WriteLine("Hello world"+query+ result);

                return new ResultDto("401", "", "Consulta exitosa", "");
            }
            catch (SqlException e)
            {
                // Console.WriteLine(e.ToString());
                return new ResultDto("Fail", "", "", $"Error- {e}");
            }
        }


    }
}

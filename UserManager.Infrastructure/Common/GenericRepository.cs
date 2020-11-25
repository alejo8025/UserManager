using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UserManager.Model.Common;

namespace UserManager.Infrastructure.Common
{
    public abstract class GenericRepository
    {
        private readonly AppSettingGlobal GlobalSettings;
        protected GenericRepository(AppSettingGlobal settings) => GlobalSettings = settings;

        public string DBConnectionString { get; set; }
        private IDbConnection Connection()
        {
            return new SqlConnection(GlobalSettings.GetValue("DbConnection"));
        }

        /// <summary>
        /// Retorna uno o varios registros desde la base de datos
        /// </summary>
        /// <typeparam name="TInput">Entity Request</typeparam>
        /// <typeparam name="XOutput">Entity Response</typeparam>
        /// <param name="Name">Nombre del objeto en la base de datos</param>
        /// <param name="filter">Parámetros</param>
        /// <param name="command">Tipo de Comando</param>
        /// <returns>Lista de registros en la base de datos</returns>
        internal async Task<IEnumerable<XOutput>> GetAsync<TInput, XOutput>(string Name, TInput filter, CommandType command) where TInput : class
        {
            using IDbConnection conn = Connection();
            conn.Open();
            var parameters = filter.GetParameters();
            var result = await conn.QueryAsync<XOutput>(Name, parameters, commandType: command);
            return result;
        }

        /// <summary>
        /// Retorna un registro desde la base de datos
        /// </summary>
        /// <typeparam name="TInput">Entity Request</typeparam>
        /// <typeparam name="XOutput">Entity Response</typeparam>
        /// <param name="Name">Nombre del objeto en la base de datos</param>
        /// <param name="filter">Parámetros</param>
        /// <param name="command">Tipo de Comando</param>
        /// <returns>Registro específico en base de datos</returns>
        internal async Task<XOutput> GetAsyncFirst<TInput, XOutput>(string Name, TInput filter, CommandType command) where TInput : class
        {
            using IDbConnection conn = Connection();
            conn.Open();
            var parameters = filter.GetParameters();
            var result = await conn.QueryFirstOrDefaultAsync<XOutput>(Name, parameters, commandType: command);
            return result;
        }

        internal async Task<IEnumerable<XOutput>> GetAsyncFirstDynamic<XOutput>(string Name, object filter, CommandType command)
        {
            using IDbConnection conn = Connection();
            conn.Open();
            var parameters = filter;
            var result = await conn.QueryAsync<XOutput>(Name, parameters, commandType: command, commandTimeout: 10);
            return result;
        }
    }
}

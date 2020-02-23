using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LojaNet.DAL
{
    public class DbHelper
    {
        public static string conexao
        {
            get { return "Data Source=LAPTOP-DPHI4379\\RODEXO;Initial Catalog=LojaNet;Integrated Security=True"; }
        }

        public static IDataReader ExecuteReader(string storedProcedure, params object[] parametros)
        {
            var cn = new SqlConnection(conexao);
            var cmd = new SqlCommand(storedProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            PreencherParametros(parametros, cmd);
            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int ExecuteNonQuery(string storedProcedure, params object[] parametros)
        {
            int retorno = 0;
            using (var cn = new SqlConnection(conexao))
            {
                using (var cmd = new SqlCommand(storedProcedure, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    PreencherParametros(parametros, cmd);
                    cn.Open();
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            return retorno;
        }

        private static void PreencherParametros(object[] parametros, SqlCommand cmd)
        {
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }
        }
    }
}

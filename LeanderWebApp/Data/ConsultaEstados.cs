using LeanderWebApp.Model;
using MySqlConnector;
using System.Data;

namespace LeanderWebApp.Data
{
    public class ConsultaEstados
    {
        private ParametrosConfiguracion ParametrosConfiguracion = new ParametrosConfiguracion("MySqlConnection");

        public object InsertEstados(Estado estado)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_insert_estados";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_nombre", estado.Nombre);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((int)reader["Codigo"] == 1)
                        {
                            success.Numero = 500;
                            success.Resultado = reader["JsonResponse"].ToString();
                            break;
                        }
                        success.Numero = 200;
                        success.Resultado = reader["JsonResponse"].ToString();

                    }
                    conexion.Close();
                    return success;
                }


            }
            catch (Exception e)
            {
                Errors error = new Errors();
                error.Message = e.Message;
                return error;
            }

        }



        public object UpdateEstados(Estado estado)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_update_estados";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_id", estado.Id);
                    cmd.Parameters.AddWithValue("@p_nombre", estado.Nombre);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((int)reader["Codigo"] == 1)
                        {
                            success.Numero = 500;
                            success.Resultado = reader["JsonResponse"].ToString();
                            break;
                        }
                        success.Numero = 200;
                        success.Resultado = reader["Mensaje"].ToString();

                    }
                    conexion.Close();
                    return success;
                }


            }
            catch (Exception e)
            {
                Errors error = new Errors();
                error.Message = e.Message;
                return error;
            }

        }


        public object DeleteEstados(int Id)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_delete_estados";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_id", Id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        success.Numero = 200;
                        success.Resultado = reader["Mensaje"].ToString();

                    }
                    conexion.Close();
                    return success;
                }


            }
            catch (Exception e)
            {
                Errors error = new Errors();
                error.Message = e.Message;
                return error;
            }

        }


        public object getEstados()
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_listar_estados";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        success.Numero = 200;
                        success.Resultado = reader["JsonResponse"].ToString();

                    }
                    conexion.Close();
                    return success;
                }


            }
            catch (Exception e)
            {
                Errors error = new Errors();
                error.Message = e.Message;
                return error;
            }

        }





    }
}

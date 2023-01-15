using LeanderWebApp.Model;
using MySqlConnector;
using System.Data;

namespace LeanderWebApp.Data
{
    public class ConsultaLocalidades
    {
        private ParametrosConfiguracion ParametrosConfiguracion = new ParametrosConfiguracion("MySqlConnection");

        public object InsertLocalidad(Localidad localidad)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_insert_localidades";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_nombre", localidad.Nombre);

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



        public object UpdateLocalidad(Localidad localidad)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_update_localidades";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_id", localidad.Id);
                    cmd.Parameters.AddWithValue("@p_nombre", localidad.Nombre);
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


        public object DeleteLocalidad(int Id)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_delete_localidades";
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


        public object getLocalidades()
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_listar_localidades";
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

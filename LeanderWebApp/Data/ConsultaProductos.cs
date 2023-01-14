using LeanderWebApp.Model;
using MySqlConnector;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace LeanderWebApp.Data
{
    public class ConsultaProductos
    {
        private ParametrosConfiguracion ParametrosConfiguracion = new ParametrosConfiguracion("MySqlConnection");


        #region Insert producto

        public object InsertProducto(Producto producto)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_insert_producto";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@p_fecha_ingreso", producto.fecha_ingreso);
                    cmd.Parameters.AddWithValue("@p_fk_id_categoria", producto.fk_id_categoria);
                    cmd.Parameters.AddWithValue("@p_fk_id_estado", producto.fk_id_estado);
                    cmd.Parameters.AddWithValue("@p_fk_id_locacion", producto.fk_id_locacion);
                    cmd.Parameters.AddWithValue("@p_precio_compra", producto.precio_compra);
                    cmd.Parameters.AddWithValue("@p_precio_venta", producto.precio_venta);
                    cmd.Parameters.AddWithValue("@p_observaciones", producto.observaciones);
                    cmd.Parameters.AddWithValue("@p_imagen", producto.imagen);
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


        #endregion


        #region Update Producto

        public object UpdateProducto(Producto producto)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_update_producto";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_id", producto.Id);
                    cmd.Parameters.AddWithValue("@p_nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@p_fecha_ingreso", producto.fecha_ingreso);
                    cmd.Parameters.AddWithValue("@p_fk_id_categoria", producto.fk_id_categoria);
                    cmd.Parameters.AddWithValue("@p_fk_id_estado", producto.fk_id_estado);
                    cmd.Parameters.AddWithValue("@p_fk_id_locacion", producto.fk_id_locacion);
                    cmd.Parameters.AddWithValue("@p_precio_compra", producto.precio_compra);
                    cmd.Parameters.AddWithValue("@p_precio_venta", producto.precio_venta);
                    cmd.Parameters.AddWithValue("@p_observaciones", producto.observaciones);
                    cmd.Parameters.AddWithValue("@p_imagen", producto.imagen);
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
        #endregion

        #region Delete Producto

        public object DeleteProducto(int Id)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_delete_producto";
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



        #endregion
    }
}

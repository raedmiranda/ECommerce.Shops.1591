using ECommerce.Shops.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Shops.DA
{
    public class TiendaDAO
    {
        #region singleton
        private static readonly TiendaDAO _instancia = new TiendaDAO();
        public static TiendaDAO Instancia { get { return _instancia; } }
        #endregion singleton

        public List<Tienda> Listar()
        {
            SqlCommand cmd = null;
            List<Tienda> list = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarTiendas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                list = new List<Tienda>();
                while (dr.Read())
                {
                    Tienda tienda = new Tienda();
                    tienda.Id = Convert.ToInt32(dr["Id"]);
                    tienda.Nombre = Convert.ToString(dr["Nombre"]);
                    tienda.Direccion = Convert.ToString(dr["Direccion"]);
                    tienda.Abierto = Convert.ToBoolean(dr["Abierto"]);
                    list.Add(tienda);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return list;
        }

        internal Tienda Devolver(int id)
        {
            SqlCommand cmd = null;
            Tienda tienda = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spDevolverTienda", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tienda = new Tienda();
                    tienda.Id = Convert.ToInt32(dr["Id"]);
                    tienda.Nombre = Convert.ToString(dr["Nombre"]);
                    tienda.Direccion = Convert.ToString(dr["Direccion"]);
                    tienda.Abierto = Convert.ToBoolean(dr["Abierto"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return tienda;
        }

        public bool Insertar(Tienda tienda)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarTienda", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", tienda.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", tienda.Direccion);
                //cmd.Parameters.AddWithValue("@Abierto", Tienda.Abierto);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) creado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;
        }

        public bool Eliminar(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEliminarTienda", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) eliminado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return eliminado;
        }

        public bool Actualizar(Tienda tienda)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spActualizarTienda", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", tienda.Id);
                cmd.Parameters.AddWithValue("@Nombre", tienda.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", tienda.Direccion);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) editado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return editado;
        }

    }
}

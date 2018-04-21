using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConoceAColombia.logica.BL
{
    public class clsUsuarios
    {
        SqlConnection _SqlConnection = null;//me permite establecer comunicacion con la base de datos
        SqlCommand _SqlCommand = null;//me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null;//me permite adaptar un conjunto de datos sql
        SqlParameter _SqlParameter = null;
        String stConexion = String.Empty;//Cadena de conexion

        public clsUsuarios()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }
        /// <summary>
        /// Validar Usuarios
        /// </summary>
        /// <param name="obclsUsuarios">Objeto Usuario</param>
        /// <returns>Confirmacion</returns>

        public bool getValidarUsuario(logica.Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarUsuario", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@cCorreo", obclsUsuarios.stCorreo));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPassword", obclsUsuarios.stPassword));
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ew)
            {
                throw ew;
            }
            finally { _SqlConnection.Close(); }

        }

        /// <summary>
        /// CREAR CUENTA DE USUARIO
        /// </summary>
        /// <param name="obclsUsuarios"></param>
        /// <returns> MENSAJE DE BBDD</returns>
        public string setCrearCuenta(logica.Models.clsUsuarios obclsUsuarios, int inOpcion)
        {
            try
            {
                
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("sp_AdministrarUsuarios", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;


                //PARAMETROS DE ENTRADA
                _SqlCommand.Parameters.Add(new SqlParameter("@cNombre", obclsUsuarios.stNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@cApellido", obclsUsuarios.stApellido));
                _SqlCommand.Parameters.Add(new SqlParameter("@cCorreo", obclsUsuarios.stCorreo));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPassword", obclsUsuarios.stPassword));
                _SqlCommand.Parameters.Add(new SqlParameter("@cImagen", obclsUsuarios.stUsuaImagen));
                _SqlCommand.Parameters.Add(new SqlParameter("@nOpcion", inOpcion));


                //PARAMETROS  DE SALIDA
                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@cMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.VarChar;
                _SqlParameter.Size = 50;

                _SqlCommand.Parameters.Add(_SqlParameter);

                _SqlCommand.ExecuteNonQuery();

                return _SqlParameter.Value.ToString();

            }
            catch (Exception ew)
            {
                throw ew;
            }
            finally { _SqlConnection.Close(); }

        }
    }
}

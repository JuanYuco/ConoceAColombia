using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.logica.BL
{
    public class clsMusica
    {
        SqlConnection _SqlConnection = null;//me permite establecer comunicacion con la base de datos
        SqlCommand _SqlCommand = null;//me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null;//me permite adaptar un conjunto de datos sql
        String stConexion = String.Empty;//Cadena de conexion
        SqlParameter _SqlParameter = null;

        public clsMusica()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }


        public DataSet getConsultarMusica()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarMusica", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;


                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ew)
            {
                throw ew;
            }
            finally { _SqlConnection.Close(); }
        }


        public DataSet getDepartamentoDatos(int Codigo)
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spDepartamentoDatos", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@dCodigo", Codigo));
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ew)
            {
                throw ew;
            }
            finally { _SqlConnection.Close(); }
        }


        public void CargarControl(ref DropDownList ddlControl, DataSet dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
        {
            try
            {
                ddlControl.DataSource = dsConsulta;
                ddlControl.DataTextField = stTexto;
                ddlControl.DataValueField = stValor;
                ddlControl.DataBind();

                ddlControl.Items.Insert(0, new ListItem(stTextoEmcabezado, stValorEmcabezado));

            }
            catch (Exception ew)
            {
                throw ew;
            }
        }



        public String setAdministrarMusica(Models.clsMusica obclsMusica, int inOpcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarMusica", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@dCodigo", obclsMusica.lgCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@dNombre", obclsMusica.stNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@dDescripcion", obclsMusica.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@dMusica", obclsMusica.stImagen));
                _SqlCommand.Parameters.Add(new SqlParameter("@dDepartamento", obclsMusica.clsDepartamentos.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@dLatitud", obclsMusica.stLatitud));
                _SqlCommand.Parameters.Add(new SqlParameter("@dLongitud", obclsMusica.stLongitud));
                _SqlCommand.Parameters.Add(new SqlParameter("@nOpcion", inOpcion));



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

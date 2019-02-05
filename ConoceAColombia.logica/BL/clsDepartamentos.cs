using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConoceAColombia.logica.BL
{
    public class clsDepartamentos
    {
        SqlConnection _SqlConnection = null;//me permite establecer comunicacion con la base de datos
        SqlCommand _SqlCommand = null;//me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null;//me permite adaptar un conjunto de datos sql
        String stConexion = String.Empty;//Cadena de conexion
        SqlParameter _SqlParameter = null;

        public clsDepartamentos()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }
        public DataSet getConsultarDepartamentos()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarDepartamentos", _SqlConnection);
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

        public String setAdministrarDepartamentos(Models.clsDepartamentos obclsDepartamentos, int inOpcion)
        {
            try
            {
                
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarDepartamentos", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@dCodigo", obclsDepartamentos.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@dNombre", obclsDepartamentos.stNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@dCapital", obclsDepartamentos.stCapital));
                _SqlCommand.Parameters.Add(new SqlParameter("@dGobernador", obclsDepartamentos.stGobernador));
                _SqlCommand.Parameters.Add(new SqlParameter("@dMunicipios", obclsDepartamentos.stMunicipios));
                _SqlCommand.Parameters.Add(new SqlParameter("@dFundacion", obclsDepartamentos.stFundacion));
                _SqlCommand.Parameters.Add(new SqlParameter("@dGentilicio", obclsDepartamentos.stGentilicio));
                _SqlCommand.Parameters.Add(new SqlParameter("@dPoblacion", obclsDepartamentos.stPoblacion));
                _SqlCommand.Parameters.Add(new SqlParameter("@dSuperficie", obclsDepartamentos.stSuperficie));
                _SqlCommand.Parameters.Add(new SqlParameter("@dDemografia", obclsDepartamentos.stDemografia));
                _SqlCommand.Parameters.Add(new SqlParameter("@dLatitud", obclsDepartamentos.stLatitud));
                _SqlCommand.Parameters.Add(new SqlParameter("@dLongitud", obclsDepartamentos.stLongitud));
                _SqlCommand.Parameters.Add(new SqlParameter("@dImagen", obclsDepartamentos.stImagen));
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

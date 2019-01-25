using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.FaunaxDepartamentoAdmin
{
    public partial class FaunaxDepartamentoAdmin : System.Web.UI.Page
    {
        void getFaunaxDepartamento()
        {
            try
            {
                Controllers.FaunaxDepartamentoControllers obFaunaxDepartamentoControllers = new Controllers.FaunaxDepartamentoControllers();
                gvwDatos.DataSource = obFaunaxDepartamentoControllers.getFaunaxDepartamento();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFaunaxDepartamento();
                logica.BL.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.BL.clsFaunaxDepartamento();
                Controllers.FaunaxDepartamentoControllers obFaunaxDepartamentoControllers = new Controllers.FaunaxDepartamentoControllers();
                List<logica.Models.clsFauna> consultaFauna = obFaunaxDepartamentoControllers.getFauna();
                List<logica.Models.clsDepartamentos> consultaDepartamento = obFaunaxDepartamentoControllers.getDepartamentos();
                obclsFaunaxDepartamento.CargarControlFauna(ref ddlFauna, consultaFauna, "lgCodigo", "stNombre", "-1", "<<Todos>>");
                obclsFaunaxDepartamento.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamento, "inCodigo", "stNombre", "-1", "<<Todos>>");
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsFaunaxDepartamento clsFaunaxDepartamento = new logica.Models.clsFaunaxDepartamento
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsFauna = new logica.Models.clsFauna
                    {
                        lgCodigo = Convert.ToInt64(ddlFauna.SelectedValue)
                    },
                    obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    }
                };


                Controllers.FaunaxDepartamentoControllers obFaunaxDepartamentoControllers = new Controllers.FaunaxDepartamentoControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFaunaxDepartamentoControllers.insertarFaunaxDepartamento(clsFaunaxDepartamento) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtLatitud.Text=txtLongitud.Text = String.Empty;
                    getFaunaxDepartamento();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFaunaxDepartamentoControllers.updateFaunaxDepartamento(clsFaunaxDepartamento) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text =  txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getFaunaxDepartamento();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text =  txtLatitud.Text = txtLongitud.Text = String.Empty;
        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    lblOpcion.Text = "2";
                    txtCodigo.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.Models.clsFaunaxDepartamento
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stLatitud = String.Empty,
                        stLongitud = String.Empty
                    };

                    Controllers.FaunaxDepartamentoControllers obFaunaxDepartamentoControllers = new Controllers.FaunaxDepartamentoControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obFaunaxDepartamentoControllers.deleteFaunaxDepartamento(obclsFaunaxDepartamento) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text =  txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getFaunaxDepartamento();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}
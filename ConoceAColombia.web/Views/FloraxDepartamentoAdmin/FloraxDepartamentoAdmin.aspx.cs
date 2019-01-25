using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.FloraxDepartamentoAdmin
{
    public partial class FloraxDepartamentoAdmin : System.Web.UI.Page
    {
        void getFloraxDepartamento()
        {
            try
            {
                Controllers.FloraxDepartamentoControllers obFloraxDepartamentoControllers = new Controllers.FloraxDepartamentoControllers();
                gvwDatos.DataSource = obFloraxDepartamentoControllers.getFloraxDepartamento();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFloraxDepartamento();
                logica.BL.clsFloraxDepartamento obclsFloraxDepartamento = new logica.BL.clsFloraxDepartamento();
                Controllers.FloraxDepartamentoControllers obFloraxDepartamentoControllers = new Controllers.FloraxDepartamentoControllers();
                List<logica.Models.clsFlora> consultaFlora = obFloraxDepartamentoControllers.getFlora();
                List<logica.Models.clsDepartamentos> consultaDepartamento = obFloraxDepartamentoControllers.getDepartamentos();
                obclsFloraxDepartamento.CargarControlFlora(ref ddlFlora, consultaFlora, "lgCodigo", "stNombre", "-1", "<<Todos>>");
                obclsFloraxDepartamento.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamento, "inCodigo", "stNombre", "-1", "<<Todos>>");
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

                logica.Models.clsFloraxDepartamento clsFloraxDepartamento = new logica.Models.clsFloraxDepartamento
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsFlora = new logica.Models.clsFlora
                    {
                        lgCodigo = Convert.ToInt64(ddlFlora.SelectedValue)
                    },
                    obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    }
                };


                Controllers.FloraxDepartamentoControllers obFloraxDepartamentoControllers = new Controllers.FloraxDepartamentoControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFloraxDepartamentoControllers.insertarFloraxDepartamento(clsFloraxDepartamento) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getFloraxDepartamento();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFloraxDepartamentoControllers.updateFloraxDepartamento(clsFloraxDepartamento) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getFloraxDepartamento();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    logica.Models.clsFloraxDepartamento obclsFloraxDepartamento = new logica.Models.clsFloraxDepartamento
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stLatitud = String.Empty,
                        stLongitud = String.Empty
                    };

                    Controllers.FloraxDepartamentoControllers obFloraxDepartamentoControllers = new Controllers.FloraxDepartamentoControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obFloraxDepartamentoControllers.deleteFloraxDepartamento(obclsFloraxDepartamento) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getFloraxDepartamento();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}
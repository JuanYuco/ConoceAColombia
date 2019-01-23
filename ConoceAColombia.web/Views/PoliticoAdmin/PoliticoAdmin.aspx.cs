using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.PoliticoAdmin
{
    public partial class PoliticoAdmin : System.Web.UI.Page
    {
        void getPolitico()
        {
            try
            {
                Controllers.PoliticoControllers obPoliticoControllers = new Controllers.PoliticoControllers();
                gvwDatos.DataSource = obPoliticoControllers.getPolitico();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPolitico();
                logica.BL.clsPolitico obclsPolitico = new logica.BL.clsPolitico();
                Controllers.PoliticoControllers obPoliticoControllers = new Controllers.PoliticoControllers();
                List<logica.Models.clsTipoPolitico> consultaTipoPolitico = obPoliticoControllers.getTipoPolitico();
                List<logica.Models.clsDepartamentos> consultaDepartamentos = obPoliticoControllers.getDepartamentos();
                obclsPolitico.CargarControlTipoPolitico(ref ddlTipoDeportista, consultaTipoPolitico, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
                obclsPolitico.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripción, ";
                if (String.IsNullOrEmpty(txtFechaNacimiento.Text)) stMensaje += "Ingrese Fecha de Nacimiento, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsPolitico clsPolitico = new logica.Models.clsPolitico
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    stFechaNacimiento = txtFechaNacimiento.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    },
                    obclsTipoPolitico = new logica.Models.clsTipoPolitico
                    {
                        lgCodigo = Convert.ToInt64(ddlTipoDeportista.SelectedIndex)
                    }


                };

                Controllers.PoliticoControllers obPoliticoControllers = new Controllers.PoliticoControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obPoliticoControllers.insertarPolitico(clsPolitico) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getPolitico();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obPoliticoControllers.updatePolitico(clsPolitico) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getPolitico();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtNombre.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtDescripcion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtFechaNacimiento.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtCiudad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsPolitico obclsPolitico = new logica.Models.clsPolitico
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        obclsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        stFechaNacimiento = String.Empty,
                        stCiudad = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        obclsTipoPolitico = new logica.Models.clsTipoPolitico { lgCodigo = 0 }



                    };

                    Controllers.PoliticoControllers obPoliticoControllers = new Controllers.PoliticoControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obPoliticoControllers.deletePolitico(obclsPolitico) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getPolitico();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}
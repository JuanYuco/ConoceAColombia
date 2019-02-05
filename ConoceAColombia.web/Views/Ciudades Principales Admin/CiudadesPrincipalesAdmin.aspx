<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="CiudadesPrincipalesAdmin.aspx.cs" Inherits="ConoceAColombia.web.Views.Ciudades_Principales_Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:label runat="server" id="lblTitulo" text="Ciudades Principales"></asp:label>
                    <asp:label runat="server" id="lblOpcion" Visible="false"></asp:label>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblCodigo" text="Código"></asp:label>
                    <asp:textbox runat="server" id="txtCodigo" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblNombre" text="Nombre"></asp:label>
                    <asp:textbox runat="server" id="txtNombre" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblDepartamento" text="Departamento"></asp:label>
                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control">

                    </asp:DropDownList>
                </div>
                
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblLatitud" text="Latitud"></asp:label>
                    <asp:textbox runat="server" id="txtLatitud" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblLongitud" text="Longitud"></asp:label>
                    <asp:textbox runat="server" id="txtLongitud" cssclass="form-control"></asp:textbox>
                </div> 
                <div class="col-md-3">
                    <asp:label runat="server" id="lblReseña" text="Reseña"></asp:label>
                    <asp:TextBox runat="server" id="txtReseña" cssclass="form-control" TextMode="multiline" Columns="50" Rows="5" ></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblImagen" runat="server" Text="Subir Imagen"></asp:Label>
                    <asp:FileUpload ID="fuImagen" runat="server" CssClass="form-control" placeholder="Agregar Imagen"></asp:FileUpload>
                </div>
            </div>
        </div>


        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:button runat="server" id="btnGuardar" text="Guardar" cssclass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:button runat="server" id="btnCancelar" text="Cancelar" cssclass="btn btn-primary" OnClick="btnCancelar_Click"/>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:label runat="server" id="lblResultado" text="Resultado"></asp:label>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12" style="overflow:auto">
                    <asp:GridView runat="server" ID="gvwDatos" width="100%" AutoGenerateColumns="False" EmptyDataText="No se encontraron registros" OnRowCommand="gvwDatos_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("ciprCodigo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Nombre" DataField="ciprNombre" />
                            <asp:BoundField HeaderText="Reseña" DataField="ciprReseña" />
                            <asp:BoundField HeaderText="Latitud" DataField="ciprLatitud" />
                            <asp:BoundField HeaderText="Longitud" DataField="ciprLongitud"/>
                            <asp:BoundField HeaderText="Imagen" DataField="ciprImagen" />
                            <asp:BoundField HeaderText="Departamento" DataField="depaNombre"/>

                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibEditar" runat="server" ImageUrl="~/Resources/Images/edit26-300px.png" Width="50px" Height="50px" CommandName="Editar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Resources/Images/61848.png" Width="50px" Height="50px" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

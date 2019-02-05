<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="DepartamentosAdmin.aspx.cs" Inherits="ConoceAColombia.web.Views.Departamentos_Admin.WebForm1" %>

<asp:Content runat="server" ID="ConteHeader" ContentPlaceHolderID="Header">
    <link href="../../css/sweetalert.css" rel="stylesheet" />
    <script src="../../js/sweetalert.min.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:label runat="server" id="lblTitulo" text="Departamentos"></asp:label>
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
                    <asp:label runat="server" id="lblCapital" text="Capital"></asp:label>
                    <asp:textbox runat="server" id="txtCapital" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblGobernador" text="Gobernador"></asp:label>
                    <asp:textbox runat="server" id="txtGobernador" cssclass="form-control"></asp:textbox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblMunicipios" text="Municipios"></asp:label>
                    <asp:textbox runat="server" id="txtMunicipios" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblFundacion" text="Fundación"></asp:label>
                    <asp:textbox runat="server" id="txtFundacion" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblGentilicio" text="Gentilicio"></asp:label>
                    <asp:textbox runat="server" id="txtGentilicio" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblPoblacion" text="Población"></asp:label>
                    <asp:textbox runat="server" id="txtPoblacion" cssclass="form-control"></asp:textbox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblSuperficie" text="Superficie"></asp:label>
                    <asp:textbox runat="server" id="txtSuperficie" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblDemografia" text="Demografia"></asp:label>
                    <asp:textbox runat="server" id="txtDemografia" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblLatitud" text="Latitud"></asp:label>
                    <asp:textbox runat="server" id="txtLatitud" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblLongitud" text="Longitud"></asp:label>
                    <asp:textbox runat="server" id="txtLongitud" cssclass="form-control"></asp:textbox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
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
                                    <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("depaCodigo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Nombre" DataField="depaNombre" />
                            <asp:BoundField HeaderText="Capital" DataField="depaCapital" />
                            <asp:BoundField HeaderText="Gobernador" DataField="depaGobernador" />
                            <asp:BoundField HeaderText="Municipios" DataField="depaMunicipios" />
                            <asp:BoundField HeaderText="Fundacion" DataField="depaFundacion" />
                            <asp:BoundField HeaderText="Gentilicio" DataField="depaGentilicio" />
                            <asp:BoundField HeaderText="Poblacion" DataField="depaPoblacion" />
                            <asp:BoundField HeaderText="Superficie" DataField="depaSuperficie" />
                            <asp:BoundField HeaderText="Demografia" DataField="depaDemografia" />
                            <asp:BoundField HeaderText="Latitud" DataField="depaLatitud" />
                            <asp:BoundField HeaderText="Longitud" DataField="depaLongitud" />
                            <asp:BoundField HeaderText="Imagen" DataField="depaImagen" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="HistoriaAdmin.aspx.cs" Inherits="ConoceAColombia.web.Views.HistoriaAdmin.HistoriaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTitulo" Text="Historia"></asp:Label>
                    <asp:Label runat="server" ID="lblOpcion" Visible="false"></asp:Label>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblCodigo" Text="Código"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblNombre" Text="Nombre"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblDescripcion" Text="Descripción"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDescripción" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblTipodeHistoria" Text="Tipo de Historia"></asp:Label>
                    <asp:DropDownList ID="ddlTipoHistoria" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblFechaInicio" Text="Fecha de Inicio"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblFechaFin" Text="Fecha del final"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFechaFin" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblLatitud" Text="Latitud"></asp:Label>
                    <asp:TextBox runat="server" ID="txtLatitud" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblLongitud" Text="Longitud"></asp:Label>
                    <asp:TextBox runat="server" ID="txtLongitud" CssClass="form-control"></asp:TextBox>
                    
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label1" Text="Departamento"></asp:Label>
                    <asp:DropDownList ID="dllDepartamento" runat="server" CssClass="form-control">
                    </asp:DropDownList>
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
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblResultado" Text="Resultado"></asp:Label>
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
                                    <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("histCodigo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Nombre" DataField="histNombre" />
                            <asp:BoundField HeaderText="Descripcion" DataField="histDescripcion" />
                            <asp:BoundField HeaderText="Periodo Historia" DataField="pehiDescripcion" />
                            <asp:BoundField HeaderText="Fecha Inicio" DataField="histFechaInicio" />
                            <asp:BoundField HeaderText="Fecha Fin" DataField="HistFechaFin"/>
                            <asp:BoundField HeaderText="Latitud" DataField="HistLatitud"/>
                            <asp:BoundField HeaderText="Longitud" DataField="HistLongitud"/>
                            <asp:BoundField HeaderText="Imagen" DataField="histImagen"/>
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

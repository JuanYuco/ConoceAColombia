<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="FaunaAdmin.aspx.cs" Inherits="ConoceAColombia.web.Views.FaunaAdmin.FaunaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="form-group">
        <div class="form-row">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblTitulo" Text="Fauna"></asp:Label>
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
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblTipoFauna" Text="Tipo Fauna"></asp:Label>
                <asp:DropDownList ID="ddlTipoFauna" runat="server" CssClass="form-control">
                </asp:DropDownList>
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
            <div class="col-md-12" style="overflow: auto">
                <asp:GridView runat="server" ID="gvwDatos" Width="100%" AutoGenerateColumns="False" EmptyDataText="No se encontraron registros" OnRowCommand="gvwDatos_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Codigo">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("lgCodigo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nombre" DataField="stNombre" />
                        <asp:BoundField HeaderText="Descripción" DataField="stDescripcion" />
                        <asp:BoundField HeaderText="Imagen" DataField="stImagen" />
                        <asp:BoundField HeaderText="Tipo" DataField="obclsTipoFauna.stDescripcion" />
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
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="FloraAdmin.aspx.cs" Inherits="ConoceAColombia.web.Views.FloraAdmin.FloraAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
    <ajaxToolkit:AutoCompleteExtender ID="acNombre" runat="server"
        ServicePath="~/Services/wsConsulta.asmx"
        ServiceMethod="getFloraWS"
        MinimumPrefixLength="2"
        CompletionInterval="100"
        EnableCaching="false"
        CompletionSetCount="10"
        FirstRowSelected="false"
        UseContextKey="true"
        TargetControlID="txtNombre">
    </ajaxToolkit:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTitulo" Text="Flora"></asp:Label>
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
                    <asp:Label runat="server" ID="lblNomCientifico" Text="Nombre Cientifico"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNomCientifico" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblNomComun" Text="NombreComun"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNomComun" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblDescripcion" Text="Descripcion"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblTipoFlora" Text="TipoFlora"></asp:Label>
                    <asp:DropDownList ID="ddlTipoFlora" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblAbundancia" Text="Abundancia"></asp:Label>
                    <asp:TextBox runat="server" ID="txtAbundancia" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblPeriodoFloracion" Text="Periodo de Floracion"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPeridoFloracion" CssClass="form-control"></asp:TextBox>
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
                            <asp:BoundField HeaderText="Nombre Cientifico" DataField="stNombreCientifico" />
                            <asp:BoundField HeaderText="Nombre Comun" DataField="stNombre" />
                            <asp:BoundField HeaderText="Descripcion" DataField="stDescripcion" />
                            <asp:BoundField HeaderText="Abundancia" DataField="stAbundancia" />
                            <asp:BoundField HeaderText="Periodo de Floracion" DataField="stPeriodoFloracion" />
                            <asp:BoundField HeaderText="Tipo Flora" DataField="obclsTipoFlora.stDescripcion" />

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

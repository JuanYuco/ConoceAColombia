<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="TipoHistoriaAdmin.aspx.cs" Inherits="ConoceAColombia.web.Views.Tipo_Historia_Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTiposhistoria" Text="Tipos de Historia"></asp:Label>
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
                    <asp:Label runat="server" ID="lblDescripcion" Text="Descripcion"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control"></asp:TextBox>
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
    </div>
</asp:Content>

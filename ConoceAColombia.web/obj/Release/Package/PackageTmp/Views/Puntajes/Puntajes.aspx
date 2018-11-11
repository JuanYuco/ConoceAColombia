<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="Puntajes.aspx.cs" Inherits="ConoceAColombia.web.Views.Puntajes.Puntajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div id="divLlenar" runat="server" class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTitulo" Text="Agrega tu puntaje"></asp:Label>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblNombre" Text="Nombre Completo"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>

                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar Puntaje" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="form-row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnVolver" Text="Jugar de Nuevo" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
            </div>
        </div>
    </div>



    <div id="divPuntajes" runat="server" class="form-group" visible="false">
        <div class="form-row">
            <div class="col-md-12" style="overflow: auto">
                <asp:GridView runat="server" ID="gvwDatos" Width="100%" AutoGenerateColumns="False" EmptyDataText="No se encontraron registros" OnRowCommand="gvwDatos_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Codigo" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("lgCodigo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nombre Completo" DataField="stNombreCompleto" />
                        <asp:BoundField HeaderText="Tipo de Juego" DataField="stTipoJuego" />
                        <asp:BoundField HeaderText="Dificultad" DataField="stDificultad" />
                        <asp:BoundField HeaderText="Puntaje" DataField="inPuntaje" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

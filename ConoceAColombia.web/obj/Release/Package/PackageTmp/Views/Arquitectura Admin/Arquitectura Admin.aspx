﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="Arquitectura Admin.aspx.cs" Inherits="ConoceAColombia.web.Views.Arquitectura_Admin.Arquitectura_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTitulo" Text="Arquitectura"></asp:Label>
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
                    <asp:Label runat="server" ID="lblCiudad" Text="Ciudad"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblLatitud" Text="Latitud"></asp:Label>
                    <asp:TextBox runat="server" ID="txtLatitud" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblLongitud" Text="Longitud"></asp:Label>
                    <asp:TextBox runat="server" ID="txtLongitud" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblDepartamento" Text="Departamento"></asp:Label>
                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblArquitectura" Text="Arquitectura"></asp:Label>
                    <asp:DropDownList ID="ddlTipoArquitectura" runat="server" CssClass="form-control">
                    </asp:DropDownList>
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
                                    <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("arquCodigo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Departamento" DataField="depaNombre" />
                            <asp:BoundField HeaderText="Nombre" DataField="arquNombre" />
                            <asp:BoundField HeaderText="Ciudad" DataField="arquCiudad" />
                            <asp:BoundField HeaderText="Latitud" DataField="arquLatitud" />
                            <asp:BoundField HeaderText="Longitud" DataField="arquLongitud"/>
                            <asp:BoundField HeaderText="Tipo de arquitectura" DataField="tiarDescripcion"/>

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

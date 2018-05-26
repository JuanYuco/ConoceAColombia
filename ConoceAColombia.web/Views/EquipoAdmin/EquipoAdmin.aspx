<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="EquipoAdmin.aspx.cs" Inherits="ConoceAColombia.web.Views.EquipoAdmin.EquipoAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:label runat="server" id="lblTitulo" text="Equipos"></asp:label>
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
                    <asp:label runat="server" id="lblDescripción" text="Descripción"></asp:label>
                    <asp:textbox runat="server" id="txtDescripcion" cssclass="form-control"></asp:textbox>
                    
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblPresidente" text="Presidente"></asp:label>
                    <asp:textbox runat="server" id="txtPresidente" cssclass="form-control"></asp:textbox>
                </div>
                
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblFundacion" text="Fundación"></asp:label>
                    <asp:textbox runat="server" id="txtFundación" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblCiudad" text="Ciudad"></asp:label>
                    <asp:textbox runat="server" id="txtCiudad" cssclass="form-control"></asp:textbox>
                </div> 
                <div class="col-md-3">
                     <asp:label runat="server" id="lblDeportes" text="Deportes"></asp:label>
                    <asp:DropDownList ID="ddlDeportes" runat="server" CssClass="form-control">

                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblDepartamentos" text="Departamentos"></asp:label>
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
                                    <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("lgCodigo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Nombre" DataField="stNombre" />
                            <asp:BoundField HeaderText="Descripción" DataField="stDescripcion" />
                            <asp:BoundField HeaderText="Presidente" DataField="stPresidente" />
                            <asp:BoundField HeaderText="Fundación" DataField="stFundacion"/>
                            <asp:BoundField HeaderText="Ciudad" DataField="stCiudad"/>
                            <asp:BoundField HeaderText="Latitud" DataField="stLatitud"/>
                            <asp:BoundField HeaderText="Longitud" DataField="stLongitud"/>
                            <asp:BoundField HeaderText="Deporte" DataField="obclsDeportes.stNombre"/>
                            <asp:BoundField HeaderText="Departamento" DataField="obclsDepartamentos.stNombre"/>
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

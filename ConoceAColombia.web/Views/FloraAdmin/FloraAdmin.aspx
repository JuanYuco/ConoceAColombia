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
                        TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:label runat="server" id="lblTitulo" text="Flora"></asp:label>
                    <asp:label runat="server" id="lblOpcion" visible="false"></asp:label>
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
                    <asp:label runat="server" id="lblNomCientifico" text="Nombre Cientifico"></asp:label>
                    <asp:textbox runat="server" id="txtNomCientifico" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblNomComun" text="NombreComun"></asp:label>
                    <asp:textbox runat="server" id="txtNomComun" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblDescripcion" text="Descripcion"></asp:label>
                    <asp:textbox runat="server" id="txtDescripcion" cssclass="form-control"></asp:textbox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblDepartamento" text="Departamento"></asp:label>
                    <asp:dropdownlist id="ddlDepartamento" runat="server" cssclass="form-control">
                    </asp:dropdownlist>
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
                    <asp:label runat="server" id="lblAbundancia" text="Abundancia"></asp:label>
                    <asp:textbox runat="server" id="txtAbundancia" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblPeriodoFloracion" text="Periodo de Floracion"></asp:label>
                    <asp:textbox runat="server" id="txtPeridoFloracion" cssclass="form-control"></asp:textbox>
                </div>
            </div>
        </div>



        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:button runat="server" id="btnGuardar" text="Guardar" cssclass="btn btn-primary" onclick="btnGuardar_Click" />
                    <asp:button runat="server" id="btnCancelar" text="Cancelar" cssclass="btn btn-primary" onclick="btnCancelar_Click" />
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
                <div class="col-md-12" style="overflow: auto">
                    <asp:gridview runat="server" id="gvwDatos" width="100%" autogeneratecolumns="False" emptydatatext="No se encontraron registros" onrowcommand="gvwDatos_RowCommand">
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
                            <asp:BoundField HeaderText="Latitud" DataField="stLongitud" />
                            <asp:BoundField HeaderText="Longitud" DataField="stLatitud"/>
                            <asp:BoundField HeaderText="Codigo Departamento" DataField="obclsDepartamentos.inCodigo"/>
                            <asp:BoundField HeaderText="Nombre Departamento" DataField="obclsDepartamentos.stNombre"/>

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
                    </asp:gridview>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

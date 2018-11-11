<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin Juego/TemplateJuego.Master" AutoEventWireup="true" CodeBehind="PreguntasJuego.aspx.cs" Inherits="ConoceAColombia.web.Views.PreguntasJuego.PreguntasJuego" %>
<asp:Content runat="server" ID="ConteHeader" ContentPlaceHolderID="Header">
    <link href="../../css/sweetalert.css" rel="stylesheet" />
    <script src="../../js/sweetalert.min.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:label runat="server" id="lblTitulo" text="Preguntas Juego"></asp:label>
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
                    <asp:label runat="server" id="lblPregunta" text="Pregunta"></asp:label>
                    <asp:textbox runat="server" id="txtPregunta" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblRespuestaCorrecta" text="Respuesta Correcta"></asp:label>
                    <asp:textbox runat="server" id="txtRespuestaCorrecta" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblRespuestaIncorrectaUno" text="Respuesta Incorrecta Uno"></asp:label>
                    <asp:textbox runat="server" id="txtRespuestaIncorrectaUno" cssclass="form-control"></asp:textbox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblRespuestaIncorrectaDos" text="Respuesta Incorrecta Dos"></asp:label>
                    <asp:textbox runat="server" id="txtRespuestaIncorrectaDos" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblRespuestaIncorrectaTres" text="Respuesta Incorrecta Tres"></asp:label>
                    <asp:textbox runat="server" id="txtRespuestaIncorrectaTres" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblRespuestaIncorrectaCuatro" text="Respuesta Incorrecta Cuatro"></asp:label>
                    <asp:textbox runat="server" id="txtRespuestaIncorrectaCuatro" cssclass="form-control"></asp:textbox>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblRespuestaIncorrectaCinco" text="Respuesta Incorrecta Cinco"></asp:label>
                    <asp:textbox runat="server" id="txtRespuestaIncorrectaCinco" cssclass="form-control"></asp:textbox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:label runat="server" id="lblTematicasJuego" text="Tematica"></asp:label>
                    <asp:DropDownList ID="ddlTematicasJuego" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblTipoJuego" text="Tipo Juego"></asp:label>
                    <asp:DropDownList ID="ddlTipoJuego" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:label runat="server" id="lblDicultadJuego" text="Dicultad"></asp:label>
                    <asp:DropDownList ID="ddlDicultadJuego" runat="server" CssClass="form-control">
                    </asp:DropDownList>
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
                            <asp:BoundField HeaderText="Pregunta" DataField="stPregunta" />
                            <asp:BoundField HeaderText="Respuesta Correcta" DataField="stRespuestaCorrecta" />
                            <asp:BoundField HeaderText="Respuesta Incorrecta Uno" DataField="stRespuestaIncorrectaUno" />
                            <asp:BoundField HeaderText="Respuesta Incorrecta Dos" DataField="stRespuestaIncorrectaDos" />
                            <asp:BoundField HeaderText="Respuesta Incorrecta Tres" DataField="stRespuestaIncorrectaTres" />
                            <asp:BoundField HeaderText="Respuesta Incorrecta Cuatro" DataField="stRespuestaIncorrectaCuatro" />
                            <asp:BoundField HeaderText="Respuesta Incorrecta Cinco" DataField="stRespuestaIncorrectaCinco" />
                            <asp:BoundField HeaderText="Tematica" DataField="obclsTematicasJuego.stDescripcion" />
                            <asp:BoundField HeaderText="Tipo juego" DataField="obclsTipoJuego.stDescripcion" />
                            <asp:BoundField HeaderText="Dicultad" DataField="obclsDicultadJuego.stDescripcion" />

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

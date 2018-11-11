<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="JuegoPorTematicas.aspx.cs" Inherits="ConoceAColombia.web.Views.JuegoPorTematicas.JuegoPorTematicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="form-group" id="divPreguntas">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblPregunta" Text="Aqui va una pregunta?"></asp:Label>
            <asp:Label runat="server" ID="lblRespuestaCorrecta" Visible="false" Text=""></asp:Label>
            <asp:Label runat="server" ID="lblPuntaje" Visible="false" Text="0"></asp:Label>
        </div>
    </div>
    <div id="divRespuestas" runat="server" class="mt-xl-auto">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaUno" CssClass="btn btn-primary" Text="" style="width:200px; height:100px" OnClick="btnRespuestaUno_Click"/>
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaDos" CssClass="btn btn-primary" Text="" style="width:200px; height:100px" OnClick="btnRespuestaDos_Click"/>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaTres" CssClass="btn btn-primary" Text="" style="width:200px; height:100px" OnClick="btnRespuestaTres_Click"/>
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaCuatro" CssClass="btn btn-primary" Text="" style="width:200px; height:100px" OnClick="btnRespuestaCuatro_Click"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="ConoceAColombia.web.Views.Juego.Juego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">

    <div class="form-group" id="divPreguntas">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblPregunta" Text="Aqui va una pregunta?"></asp:Label>
        </div>
    </div>
    <div id="divRespuestas" runat="server" class="mt-xl-auto">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaUno" CssClass="btn btn-primary" Text="" style="width:200px; height:100px"/>
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaDos" CssClass="btn btn-primary" Text="" style="width:200px; height:100px"/>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaTres" CssClass="btn btn-primary" Text="" style="width:200px; height:100px"/>
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnRespuestaCuatro" CssClass="btn btn-primary" Text="" style="width:200px; height:100px"/>
                </div>
            </div>
        </div>
    </div>


    <div id="anagrama" runat="server">
        <div class="form-group">
            <div id="divLetras" runat="server">

            </div>
        </div>
    </div>

   






</asp:Content>

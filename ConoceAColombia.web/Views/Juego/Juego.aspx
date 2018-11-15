<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="ConoceAColombia.web.Views.Juego.Juego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">

    <div class="form-group" id="divPreguntas">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblPregunta" Text="Aqui va una pregunta?"></asp:Label>
            <asp:Label runat="server" ID="lblRespuestaCorrecta" Visible="false" Text=""></asp:Label>
            <asp:Label runat="server" ID="lblPuntaje" Visible="false" Text="0"></asp:Label>
            <asp:ScriptManager ID="smTiempo" runat="server"></asp:ScriptManager>
            <asp:Timer ID="tmTiempo" runat="server" Interval="1000" OnTick="tmTiempo_Tick"></asp:Timer>
            <asp:UpdatePanel ID="upTiempo" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tmTiempo" Eventname="tick" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
    </div>
    <div id="divRespuestas" runat="server" class="mt-xl-auto">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <asp:Button runat="server" ID="btnRespuestaUno" CssClass="btn btn-primary" Text="" style="width:400px; height:100px" OnClick="btnRespuestaUno_Click"/>
                </div>
                <div class="col-md-6">
                    <asp:Button runat="server" ID="btnRespuestaDos" CssClass="btn btn-primary" Text="" style="width:400px; height:100px" OnClick="btnRespuestaDos_Click"/>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <asp:Button runat="server" ID="btnRespuestaTres" CssClass="btn btn-primary" Text="" style="width:400px; height:100px" OnClick="btnRespuestaTres_Click"/>
                </div>
                <div class="col-md-6">
                    <asp:Button runat="server" ID="btnRespuestaCuatro" CssClass="btn btn-primary" Text="" style="width:400px; height:100px" OnClick="btnRespuestaCuatro_Click"/>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="MenuJuego.aspx.cs" Inherits="ConoceAColombia.web.Views.MenuJuego.MenuJuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="form-group">
        <div class="form-row">
            <div class="col-md-3">
                <img src="../../Resources/Images/barajar.png" style="width:250px; height:250px"/>
                <asp:Button runat="server" ID="btnJuegoRandom" Text="Random" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnJuegoRandom_Click" />
            </div>
            <div class="col-md-3">
                <img src="../../Resources/Images/mundial.png" style="width:250px; height:250px"/>
                <asp:Button runat="server" ID="btnJuegoGeografia" Text="Geografía" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnJuegoGeografia_Click" />
            </div>
            <div class="col-md-3">
                <img src="../../Resources/Images/jamon.png" style="width:250px; height:250px"/>
                <asp:Button runat="server" ID="btnJuegoGastronomia" Text="Gastronomía" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnJuegoGastronomia_Click" />
            </div>
            <div class="col-md-3">
                <img src="../../Resources/Images/historia.png" style="width:250px; height:250px"/>
                <asp:Button runat="server" ID="btnHistoria" Text="Historía" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnHistoria_Click" />
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="form-group">
        <div class="form-row">
            <div class="col-md-3">
                <img src="../../Resources/Images/balon-en-variante-de-futbol.png" style="width:250px; height:250px"/>
                <asp:Button runat="server" ID="btnDeportes" Text="Deportes" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnDeportes_Click" />
            </div>
            <div class="col-md-3">
                <img src="../../Resources/Images/lotus-flower.png" style="width:250px; height:250px"/>
                <asp:Button runat="server" ID="btnFlora" Text="Flora" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnFlora_Click" />
            </div>
            <div class="col-md-3">
                <img src="../../Resources/Images/aguila.png" style="width:250px; height:250px"/>
                <asp:Button runat="server" ID="btnFauna" Text="Fauna" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnFauna_Click" />

            </div>
            <div class="col-md-3">
                <img src="../../Resources/Images/nota-musical.png" style="width:250px; height:250px" />
                <asp:Button runat="server" ID="btnMusica" Text="Música" CssClass="btn" BackColor="Silver" style="width:250px; height:100px" OnClick="btnMusica_Click" />
            </div>
        </div>
    </div>
</asp:Content>

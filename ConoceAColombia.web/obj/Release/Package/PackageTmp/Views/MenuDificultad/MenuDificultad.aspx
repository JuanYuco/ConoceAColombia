<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="MenuDificultad.aspx.cs" Inherits="ConoceAColombia.web.Views.MenuDificultad.MenuDificultad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTematica" Text="" Font-Size="50pt" ForeColor="Black"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="form-row">
            <div class="col-md-4">
                <img src="../../Resources/Images/happy.png" style="width: 250px; height: 250px" />
                <asp:Button runat="server" ID="btnDificultadFacil" Text="Fácil" CssClass="btn" BackColor="GreenYellow" Style="width: 250px; height: 100px" OnClick="btnDificultadFacil_Click" />
            </div>
            <div class="col-md-4">
                <img src="../../Resources/Images/serio.png" style="width: 250px; height: 250px" />
                <asp:Button runat="server" ID="btnDificultadMedio" Text="Medio" CssClass="btn" BackColor="Yellow" Style="width: 250px; height: 100px" OnClick="btnDificultadMedio_Click" />
            </div>
            <div class="col-md-4">
                <img src="../../Resources/Images/enojado.png" style="width: 250px; height: 250px" />
                <asp:Button runat="server" ID="btnDificultadDificil" Text="Difícil" CssClass="btn" BackColor="Red" Style="width: 250px; height: 100px" OnClick="btnDificultadDificil_Click" />
            </div>
        </div>
    </div>
</asp:Content>

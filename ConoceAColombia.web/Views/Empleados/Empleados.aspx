<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template Admin/Template Admin.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="ConoceAColombia.web.Views.Empleados.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="acNombre" runat="server"
                        ServicePath="~/Services/wsConsulta.asmx"
                        ServiceMethod="getEmpleadosWS"
                        MinimumPrefixLength="2" 
                        CompletionInterval="100"
                        EnableCaching="false" 
                        CompletionSetCount="10"
                        FirstRowSelected="false" 
                        UseContextKey="true" 
                        TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
</asp:Content>

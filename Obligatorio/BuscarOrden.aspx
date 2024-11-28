<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarOrden.aspx.cs" Inherits="Obligatorio.BuscarOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Ingresa el número de una orden "></asp:Label>
    <asp:TextBox ID="txtNumeroOrden" runat="server" Required Type="Number"></asp:TextBox>
    <br /><br />
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

    <asp:Panel ID="panelDetalles" runat="server" Visible="False">
        <h3>Detalles de la Orden</h3>
        <asp:Label ID="lblEstado" runat="server" Text="Estado: " />
        <br />
        <asp:Label ID="lblCliente" runat="server" Text="Cliente: " />
        <br />
        <asp:Label ID="lblTecnico" runat="server" Text="Técnico: " />
        <br />
        <asp:Label ID="lblComentarios" runat="server" Text="Comentarios: " />
    </asp:Panel>
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>

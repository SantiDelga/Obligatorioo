<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarOrden.aspx.cs" Inherits="Obligatorio.BuscarOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Ingresa el número de una orden "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Required Type="Number"></asp:TextBox>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenesTrabajo.aspx.cs" Inherits="Obligatorio.OrdenesTrabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Gestión de Órdenes de Trabajo</h2>

    <asp:Label ID="lblCliente" runat="server" Text="Cliente:"></asp:Label>
    <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList>
    <br />

    <asp:Label ID="lblTecnico" runat="server" Text="Técnico:"></asp:Label>
    <asp:DropDownList ID="ddlTecnico" runat="server"></asp:DropDownList>
    <br />

    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción del problema:"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" Required></asp:TextBox>
    <br />

    <asp:Button ID="btnCrearOrden" runat="server" Text="Crear Orden" OnClick="btnCrearOrden_Click" />
    <br />
    <br />

    <asp:GridView ID="gvOrdenes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
        OnRowEditing="gvOrdenes_RowEditing" OnRowUpdating="gvOrdenes_RowUpdating"
        OnRowDeleting="gvOrdenes_RowDeleting" OnRowCommand="gvOrdenes_RowCommand">
        <Columns>
            <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
            <asp:BoundField DataField="Tecnico" HeaderText="Técnico" />
            <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción del Problema"/>
            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Estado">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server">
                        <asp:ListItem>Pendiente</asp:ListItem>
                        <asp:ListItem>En Progreso</asp:ListItem>
                        <asp:ListItem>Completada</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <%# Eval("Estado") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios">
                <ItemTemplate>
                    <asp:Button ID="btnComentarios" runat="server" Text="Agregar Comentario"
                        CommandName="AgregarComentario" CommandArgument='<%# Eval("NumeroOrden") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>

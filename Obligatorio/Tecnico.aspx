<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="Obligatorio.Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Nombre "></asp:Label>
    <asp:TextBox ID="txtNombreTecnico" runat="server" Required></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Apellido "></asp:Label>
    <asp:TextBox ID="txtApellidoTecnico" runat="server" Required></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="CI "></asp:Label>
    <asp:TextBox ID="txtCITecnico" runat="server" type="Number" Required></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Especialidad "></asp:Label>
    <asp:TextBox ID="txtEspecialidadTecnico" runat="server" Required></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Agregar técnico" OnClick="Button1_Click" />
    <br>
    <br>
    <asp:GridView ID="gvTecnico" runat="server" AutoGenerateColumns="False"
        CssClass="table table-striped" OnRowCommand="gvTecnico_RowCommand" OnRowEditing="gvTecnico_RowEditing"
        OnRowCancelingEdit="gvTecnico_RowCancelingEdit" OnRowUpdating="gvTecnico_RowUpdating"
        OnRowDeleting="gvTecnico_RowDeleting">
        <Columns>

            <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                <ItemTemplate>
                    <%# Eval("Nombre") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombreTecnico" runat="server" Text='<%# Eval("Nombre") %>' />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Apellido" SortExpression="Apellido">
                <ItemTemplate>
                    <%# Eval("Apellido") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtApellidoTecnico" runat="server" Text='<%# Eval("Apellido") %>' />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="CI" SortExpression="CI">
                <ItemTemplate>
                    <%# Eval("CI") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCITecnico" runat="server" Text='<%# Eval("CI") %>' />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Especialidad" SortExpression="Especialidad">
                <ItemTemplate>
                    <%# Eval("Especialidad") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEspecialidadTecnico" runat="server" Text='<%# Eval("Especialidad") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br>
    <br>
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>

<script type="text/javascript">
    // Función para permitir solo números
    function soloNumeros(event) {
        var keyCode = event.which || event.keyCode;
        // Permite la tecla de retroceso (backspace), los números y los signos de puntuación si se requieren (como el guión para teléfonos internacionales).
        if (keyCode >= 48 && keyCode <= 57 || keyCode == 8) {
            return true;
        }
        return false;
    }
</script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Obligatorio.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Nombre "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" Required></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="Label2" runat="server" Text="Apellido "></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server" Required></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="Label3" runat="server" Text="CI "></asp:Label>
    <asp:TextBox ID="txtCi" runat="server" Required Type="Number"></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="Label4" runat="server" Text="Dirección "></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="Label5" runat="server" Text="Teléfono "></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server" Type="Number"></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="Label6" runat="server" Text="Email "></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br>
    <br>
    <asp:Button ID="Button1" runat="server" Text="Agregar cliente" OnClick="Button1_Click" />
    <br>
    <br>
<asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="False" 
    CssClass="table table-striped" OnRowCommand="gvCliente_RowCommand" OnRowEditing="gvCliente_RowEditing"
    OnRowCancelingEdit="gvCliente_RowCancelingEdit" OnRowUpdating="gvCliente_RowUpdating" 
    OnRowDeleting="gvCliente_RowDeleting">
    <Columns>
        
        <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
            <ItemTemplate>
                <%# Eval("Nombre") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtNombre" runat="server" Text='<%# Eval("Nombre") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        
        <asp:TemplateField HeaderText="Apellido" SortExpression="Apellido">
            <ItemTemplate>
                <%# Eval("Apellido") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtApellido" runat="server" Text='<%# Eval("Apellido") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        
        <asp:TemplateField HeaderText="CI" SortExpression="CI">
            <ItemTemplate>
                <%# Eval("CI") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCI" runat="server" Text='<%# Eval("CI") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        
        <asp:TemplateField HeaderText="Dirección" SortExpression="Direccion">
            <ItemTemplate>
                <%# Eval("Direccion") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Eval("Direccion") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        
        <asp:TemplateField HeaderText="Teléfono" SortExpression="Telefono">
            <ItemTemplate>
                <%# Eval("Telefono") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTelefono" runat="server" Text='<%# Eval("Telefono") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        
        <asp:TemplateField HeaderText="Email" SortExpression="Email">
            <ItemTemplate>
                <%# Eval("Email") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>' />
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



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogoTecnicos.aspx.cs" Inherits="bancouh1.Presentacion.CatalogoTecnicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Catalogo de Tecnicos</title>
    <link rel="stylesheet" type="text/css" href="/css/Estilo.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="Menu.aspx">Inicio</a></li>
                <li><a href="CatalogoUsuarios.aspx">Usuario</a></li>
                <li><a class="active" href="CatalogoTecnicos.aspx">Tecnicos</a></li>
            </ul>

            <h2>Catalogo de Tecnicos</h2>
            <p>Agregar, modificar y eliminar tecnicos.</p>

            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />

            <div>
                <label for="txtTecnicoID">ID del tecnico:</label>
                <asp:TextBox ID="txtTecnicoID" runat="server"></asp:TextBox>
                <br />

                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <br />

                <label for="txtEspecialidad">Especialidad:</label>
                <asp:TextBox ID="txtEspecialidad" runat="server"></asp:TextBox>
                <br />
            </div>
            <br />

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click" />
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

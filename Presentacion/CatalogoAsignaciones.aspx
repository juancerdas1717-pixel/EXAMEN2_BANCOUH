<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogoAsignaciones.aspx.cs" Inherits="bancouh1.Presentacion.CatalogoAsignaciones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Catalogo de Asignaciones</title>
    <link rel="stylesheet" type="text/css" href="/css/Estilo.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="Menu.aspx">Inicio</a></li>
                <li><a href="CatalogoUsuarios.aspx">Usuarios</a></li>
                <li><a href="CatalogoTecnicos.aspx">Tecnicos</a></li>
                <li><a class="active" href="CatalogoAsignaciones.aspx">Asignaciones</a></li>
            </ul>

            <h2>Catalogo de Asignaciones</h2>
            <p>Agregar, modificar y eliminar asignaciones de tecnicos a reparaciones.</p>

            <asp:GridView ID="GridViewAsignaciones" runat="server" AutoGenerateColumns="true"
                EmptyDataText="No hay asignaciones registradas."></asp:GridView>
            <br />

            <div>
                <label for="txtAsignacionID">ID de asignacion:</label>
                <asp:TextBox ID="txtAsignacionID" runat="server"></asp:TextBox>
                <br />

                <label for="txtReparacionID">ID de reparacion:</label>
                <asp:TextBox ID="txtReparacionID" runat="server"></asp:TextBox>
                <br />

                <label for="txtTecnicoID">ID del tecnico:</label>
                <asp:TextBox ID="txtTecnicoID" runat="server"></asp:TextBox>
                <br />

                <label for="txtFechaAsignacion">Fecha de asignacion:</label>
                <asp:TextBox ID="txtFechaAsignacion" runat="server" TextMode="Date"></asp:TextBox>
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

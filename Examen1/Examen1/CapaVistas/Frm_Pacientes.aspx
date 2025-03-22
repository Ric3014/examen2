<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Pacientes.aspx.cs" Inherits="Examen1.CapaVistas.Frm_Pacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="\css\Menucss.css" rel="stylesheet" />
    <link href="\css\CRUDcss.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <ul>
            <li><a href="Frm_Pacientes.aspx">Pacientes</a></li>
            <li><a href="Frm_Medicos.aspx">Medicos</a></li>
            <li><a href="#Frm_Consultas.aspx">Consultas</a></li>
        </ul>

        <div>
        </div>
        <div>
            <h1>Catalogo de Pacientes</h1>
        </div>

        <div class="contenedor">
            <div class="formulario">
                <asp:Label ID="Label1" runat="server" Text="Cedula"></asp:Label>
                <asp:TextBox ID="tcedula" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="tnombre" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Primer Apellido"></asp:Label>
                <asp:TextBox ID="tapellido" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                <asp:TextBox ID="tFechaNacimiento" runat="server"></asp:TextBox>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false"></asp:Calendar>
                <asp:Button ID="btnMostrarCalendario" runat="server" Text="Mostrar Calendario" OnClick="btnMostrarCalendario_Click" />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Edad"></asp:Label>
                <asp:TextBox ID="tedad" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Telefono"></asp:Label>
                <asp:TextBox ID="ttelefono" runat="server"></asp:TextBox>
                <br />

                <div class="buttons-container">
                    <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn-crud" OnClick="bagregar_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Modificar" CssClass="btn-crud" OnClick="bmodificar_Click" />
                    <asp:Button ID="Button4" runat="server" Text="Borrar" CssClass="btn-crud" OnClick="bborrar_Click" />
                </div>
            </div>

            <div class="grid-container">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"
                    CssClass="table" BorderColor="Black" BorderWidth="1px"
                    CellPadding="9" CellSpacing="9" BackColor="White"
                    AllowPaging="True" PageSize="9" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Medicos.aspx.cs" Inherits="Examen1.CapaVistas.Frm_Medicos" %>

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
            <li><a href="Frm_Consultas.aspx">Consultas</a></li>
        </ul>

        <div>
        </div>
        <div>
            <h1>Catalogo de Medicos</h1>
        </div>

        <div class="contenedor">
            <div class="formulario">
                <asp:Label ID="Label1" runat="server" Text="ID Medico"></asp:Label>
                <asp:TextBox ID="tidmedico" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="tnombre" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                <asp:TextBox ID="tespecialidad" runat="server"></asp:TextBox>
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
        <div>
        </div>
    </form>
</body>
</html>

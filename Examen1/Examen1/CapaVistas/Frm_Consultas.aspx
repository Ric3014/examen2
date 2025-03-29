<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Consultas.aspx.cs" Inherits="Examen1.CapaVistas.Frm_Consultas" %>

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
        <div>
            <ul>
                <li><a href="Frm_Pacientes.aspx">Pacientes</a></li>
                <li><a href="Frm_Medicos.aspx">Medicos</a></li>
                <li><a href="Frm_Consultas.aspx">Consultas</a></li>
            </ul>

            <div>
            </div>
            <div>
                <h1>Catalogo de Consultas</h1>
            </div>

            <div class="contenedor">
                <div class="formulario">
                    <asp:Label ID="Label1" runat="server" Text="ID Consulta"></asp:Label>
                    <asp:TextBox ID="tIDconsulta" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Cedula"></asp:Label>
                    <asp:TextBox ID="tcedula" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="ID Medico"></asp:Label>
                    <asp:TextBox ID="tIDmedico" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Fecha de Atencion:"></asp:Label>
                    <asp:TextBox ID="tFechaAtencion" runat="server"></asp:TextBox>
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false"></asp:Calendar>
                    <asp:Button ID="btnMostrarCalendario" runat="server" Text="Mostrar Calendario" OnClick="btnMostrarCalendario_Click" />
                    <br />

                    <asp:Label ID="LabelHora" runat="server" Text="Hora de Atención:"></asp:Label>
                    <select id="hora" name="hora">
                        <option value="01">01</option>
                        <option value="02">02</option>
                        <option value="03">03</option>
                        <option value="04">04</option>
                        <option value="05">05</option>
                        <option value="06">06</option>
                        <option value="07">07</option>
                        <option value="08">08</option>
                        <option value="09">09</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                    </select>
                    :
                    <select id="minutos" name="minutos">
                        <option value="00">00</option>
                        <option value="15">15</option>
                        <option value="30">30</option>
                        <option value="45">45</option>
                    </select>
                    <select id="ampm" name="ampm">
                        <option value="AM">AM</option>
                        <option value="PM">PM</option>
                    </select>

                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Colsultorio"></asp:Label>
                    <asp:TextBox ID="tconsultorio" runat="server"></asp:TextBox>
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
        </div>
    </form>
</body>
</html>

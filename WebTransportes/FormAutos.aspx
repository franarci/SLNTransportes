<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormAutos.aspx.cs" Inherits="WebTransportes.FormAutos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 69px;
        }
        .auto-style4 {
            height: 23px;
            width: 69px;
        }
        .auto-style5 {
            width: 154px;
        }
        .auto-style6 {
            height: 23px;
            width: 154px;
        }
        .auto-style7 {
            margin-left: 0px;
        }
        .auto-style8 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">Marca</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="dropMarcas" runat="server" Height="16px" Width="129px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Modelo</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style3">Matricula</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Precio</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Id</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" class="auto-style8">Buscar&nbsp; autos por marca&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="dropFiltroMarcas" runat="server" CssClass="auto-style7" Height="16px" Width="123px" OnSelectedIndexChanged="Page_Load">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gridAutos" runat="server" Height="201px" Width="567px">
        </asp:GridView>
    </form>
</body>
</html>

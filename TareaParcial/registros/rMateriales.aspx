<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rMateriales.aspx.cs" Inherits="TareaParcial.rMateriales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
        .auto-style2 {
            width: 177px;
        }
        .auto-style3 {
            width: 35px;
        }
        .auto-style4 {
            width: 80px;
        }
    </style>
    <h1>Registro de materiales</h1>

</head>
  


<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">
<asp:label runat="server" text="Label">ID</asp:label>
                </td>
                <td class="auto-style2">
<asp:textbox ID="txtBuscar" runat="server"></asp:textbox>
                </td>
                <td class="auto-style4">
<asp:button ID="btnBuscar" runat="server" text="Buscar" CssClass="auto-style1" />
  
                </td>
                <td>
  
<asp:textbox  ID="TxtFecha" runat="server" TextMode="Date"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
<asp:label ID="Razon" runat="server" text="Razon">Razon</asp:label>
                </td>
                <td class="auto-style2">
<asp:textbox ID="txtRazon" runat="server"></asp:textbox>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Material</td>
         
                <td class="auto-style2">Cantidad</td>
                <td class="auto-style4">Precio</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:TextBox ID="TxtDescripcionM" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtCantidad" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TxtPrecio" runat="server" TextMode="Number"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:Button ID="BtnADD" runat="server" Text="ADD" OnClick="BtnADD_Click" />
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <br/>
                    <br/>
                    <asp:GridView ID="GVDetalle" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:BoundField DataField="Material" HeaderText="Material" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

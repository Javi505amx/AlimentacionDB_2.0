<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WOPTH.aspx.cs" Inherits="AlimentacionDB_2._0.WOPTH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
    <title>Work Order PTH</title>
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <style type="text/css">
        #form1{
            text-align: center;
        }
        #divButtons{
            position: absolute;
            bottom:50px;
            right: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:DropDownList ID="ddlFunction" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlFunction_SelectedIndexChanged">
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                <asp:ListItem Value="Create" Text="Nueva WO"></asp:ListItem>
                <asp:ListItem Value="Update" Text="Modificar WO"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblWorkOrder" runat="server" Text="Work Order:" Font-Size="20px" Font-Bold="true"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtWorkOrder" Font-Size="20px" Enabled="false" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtWorkOrder_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblModel" runat="server" Text="Modelo:" Font-Bold="true" Font-Size="20px"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtModel" Font-Size="20px" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblMain" runat="server" Text="Main:" Font-Bold="true" Font-Size="20px"></asp:Label>
            <br />
            <asp:TextBox ID="txtMain" runat="server" Font-Size="20px" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblQty" runat="server" Text="Cantidad:" Font-Bold="true" Font-Size="20px"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtQty" Font-Size="20px" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblRate" runat="server" Text="Rate:" Font-Bold="true" Font-Size="20px"></asp:Label>
            <br />
            <asp:TextBox ID="txtRate" runat="server" Font-Size="20px" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblRateMin" runat="server" Text="Rate/Min:" Font-Bold="true" Font-Size="20px"></asp:Label>
            <br />
            <asp:TextBox ID="txtRateMin" runat="server" Font-Size="20px" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblResult" runat="server" Font-Size="20px" Font-Bold="true" Text=""></asp:Label>
            <br />
            <br />
            <asp:LinkButton runat="server" ID="btnSave" Text="Guardar" CssClass="btn btn-success" Font-Size="20px" Visible="false" OnClick="btnSave_Click"></asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton runat="server" ID="btnCancel" Text="Cancelar" CssClass="btn btn-danger" Font-Size="20px" Visible="false" OnClick="btnCancel_Click"></asp:LinkButton>
        </div>
        <br />
        <asp:LinkButton ID="btnClose2" runat="server" Font-Size="200%" CssClass="btn btn-primary" PostBackUrl="~/Menu.aspx">
            <span class="fas fa-backspace" aria-hidden="true"></span> Atras
        </asp:LinkButton>
    </form>
</body>
</html>

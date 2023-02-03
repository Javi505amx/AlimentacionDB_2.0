<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteFS.aspx.cs" Inherits="AlimentacionDB_2._0.DeleteFS" %>

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
    <title>Eliminacion de FS</title>
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
            <br />
            <asp:Label runat="server" ID="lblTitle" Text="Ingresa Work Order" Font-Size="30px" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <br />
            <asp:TextBox runat="server" ID="txtWorkOrder" Font-Size="30px" OnTextChanged="txtWorkOrder_TextChanged" AutoCompleteType="Disabled" style="text-transform:uppercase;"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="lblWorkOrder" runat="server" Text="" Font-Size="30px" Font-Bold="true" ForeColor="Blue"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblModel" runat="server" Text="" Font-Size="30px" Font-Bold="true" ForeColor="Blue"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" ID="lblResult" Text="" Font-Size="30px" Font-Bold="true" ForeColor="Green"></asp:Label>
            <br />
            <br />
            <br />
            <asp:LinkButton runat="server" ID="btnDelete" Text="Eliminar" CssClass="btn btn-danger" Font-Size="30px" Visible="false" OnClick="btnDelete_Click"></asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton runat="server" ID="btnCancel" Text="Cancelar" CssClass="btn btn-warning" Font-Size="30px" Visible="false" OnClick="btnCancel_Click"></asp:LinkButton>
        </div>
        <asp:LinkButton ID="btnClose2" runat="server" Font-Size="200%" CssClass="btn btn-primary" PostBackUrl="~/Menu.aspx">
            <span class="fas fa-backspace" aria-hidden="true"></span> Atras
        </asp:LinkButton>
    </form>
</body>
</html>

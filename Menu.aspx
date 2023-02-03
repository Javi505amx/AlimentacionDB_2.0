<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="AlimentacionDB_2._0.Menu" %>

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
    <title>Menu</title>
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <style type="text/css">
        #menu{
            text-align: center;
        }
    </style>
</head>
<body class="bg-light">
    <form id="menu" runat="server" style="font-family:Calibri" title="Menu">
        <br />
        <br />
        <br />
        <div id="divLinks">
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnDeleteFS" Font-Size="200%" PostBackUrl="~/DeleteFS.aspx">
                <span class="fas fa-trash" aria-hidden="true"></span> Eliminación de FS SMT
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnWOSMT" Font-Size="200%" PostBackUrl="~/WOSMT.aspx">
                <span class="fas fa-list" aria-hidden="true"></span> Work Order SMT
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnWOPTH" Font-Size="200%" PostBackUrl="~/WOPTH.aspx">
                <span class="fas fa-list" aria-hidden="true"></span> Work Order PTH
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnSerials" Font-Size="200%" PostBackUrl="~/ImportSerials.aspx">
                <span class="fas fa-barcode" aria-hidden="true"></span> Importación de Seriales
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnKNSMT" Font-Size="200%" PostBackUrl="~/ImportKNSMT.aspx">
                <span class="fas fa-list" aria-hidden="true"></span> Kitting Note SMT
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnKNPTH" Font-Size="200%" PostBackUrl="~/ImportKNPTH.aspx">
                <span class="fas fa-list" aria-hidden="true"></span> Kitting Note PTH
            </asp:LinkButton>
                        <br />
            <br />
                        <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="LinkButton1" Font-Size="200%" PostBackUrl="~/AlternateNP.aspx">
                <span class="fas fa-list" aria-hidden="true"></span> Importar Alternos SMT
            </asp:LinkButton>
        </div>
    </form>
</body>
</html>

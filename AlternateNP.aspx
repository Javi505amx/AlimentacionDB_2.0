<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlternateNP.aspx.cs" Inherits="AlimentacionDB_2._0.AlternateNP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Importacion de Seriales</title>
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap4.min.css"/>
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#gvData").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        function preventBack() {window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () {null};
    </script>
    <style type="text/css">
        #btnLogout{
            float: right;
        }
    </style>
</head>
<body>
<form id="populateForm" runat="server" style="font-family: Calibri; font-weight: 700;" title="Importación de Seriales">
        <div class="container py-3">
            <h2 class="text-center text-uppercase">Importación de alternos</h2>
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" PostBackUrl="~/Menu.aspx">
                <span class="fa fa-backspace" aria-hidden="true"></span> Atrás
            </asp:LinkButton>
            <div class="card">
                <div class="card-header bg-secondary text-uppercase text-white">
                    <h5>SUBIR Alternos</h5>
                </div>
                <div class="card-body">
                    <button style="margin-bottom:10px;" type="button" class="btn btn-secondary" data-toggle="modal" data-target="#myModal">
                        <i class="fa fa-plus-circle" aria-hidden="true"></i> Seleccionar Archivo
                    </button>
                    <div class="modal fade" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Select File</h4>
                                    <button type="button" class="close" data-dismiss="modal">X</button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Choose Excel File</label>
                                                <div class="input-group">
                                                    <div class="custom-file">
                                                        <asp:FileUpload ID="fuData" CssClass="custom-file-input" runat="server"/>
                                                        <label class="custom-file-label"></label>
                                                    </div>
                                                    <label id="filename"></label>
                                                    <div class="input-group-append">
                                                        <asp:Button Text="Subir" ID="btnUpload" runat="server" CssClass="btn btn-outline-secondary" OnClick="btnUpload_Click"/>
                                                    </div>
                                                </div>
                                                <asp:Label ID="lblMessage" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:GridView ID="GridView1" HeaderStyle-CssClass="bg-secondary text-white" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered``">
                        <EmptyDataTemplate>
                            <div class="text-center">Sin registros</div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="WorkOrder" DataField="WorkOrder"/>
                            <asp:BoundField HeaderText="Model" DataField="Model" />
                            <asp:BoundField HeaderText="Quantity" DataField="Quantity"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

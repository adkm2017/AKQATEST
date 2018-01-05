<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="amount-in-words.aspx.cs" Inherits="AkqaTest.amount_in_words" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AmountInWords</title>
    <script src="Scripts/Jqueryv3.2.1.js"></script>
    <link href="Assets/css/main.css" rel="stylesheet" />
    <%--  <script src="Scripts/CallWCFService.js"></script>--%>
    <%-- <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>--%>
    <script type="text/javascript" >
        $(document).ready(function () {
            $('#btnGetData').click(function () {

                var data1 = {
                    name: $('#txtName').val(),
                    amount: $('#txtAmount').val(),
                };
                //alert(data1);
                var dataasstring = JSON.stringify(data1);
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/AKQA.asmx/GetPersonData",
                    data: dataasstring,
                    success: function (data) {
                        $(".divPerson").html("<p>" + data.d + "</p>");
                    },
                    error: function (d) {
                        alert("Error");
                    }
                });
            });
        });
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div class="main-content">

        <div>
            <h1>Person Details.. </h1>
        </div>

        <div>
            <label for="" class="label">Person's Name:</label>
            <input type="text" id="txtName" class="input"/>
            <label for="" class="label"> Amount:</label>
            <input type="text" id="txtAmount" class="input"/>
            <input type="button" id="btnGetData" value="Get Data" class="getdata"/><br/>
            <div class="divPerson">Test</div>
        </div>
        
    </div>
</form>
</body>
</html>

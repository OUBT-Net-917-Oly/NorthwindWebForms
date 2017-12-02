<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="NorthwindWebApp.pages.CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer list</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Customer list</h2>
        <div>
            <table>
                <tr>
                    <td><strong>Customer Id</strong></td>
                    <td><strong>Customer Name</strong></td>
                </tr>

                <% foreach (var customer in Customers)
                   {
                        %>
                    <tr>
                        <td><%= customer.CustomerId %></td>
                        <td><%= customer.CompanyName %></td>
                    </tr>
                <% } %>

            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Otemanu.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>

    <link rel="stylesheet" type="text/css" href="../Styles/Otemanu.css" />
</head>
<body>
    <form id="RegisterForm" runat="server">
    <div class="centerBlock boarder">
        <table class="centerBlock">
            <tr>
                <th colspan="3">Registration</th>
            </tr>
            <tr>
                <td>Username</td>
                <td><asp:TextBox ID="TextBoxUsername" runat="server" /></td>                
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td><asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button Text="Submit" runat="server" OnClick="RegisterUser" /></td>
                <td></td>
            </tr>
        </table>

        <a class="centerLink" href="Login.aspx">Login</a> 
    </div>
    </form>
</body>
</html>

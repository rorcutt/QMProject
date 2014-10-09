<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Otemanu.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link rel="stylesheet" type="text/css" href="../Styles/Otemanu.css" />
</head>
<body>
    <form id="LoginForm" runat="server">
        <div class="centerBlock boarder">
            <table class="centerBlock">
                <tr>
                    <th colspan="2">Login</th>
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
                    <td></td>
                    <td><asp:Button Text="Login" runat="server" OnClick="ValidateUser" /></td>
                </tr>
            </table>  
        
            <a class="centerLink" href="Register.aspx">Register</a> 
        </div>
                    
    </form>
</body>
</html>

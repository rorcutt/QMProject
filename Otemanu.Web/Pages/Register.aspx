<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Otemanu.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Register</title>

</head>
<body>
    <form id="RegisterForm" runat="server">
        <div>
            <h4>Register a new user</h4>
            <p>
                <asp:Literal runat="server" ID="StatusMessage" />
            </p>                
            <div>
                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="UserName" />                
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />                
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />                
                </div>
            </div>
            <div>
                <div>
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

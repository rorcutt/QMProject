<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Otemanu.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   <title>Otemanu - Login</title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Log In</h4>

            <p>
                <asp:Literal runat="server" ID="StatusText" />
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
                <div>
                    <asp:Button runat="server" OnClick="SignIn" Text="Log in" />
                </div>
            </div> 
            <div>
                <asp:HyperLink ID="RegisterLink" NavigateUrl="~/Pages/Register.aspx" Text="Register New User" runat="server"></asp:HyperLink>           
            </div>            
        </div>
   </form>
</body>
</html>
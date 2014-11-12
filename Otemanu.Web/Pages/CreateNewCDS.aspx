<%@ Page Title="" Language="C#" MasterPageFile="~/Otemanu.Master" AutoEventWireup="true" CodeBehind="CreateNewCDS.aspx.cs" Inherits="Otemanu.Pages.CreateNewCDS" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create New Custom Defined Screen</h2>
    <asp:Label runat="server" Text="Name"></asp:Label><asp:TextBox ID="CDSNameTextBox" runat="server"></asp:TextBox>
    <asp:Label runat="server" Text="Description"></asp:Label><asp:TextBox ID="CDSDescriptionTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="CreateNewCDSButton" runat="server" Text="Create" OnClick="CreateNewCDSButton_Click"/>
</asp:Content>

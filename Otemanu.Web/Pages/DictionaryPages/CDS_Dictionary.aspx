<%@ Page Title="" Language="C#" MasterPageFile="~/Otemanu.Master" AutoEventWireup="true" CodeBehind="CDS_Dictionary.aspx.cs" Inherits="Otemanu.CDS_Dictionary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TableRow runat="server">

            <asp:TableCell  runat="server">
                <asp:Label ID="QueryMnemonic" runat="server" Text="Query Mnemonic "></asp:Label>
                <asp:TextBox ID="QueryMnemonicBox"  MaxLength="10" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    <asp:TableRow runat="server">
            <asp:TableCell  runat="server">
                <asp:Label ID="QueryDescription" runat="server" Text="Query Description"></asp:Label>
                <asp:TextBox ID="QueryDescriptionBox" Width="50%" MaxLength="60" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    <asp:TableRow runat="server">
            <asp:TableCell Width="10%" runat="server">
                <asp:Label ID="QueryActive" Width="5%" runat="server" Text="Active "></asp:Label>
                <asp:DropDownList ID="ActiveList" runat="server">
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
                    </asp:TableRow>
        <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>

    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
    </asp:Panel>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />

</asp:Content>
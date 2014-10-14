<%@ Page Title="" Language="C#" MasterPageFile="~/Otemanu.Master" AutoEventWireup="true" CodeBehind="Dictionary.aspx.cs" Inherits="Otemanu.Dictionary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <table>
        <tr><td>
        <b>DICTIONARIES</b>
            </td></tr>
        <tr>
            <td>
    <asp:LinkButton PostBackUrl="~/Pages/DictionaryPages/Query_Dictionary.aspx"  ID="QueryDict" runat="server" Height="16px" Width="345px">Query Dictionary</asp:LinkButton>
                </td>
            </tr>
        <tr>
            <td>
            <asp:LinkButton PostBackUrl="~/Pages/DictionaryPages/CDS_Dictionary.aspx"  ID="CDS_Dictionary" runat="server" Height="16px" Width="345px">Custom Defined Screen Dictionary</asp:LinkButton>
            </td>
                </tr>
                </table>
 
</asp:Content>
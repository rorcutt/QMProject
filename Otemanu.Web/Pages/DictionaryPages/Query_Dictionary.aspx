<%@ Page Title="" Language="C#" MasterPageFile="~/Otemanu.Master" AutoEventWireup="true" CodeBehind="Query_Dictionary.aspx.cs" Inherits="Otemanu.Query_Dictionary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Table ID="Table1" runat="server" Height="92px" Width="934px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <div style="text-align: left">
                    <b><asp:Label ID="NewEditLabel" runat="server" Text="New Query"></asp:Label></b>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
        <asp:TableRow runat="server">

            <asp:TableCell Width="20%" runat="server">
                <asp:Label ID="QueryMnemonic" runat="server" Text="Query Mnemonic "></asp:Label>
                <asp:TextBox ID="QueryMnemonicBox" width="50%" MaxLength="10" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="60%" runat="server">
                <asp:Label ID="QueryDescription" runat="server" Text="Query Description"></asp:Label>
                <asp:TextBox ID="QueryDescriptionBox" Width="80%" MaxLength="60" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="20%" runat="server">
                <asp:Label Width="100%" ID="QueryType" runat="server" Text="Query Type"></asp:Label>
                <asp:DropDownList Width="80%" ID="QueryTypeSelect" runat="server">
                    <asp:ListItem>Label</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
                    </asp:TableRow>
        <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>


            <asp:TableRow runat="server">

            <asp:TableCell Width="10%" runat="server">
                <asp:Label ID="QueryActive" Width="90%" runat="server" Text="Active "></asp:Label>
                <asp:DropDownList ID="ActiveList" runat="server">
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
                <asp:TableCell Width="60%" runat="server">
                <asp:Label ID="QueryLabelText" runat="server" Text="Query Label Text "></asp:Label>
                 <asp:TextBox ID="QueryLabelTextBox" width="80%" MaxLength="120" runat="server"></asp:TextBox>
            </asp:TableCell>
                <asp:TableCell>
                    <asp:Button OnClick="Submit_Click" ID="Submit" runat="server" Text="Submit New" />
                    </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="QueryGrid" OnSelectedIndexChanged="QueryGrid_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" DataKeyNames="Query_Mnemonic" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." Height="149px" Width="931px" Style="margin-top: 0px" AllowSorting="True">
        <Columns>
            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
            <asp:BoundField DataField="Query_Mnemonic" HeaderText="Query Mnemonic" ReadOnly="True" SortExpression="Query_Mnemonic" />
            <asp:BoundField DataField="Query_Description" HeaderText="Query Description" SortExpression="Query_Description" />
            <asp:BoundField DataField="Query_Type" HeaderText="Query Type" SortExpression="Query_Type" />
            <asp:BoundField DataField="Query_Active" HeaderText="Query_Active" SortExpression="Query_Active" />
            <asp:BoundField DataField="Query_Label_Text" HeaderText="Query_Label_Text" SortExpression="Query_Label_Text" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [QueryDict] ORDER BY [Query_Active] DESC, [Query_Mnemonic]">
    </asp:SqlDataSource>
    <br />
    <br />
</asp:Content>

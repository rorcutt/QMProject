<%@ Page Title="" Language="C#" MasterPageFile="~/Otemanu.Master" AutoEventWireup="true" CodeBehind="Dictionary.aspx.cs" Inherits="Otemanu.Dictionary" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="CDSDefinitionDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="EXEC pr_GetCDSDefinition @CustomDefinedScreen">
        <SelectParameters>
            <asp:ControlParameter ControlID="CDSDropDownList" PropertyName="SelectedValue" Name="CustomDefinedScreen"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="CDSDropDownListDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="EXEC pr_GetAllCDS"></asp:SqlDataSource>

    <asp:SqlDataSource ID="QueryDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="EXEC pr_GetQuerysFromCDS @CustomDefinedScreen">
        <SelectParameters>
            <asp:ControlParameter ControlID="CDSDropDownList" PropertyName="SelectedValue" Name="CustomDefinedScreen"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:Table runat="server" Width="400px">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1.5">
                <asp:Label ID="CDSDropDownListLabel" runat="server" Text="Choose a CDS" Font-Bold="True"></asp:Label><br/>
                <asp:DropDownList ID="CDSDropDownList" runat="server" DataSourceID="CDSDropDownListDataSource" DataTextField="Name" DataValueField="Id" AutoPostBack="True"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1.5">
                <asp:Label runat="server" Text="Included Queries" Font-Bold="True"></asp:Label>        
                <asp:DataList ID="QueryDataList" runat="server" DataSourceID="QueryDataSource">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Name") %>' runat="server"/><br/>
                    </ItemTemplate>
                </asp:DataList> 
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br/>
    <asp:Button ID="PreviewCDS" runat="server" Text="Preview CDS" OnClick="PreviewCDS_Click"/>
    <br/>

    <asp:PlaceHolder ID="DynamicCDSContent" runat="server"></asp:PlaceHolder>

</asp:Content>
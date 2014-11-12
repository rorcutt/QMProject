<%@ Page Title="" Language="C#" MasterPageFile="~/Otemanu.Master" AutoEventWireup="true" CodeBehind="CDSDictionary.aspx.cs" Inherits="Otemanu.CDSDictionary" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="QueriesByCDSDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="pr_GetQueriesFromCDS" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="CDSDropDownList" PropertyName="SelectedValue" Name="CustomDefinedScreen" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="AllCDSDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="pr_GetAllCDS" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="AllQueriesDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="pr_GetAllQueries" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:SqlDataSource ID="CDSDefinitionDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="EXEC pr_GetCDSDefinition @CustomDefinedScreen">
        <SelectParameters>
            <asp:ControlParameter ControlID="CDSDropDownList" PropertyName="SelectedValue" Name="CustomDefinedScreen"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <h2>CDS Dictionary</h2>

    <asp:Table runat="server" Width="550px">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1.5">
                <asp:Label ID="CDSDropDownListLabel" runat="server" Text="Choose a CDS" Font-Bold="True"></asp:Label><br/>
                <asp:DropDownList ID="CDSDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CDSDropDownList_SelectedIndexChanged"></asp:DropDownList><br/><br/>
                <div><asp:HyperLink runat="server" NavigateUrl="~/Pages/CreateNewCDS.aspx">Create New CDS</asp:HyperLink></div><br />
                <div><asp:Button ID="DeleteCDSButton" runat="server" Text="Delete CDS" OnClick="DeleteCDSButton_Click"/></div>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1.5">
                <asp:Label runat="server" Text="Included Queries" Font-Bold="True"></asp:Label>        
                <asp:CheckBoxList ID="QueryCheckBoxList" runat="server" DataSourceID="AllQueriesDataSource" DataTextField="Name" DataValueField="Id"></asp:CheckBoxList> 
                <asp:Button ID="SaveCDSChangesButton" runat="server" Text="Save Changes" OnClick="SaveCDSChangesButton_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br/>
    <asp:Button ID="PreviewCDS" runat="server" Text="Preview CDS" OnClick="PreviewCDS_Click"/>
    <br/>

    <asp:PlaceHolder ID="DynamicCDSContent" runat="server"></asp:PlaceHolder>

</asp:Content>
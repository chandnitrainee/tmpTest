<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="EmployeeStatus.aspx.cs" Inherits="EmployeeStatus" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="divInnerContentEmployeeStatus">
        <h2>
            <asp:Label runat="server" ID="lblCompanyName"></asp:Label></h2>
        <h3>
            <asp:Label runat="server" ID="lblHeaderDescription"></asp:Label></h3>
        <asp:UpdatePanel runat="server" ID="updatePanel1">
            <ContentTemplate>
                <telerik:RadGrid AutoGenerateColumns="false" ID="employeeStatusGrid"
                    AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" runat="server"
                    ShowGroupPanel="false" GroupingSettings-CaseSensitive="false"   OnNeedDataSource="employeeStatusGrid_NeedDataSource" OnItemCommand="employeeStatusGrid__ItemCommand" CellSpacing="0" GridLines="None"> 
                    <PagerStyle Mode="NextPrevAndNumeric" />
                    <MasterTableView TableLayout="Fixed">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EmployeeName"
                                SortExpression="EmployeeName" HeaderStyle-Width="160px" FilterControlWidth="160px"
                                AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="true" />
                            <%--  <telerik:GridBoundColumn HeaderText="Last Entry" DataField="EntryDescription"
                                SortExpression="LastEntry" HeaderStyle-Width="60px" FilterControlWidth="60px"
                                AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="true" />--%>
                            <telerik:GridBoundColumn HeaderText="Total Hours Worked(HH:MM)" DataField="totalWorkHours" 
                                SortExpression="totalWorkHours" HeaderStyle-Width="60px" FilterControlWidth="40px"
                                AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="true" />
                             <telerik:GridBoundColumn HeaderText="Total Break Hours(HH:MM)" DataField="totalBreakHours"
                                SortExpression="totalBreakHours" HeaderStyle-Width="60px" FilterControlWidth="40px"
                                AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="true" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>


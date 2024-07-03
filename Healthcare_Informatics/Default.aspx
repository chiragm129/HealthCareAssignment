<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Healthcare_Informatics._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Employee Submission Form</h2>

    <div style="margin-bottom: 10px;">
        <asp:Label ID="lblEmployeeCode" runat="server" Text="Employee Code:" />
        <asp:TextBox ID="txtEmployeeCode" runat="server" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name:" />
        <asp:TextBox ID="txtEmployeeName" runat="server" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label ID="lblDateOfBirth" runat="server" Text="Date of Birth:" />
        <asp:TextBox ID="txtDateOfBirth" runat="server" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label ID="lblGender" runat="server" Text="Gender:" />
        <asp:DropDownList ID="ddlGender" runat="server">
            <asp:ListItem Text="Male" Value="1" />
            <asp:ListItem Text="Female" Value="0" />
        </asp:DropDownList>
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label ID="lblDepartment" runat="server" Text="Department:" />
        <asp:TextBox ID="txtDepartment" runat="server" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label ID="lblDesignation" runat="server" Text="Designation:" />
        <asp:TextBox ID="txtDesignation" runat="server" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label ID="lblBasicSalary" runat="server" Text="Basic Salary:" />
        <asp:TextBox ID="txtBasicSalary" runat="server" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" Visible="false" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="false" />
    </div>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>


<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Employee Entry Form</h2>
    <asp:Label ID="lblEmployeeCode" runat="server" Text="Employee Code:"></asp:Label>
    <asp:TextBox ID="txtEmployeeCode" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name:"></asp:Label>
    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date of Birth:"></asp:Label>
    <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
    <asp:DropDownList ID="ddlGender" runat="server">
        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
        <asp:ListItem Text="Female" Value="0"></asp:ListItem>
    </asp:DropDownList><br />
    <asp:Label ID="lblDepartment" runat="server" Text="Department:"></asp:Label>
    <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblDesignation" runat="server" Text="Designation:"></asp:Label>
    <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblBasicSalary" runat="server" Text="Basic Salary:"></asp:Label>
    <asp:TextBox ID="txtBasicSalary" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br />
    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
    <asp:Button ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" Visible="false" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="false" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>--%>

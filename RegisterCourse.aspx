<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/Sitestyles.css"/>
    <title>Course Registration</title>
</head>
    
<body>
    <form id="form1" runat="server">
            <h1>Algonquin College Course Registration</h1>
            <div class="form-container">
            <asp:Label ID="Name" runat="server" Text="Student Name:"></asp:Label>
            <input id="NameBox" type="text" runat="server"/>
            <asp:RadioButtonList ID="RadioButtonList" runat="server" cssclass="RadioButtonList1">
                <asp:ListItem class="btnlist" Text="Full Time"></asp:ListItem>
                <asp:ListItem class="btnlist" Text="Part Time"></asp:ListItem>
                <asp:ListItem class="btnlist" Text="Co-op"></asp:ListItem>
            </asp:RadioButtonList>
                </div>
        <asp:Panel runat="server" ID="pnlSelection">
            <p>Following courses are currently available for registration</p>
            <br />

            <asp:Label ID="ErrorMsgName" class="error" runat="server" Text="You must enter a name!" Visible="False"></asp:Label>
            <asp:Label ID="ErrorMsgFullTime" class="error" runat="server" Text="Your selection exceeds the maximum weekly hours: 16" Visible="False"></asp:Label>
            <asp:Label ID="ErrorMsgPartTime" class="error" runat="server" Text="Your selection exceeds the maximum number of courses: 3" Visible="False"></asp:Label>
            <asp:Label ID="ErrorMsgCoop1" class="error" runat="server" Text="Your selection exceeds the maximum number of courses: 2" Visible="False"></asp:Label>
            <asp:Label ID="ErrorMsgCoop2" class="error" runat="server" Text="Your selection exceeds the maximum weekly hours: 4" Visible="False"></asp:Label><br /><br />

            <asp:CheckBoxList ID="chklst" runat="server"></asp:CheckBoxList>
            <br />
            
            <br />

            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
        </asp:Panel>
    </form>
   


        <asp:Panel runat="server" ID="pnlResult" Visible="false" >
            has enrolled in the following courses
            <asp:Table ID="tblCourses" runat="server" CssClass="table"> 
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Course Title</asp:TableHeaderCell>
                <asp:TableHeaderCell>Weekly Hours</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
       
    </asp:Panel>

</body>
</html>

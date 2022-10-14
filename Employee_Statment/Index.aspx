<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Employee_Statment.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET & MYSQL EMPLOYEE_STATMENT</title>
     <style type="text/css">
.auto-style1 {
text-align: center;
color: saddlebrown;
}
.auto-style2 {
width: 417px;
}
.auto-style6 {
width: 273px;

}
.auto-style7 {
height: 55px;
width: 273px;
}
.auto-style9 {
width: 1000px;
height: 581px;
}
.auto-style10 {
width: 97px;
}
.auto-style11 {
width: 500px;
}
.auto-style12 {
height: 116px;
}
.stylePanel {
border-radius:50px;
}
.tecboc {
border-radius:10px;
}
        #TextArea1 {
            width: 448px;
            height: 71px;
        }
        .auto-style16 {
            width: 97px;
            height: 29px;
        }
        .auto-style17 {
            width: 273px;
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style9"  >
        <div>
            <h2 > EMPLOYEE STATMENT Application by MySql & ASP.NET </h2>
        </div>
        <hr/>
        <hr class="auto-style2" />
        <%-- <asp:HiddenField ID="HiddenField1" runat="server" />--%>
        <table class="auto-style11">
            <td class="auto-style12">
                <asp:Panel ID="Panelinfo" runat="server" CssClass="stylePanel" BackColor="#CC9900"
                        GroupingText="Employee STATMENT"  >
                    <table class="auto-style12">
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="LabelId" runat="server" Text="ID"></asp:Label>
                            </td>
                            <td class="auto-style17">
                                <asp:TextBox ID="TextId" runat="server" CssClass="tecboc" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="auto-style16">
                                <asp:Label ID="LabelName" runat="server" Text="Full Name"></asp:Label>
                            </td>
                            <td class="auto-style17">
                                <asp:TextBox ID="TextBoxName" runat="server" CssClass="tecboc" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="auto-style16">
                                <asp:Label ID="LabelPosition" runat="server" Text="Position"></asp:Label>
                            </td>
                            <td class="auto-style17">
                                <asp:DropDownList ID="DropDownPosition" runat="server" CssClass="tecboc" Width="200px"></asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td >
                                <asp:Label ID="Labeldatetime" runat="server" Text="END PRIOUD"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxDate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Labeltotalhour" runat="server" Text="Total Hour"></asp:Label>
                            </td>
                            <td class="auto-style17">
                                <asp:TextBox ID="TextBoxtotalhour" runat="server" CssClass="tecboc" Width="200px"></asp:TextBox>
                            </td>
             
                        </tr>

                       

                    </table>
                </asp:Panel>
                

            </td>
            <td>
                <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1" Height="100%" Width= "500px" BackColor="#CC9900">
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" BackColor="Yellow" />
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click" BackColor="Red" />
                    <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" BackColor="BlueViolet"/>
                    <asp:Button ID="ButtonShow" runat="server" Text="Show" OnClick="ButtonShow_Click" BackColor="SpringGreen" />
                    <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" BackColor="Yellow"/>
                    <asp:Button ID="ButtonUpDate" runat="server" Text="UpDate" OnClick="ButtonUpDate_Click" BackColor="WhiteSmoke"/>
                    <asp:Button ID="Buttoncon" runat="server" Text="Conclude" OnClick="Buttoncon_Click" BackColor="SteelBlue"/>
                    <asp:Button ID="Buttoninfo" runat="server" Text="Info" OnClick="Buttoninfo_Click" />
                </asp:Panel>
                <asp:GridView ID="GridView1" runat="server" ShowFooter="true" FooterStyle-BackColor="orange" AutoGenerateColumns="false" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" HeaderStyle-BackColor="SteelBlue" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID DB" ItemStyle-BackColor="WhiteSmoke" />
                        <asp:BoundField DataField="empid" HeaderText="ID" />
                        <asp:BoundField DataField="name" HeaderText="Full Name" />
                        <asp:BoundField DataField="position" HeaderText="Position" />
                        <asp:BoundField DataField="date" HeaderText="Date" />
                        <asp:BoundField DataField="thours" HeaderText="Total Hours" />
                        <asp:BoundField DataField="sbrut" HeaderText="Salary Brut" />
                        <asp:BoundField DataField="tax" HeaderText="Tax" />
                        <asp:BoundField DataField="snet" HeaderText="Salery Net" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                <asp:Panel ID="Panelstatment" runat="server" GroupingText="Statment" BackColor="#CC9900">
                         <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </asp:Panel>
                   
            </td>
             <td>
                <asp:Panel ID="Panelfinal" runat="server" GroupingText="Info" BackColor="#CC9900">
                         <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </asp:Panel>
                   
            </td>

        </table>
        
    </form>
</body>
</html>

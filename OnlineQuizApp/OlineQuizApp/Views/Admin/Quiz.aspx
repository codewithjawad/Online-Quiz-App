<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="OlineQuizApp.Views.Admin.Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table {
            width: 100%;
            table-layout: fixed;
        }
        .table th, .table td {
            width: 25%; /* Adjust based on the number of columns */
            text-align:center;
        }
     
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <h5 class="text-center text-danger">Manage Quiz</h5>
                <div class="mb-3">
                    <label for="QuizTb" class="form-label">Quiz Name</label>
                    <input type="text" class="form-control" id="QuizTb" runat="server" autocomplete="off" required="required"/>
                </div>
                <div class="mb-3">
                    <label for="QuestiTb" class="form-label">Question Numbers</label>
                    <input type="number" class="form-control" id="QuestTb" runat="server" autocomplete="off" required="required" min="1"/>
                </div>
                <div class="mb-3">
                    <label for="AnsByQuestTb" class="form-label">Answer Number</label>
                    <input type="number" class="form-control" id="AnsByQuestTb" runat="server" autocomplete="off" required="required" min="1"/>
                </div>
                <div class="row">
                    <label id="errmsg" runat="server" class="text-danger"></label>
                    <div class="col d-grid mb-3">
                        <asp:Button ID="EditBtn" runat="server" Text="Edit" CssClass="btn btn-warning btn-block" OnClick="EditBtn_Click" />
                    </div>
                    <div class="col d-grid mb-3">
                        
                        <asp:Button ID="SaveBtn" runat="server" Text="Save" CssClass="btn btn-primary btn-block" OnClick="SaveBtn_Click" />
                    </div>
                    <div class="col d-grid mb-3">
                        <asp:Button ID="DeleteBtn" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" OnClick="DeleteBtn_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-7 ">
                <h3 class="text-danger text-center">Quiz List</h3>
                <asp:GridView ID="Quizlist" runat="server" CssClass="table row-cols-4" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True" OnSelectedIndexChanged="Quizlist_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>
                    <FooterStyle BackColor="#CCCCCC"></FooterStyle>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>
                    <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                    <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>
                    <SortedDescendingCellStyle BackColor="#F5F7FB"></SortedDescendingCellStyle>
                    <SortedDescendingHeaderStyle BackColor="#6D95E1"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

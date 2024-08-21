<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="OlineQuizApp.Views.Admin.Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .quiztx {
            display: none;
        }
        .scrollable-table {
            overflow-x: auto; /* Enables horizontal scrolling */
            white-space: nowrap; /* Prevents line breaks within the table cells */
        }
        .scrollable-table table {
            width: 100%;
            table-layout: auto; /* Allows column width to adjust based on content */
        }
        .scrollable-table th, .scrollable-table td {
            padding: 10px;
            text-align: left;
        }
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <h5 class="text-center text-danger">Manage Questions</h5>
                <div class="mb-1 quiztx">
                    <label for="QuiznameTb" class="form-label">Quiz Name</label>
                    <input type="text" class="form-control" id="Quiztb" runat="server" />
                </div>
                <div class="mb-1">
                    <label for="QuiznameTb" class="form-label">Quiz</label>
                    <asp:DropDownList ID="QuiznameTb" class="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-1">
                    <label for="QuestTb" class="form-label">Question</label>
                    <input type="text" class="form-control" id="QuestTb" runat="server" required="required" />
                </div>
                <div class="mb-1">
                    <label for="Ans1Tb" class="form-label">Option 1</label>
                    <input type="text" class="form-control" id="Ans1Tb" runat="server" autocomplete="off" required="required" />
                </div>
                <div class="mb-1">
                    <label for="Ans2Tb" class="form-label">Option 2</label>
                    <input type="text" class="form-control" id="Ans2Tb" runat="server" autocomplete="off" required="required" />
                </div>
                <div class="mb-1">
                    <label for="Ans3Tb" class="form-label">Option 3</label>
                    <input type="text" class="form-control" id="Ans3Tb" runat="server" autocomplete="off" required="required" />
                </div>
                <div class="mb-1">
                    <label for="Ans4Tb" class="form-label">Option 4</label>
                    <input type="text" class="form-control" id="Ans4Tb" runat="server" autocomplete="off" required="required" />
                </div>
                <div class="mb-1">
                    <label for="CorrectTb" class="form-label">Correct Option</label>
                    <input type="number" class="form-control" id="CorrectTb" runat="server" autocomplete="off" required="required" min="0" />
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
            <div class="col-md-9">
                <h3 class="text-danger text-center">Questions List</h3>
                <div class="scrollable-table">
                    <asp:GridView ID="Questionslist" runat="server" CssClass="table table-bordered" 
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                        CellPadding="3" ForeColor="Black" GridLines="Vertical" 
                        AutoGenerateSelectButton="True" OnSelectedIndexChanged="Questionslist_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White"></FooterStyle>
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
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Candidate/CandidateMaster.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="OlineQuizApp.Views.Candidate.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body{
            background-image: url("../../Assests/Images/1.jpg");
            background-size:cover;
        }
        #buttn{
            display:flex;
            justify-content: space-between;
        }
        #testdiv{
            padding-left: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="container-fluid">
         <div class="row" style="height:100px;"></div>
         <div class="row">
             <div class="col-md-3"></div>
             <div class="col-md-6 bg-white rounded-3" >
                 <div class="row bg-success rounded-3">
                     <h4 id="QuesTb" class="text-light " runat="server">Your Question Here</h4>
                 </div>
                 <div class="row h5 text-danger " ID="testdiv" runat="server">
                     <div class="m-1 m-3 form-check">
                         <label for="Ans1Rb" id="Ans1Lb1" runat="server" class="form-check-label text-success">Answer 1</label>
                         <input type="radio" class="form-check-input" runat="server" id="Ans1Rb"/>
                     </div>
                     <div class="m-1 m-3 form-check">
                         <label for="Ans2Rb" id="Ans2Lb1" runat="server" class="form-check-label text-success">Answer 2</label>
                         <input type="radio" class="form-check-input" runat="server" id="Ans2Rb"/>
                     </div>
                     <div class="m-1 m-3 form-check">
                         <label for="Ans3Rb" id="Ans3Lb1" runat="server" class="form-check-label text-success">Answer 3</label>
                         <input type="radio" class="form-check-input" runat="server" id="Ans3Rb" />
                     </div>
                     <div class="m-1 m-3 form-check">
                         <label for="Ans4Rb" id="Ans4Lb1" runat="server" class="form-check-label text-success">Answer 4</label>
                         <input type="radio" class="form-check-input" runat="server" id="Ans4Rb" />
                     </div>
                 </div>
                 <div class="row" ID="btndiv" runat="server">
                     <div class="col-md-6">
                         <label id="errmsg" runat="server" class="text-danger"></label>
                     </div>
                     <div class="col-md-4">
                         <label id="Label1" runat="server" class="text-danger h5"></label>
                     </div>
                     <div class="row-md-4 mb-3" id="buttn">
                         <asp:Button ID="previousButton2" runat="server" Text="Previous" class="btn btn-success" OnClick="previousButton2_Click" />
                         <asp:Button ID="SubmitButton1" runat="server" Text="Next" class="btn btn-success" OnClick="Button1_Click" />
                     </div>
                 </div>
             </div>
             <div class="col-md-3"></div>
         </div>
     </div>
</asp:Content>

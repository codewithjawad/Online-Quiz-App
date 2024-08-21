<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewCandidates.aspx.cs" Inherits="OlineQuizApp.Views.Admin.ViewCandidates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="container-fluid">
  <div class="row" style="height:30px">
  </div>
<div class="row justify-content-center">
    <div class="col-md-1"></div>
    <div class="col-md-10" >
        <h3 class="text-center text-danger">Registered Candidates</h3>
  <asp:GridView ID="CandidateList" runat="server" cssclass="table table-bordered table-dark table-hover"></asp:GridView>
        </div>
    <div class="col-md-1"></div>
</div>
</div>
</asp:Content>

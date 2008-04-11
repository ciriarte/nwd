<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="Application.Views.Shared.WebForm1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> <%= ViewData %> </h1>
</asp:Content>

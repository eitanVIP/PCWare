<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="PCWare.Pages.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Sign In</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Sign In</h1>
    <div class="center"><%=query %></div>

    <form class="center" method="post">
        <ul class="FormUl">
            <li>Username:</li>
            <li><input type="text" name="uname" id="uname" placeholder="Enter username" pattern="[A-Za-z0-9.,!? ]{3,10}" title="Between 3 and 10 characters(only English)" required /></li>
            
            <li>Password:</li>
            <li><input type="password" name="pw" placeholder="Enter password" pattern="^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\d\s]).{8,50}$" title="Have capital and non capital English letters, numbers, punctuation and between 8-50 characters" id="pword" required /></li>

            <li><input type="submit" name="submit" value="Sign In" /></li>
        </ul>
    </form>

    <div class="center">If you don't have an account you can&nbsp;<a href="SignUp.aspx">Sign Up</a>&nbsp;instead</div>
    
    <%=formTable %>
</asp:Content>
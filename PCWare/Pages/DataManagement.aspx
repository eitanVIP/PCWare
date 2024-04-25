<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DataManagement.aspx.cs" Inherits="PCWare.Pages.DataManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Data Management</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Data Management</h1>
    <%=msg %>

    <br />
    <div class="center"><%=UsersQuery %></div>
    <form class="center" method="post">
        <%=UsersTable %>
    </form>

    <br />
    <div class="center"><%=BuildsQuery %></div>
    <form class="center" method="post">
        <%=BuildsTable %>
    </form>

    <br />
    <div class="center"><%=Query1 %></div>
    <form class="center" method="post">
        <%=Query1Table %>
    </form>

    <br />
    <div class="center"><%=Query2 %></div>
    <form class="center" method="post">
        <%=Query2Table %>
    </form>
</asp:Content>
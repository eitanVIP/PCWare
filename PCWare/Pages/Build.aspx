<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Build.aspx.cs" Inherits="PCWare.Pages.Build" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Build</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Build</h1>
    <%=msg %>
    <form class="center" runat="server" method="post">
        <ul class="FormUl">
            <%=Options %>
            <%if (Session["Id"] != null) {%>
                <li><input type="submit" name="submit" value="Save" /></li>
            <%} %>
        </ul>
    </form>
</asp:Content>
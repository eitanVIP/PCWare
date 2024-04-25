<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="PCWare.Pages.Game" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Game</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <canvas id="GameCanvas" style="background-color:rgb(17, 19, 29)"></canvas>

    <script src="../Game.js"></script>
</asp:Content>
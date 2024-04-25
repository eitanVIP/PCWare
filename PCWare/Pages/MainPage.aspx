<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="PCWare.Pages.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Main Page</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Welcome To PCWare</h1>
    <h2>Learn And Build PCs</h2>

    <div class="center"><a href="CPU.aspx"><button>Start Your Tour</button></a></div>
    <br />
    <div class="center"><a href="Build.aspx"><button>Start Your Build</button></a></div>
    <br />
    <div class="center"><a href="DataManagement.aspx"><button>Manage Website</button></a></div>

    <a href="CPU.aspx"><img class="MainPageImg" style="width: 13.99%" src="../Images/CPU.png" /></a>
    <a href="Motherboard.aspx"><img class="MainPageImg"  style="width: 13.99%" src="../Images/Motherboard.png" /></a>
    <a href="RAM.aspx"><img class="MainPageImg"  style="width: 13.99%" src="../Images/RAM.png" /></a>
    <a href="SSD.aspx"><img class="MainPageImg"  style="width: 13.99%" src="../Images/SSD.png" /></a>
    <a href="GPU.aspx"><img class="MainPageImg"  style="width: 13.99%" src="../Images/GPU.png" /></a>
    <a href="PSU.aspx"><img class="MainPageImg"  style="width: 13.99%" src="../Images/PSU.png" /></a>
    <a href="Fan.aspx"><img class="MainPageImg"  style="width: 13.99%" src="../Images/Fan.png" /></a>
    
</asp:Content>

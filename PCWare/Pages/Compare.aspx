<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compare.aspx.cs" Inherits="PCWare.Pages.Compare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Compare</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Compare</h1>
    <form class="center" runat="server" method="post">
        <ul class="HorizontalList">
            <li>
                <ul style="list-style-type: none; padding: 0; margin: 0;">
                    <li>
                        <label for="Item">Item To Compare:</label>
                        <select style="margin-bottom: 10px;" id="Item" name="Item">
                          <option value="CPU">CPU</option>
                          <option value="Motherboard">Motherboard</option>
                          <option value="RAM">RAM</option>
                          <option value="SSD">SSD</option>
                          <option value="HDD">HDD</option>
                          <option value="GPU">GPU</option>
                          <option value="PSU">PSU</option>
                          <option value="Fan">Fan</option>
                          <option value="Case">Case</option>
                        </select>
                    </li>
                    <li><input style="margin-bottom: 10px;" type="submit" name="choose" value="Choose" /></li>

                    <%=Option1 %>
                    <%=Option2 %>
                    <%=CompareInput %>
                </ul>
            </li>
            <li>
                <%=CompareTable %>
            </li>
        </ul>
    </form>
</asp:Content>
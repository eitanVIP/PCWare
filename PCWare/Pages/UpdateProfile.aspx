<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="PCWare.Pages.UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Sign Up</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Update Profile</h1>
    <div class="center"><%=query %></div>

    <form class="center" method="post">
        <ul class="FormUl">
            <li>Username:</li>
            <li><input value="<%=uname %>" type="text" name="uname" id="uname" placeholder="Enter username" pattern="[A-Za-z0-9.,!? ]{3,10}" title="Between 3 and 10 characters(only English)" required /></li>
            <li>First Name:</li>
            <li><input value="<%=fname %>" type="text" name="fname" placeholder="Enter first name" id="fname" pattern="[a-zA-Z]{3,10}" title="Between 3 and 10 English letters" required /></li>
            <li>Last Name:</li>
            <li><input value="<%=lname %>" type="text" name="lname" placeholder="Enter last name" id="lname" pattern="[a-zA-Z]{3,10}" title="Between 3 and 10 English letters" required /></li>
            <li>Birthday year:</li>
            <li><input value="<%=bday %>" type="number" name="bday" placeholder="Enter birthday year" id="bday" max="2019" min="1904" title="Between 1904 and 2019" required /></li>
            <li>Gender:</li>
            <li>
                <ul class="FormUl" id="genderList">
                    <li><input <%=Male %> type="radio" name="gender" id="Male" value="Male" required /><label for="Male">Male</label></li>
                    <li><input <%=Female %> type="radio" name="gender" id="Female" value="Female" required /><label for="Female">Female</label></li>
                </ul>
            </li>
            <li>Hobbies:</li>
            <li>
                <ul class="FormUl" id="hobbiesList">
                    <li><input <%=H0 %> type="checkbox" name="hobbies" id="hobbies-0" value="0" /><label for="hobbies-0">Programming</label></li>
                    <li><input <%=H1 %> type="checkbox" name="hobbies" id="hobbies-1" value="1" /><label for="hobbies-1">Arts</label></li>
                    <li><input <%=H2 %> type="checkbox" name="hobbies" id="hobbies-2" value="2" /><label for="hobbies-2">Gaming</label></li>
                    <li><input <%=H3 %> type="checkbox" name="hobbies" id="hobbies-3" value="3" /><label for="hobbies-3">Boyscout</label></li>
                    <li><input <%=H4 %> type="checkbox" name="hobbies" id="hobbies-4" value="4" /><label for="hobbies-4">Movies</label></li>
                </ul>
            </li>
            <li>
                <label for="city">City:</label>
                <select id="city" name="city">
                  <option <%=Hadera %> value="Hadera" selected>Hadera</option>
                  <option <%=TelAviv %> value="Tel Aviv">Tel Aviv</option>
                  <option <%=Jerusalem %> value="Jerusalem">Jerusalem</option>
                  <option <%=PetahTikva %> value="Petah Tikva">Petah Tikva</option>
                  <option <%=Eilat %> value="Eilat">Eilat</option>
                </select>
            </li>
            <li>Email:</li>
            <li><input value="<%=email %>" type="email" name="email" placeholder="Enter email address" id="email" required /></li>
            <li>Phone Number:</li>
            <li>
                <select id="prefix" name="prefix" style="width: 20%;">
                  <option value="050" <%=Pre050 %>>050</option>
                  <option value="052" <%=Pre052 %>>052</option>
                  <option value="053" <%=Pre053 %>>053</option>
                  <option value="054" <%=Pre054 %>>054</option>
                  <option value="055" <%=Pre055 %>>055</option>
                  <option value="058" <%=Pre058 %>>058</option>
                </select>
                <input value="<%=phone %>" style="width: 75%;" type="text" pattern="[0-9]{7}" title="7 digits after prefix" name="phone" placeholder="Enter phone number" id="tel" required />
            </li>
            <li>Password:</li>
            <li><input value="<%=pw %>" type="password" name="pw" placeholder="Enter password" oninput="this.setCustomValidity(this.value !== document.getElementById('pwordCon').value ? 'Passwords do not match' : '');" pattern="^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\d\s]).{8,50}$" title="Have capital and non capital English letters, numbers, punctuation and between 8-50 characters" id="pword" required /></li>
            <li>Confirm Password:</li>
            <li><input type="password" name="pwConfirm" placeholder="Confirm password" oninput="this.setCustomValidity(this.value !== document.getElementById('pword').value ? 'Passwords do not match' : '');" id="pwordCon" required /></li>
            <li><input type="submit" name="submit" value="Update" /></li>
        </ul>
    </form>
    <%=formTable %>
</asp:Content>
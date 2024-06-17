<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PCWare.Pages.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PCWare - Sign Up</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Sign Up</h1>
    <form class="center" method="post">
        <ul class="FormUl">
            <li>Username:</li>
            <li><input type="text" name="uname" id="uname" placeholder="Enter username" pattern="[A-Za-z0-9.,!? ]{3,10}" title="Between 3 and 10 characters(only English)" required /></li>
            <li>First Name:</li>
            <li><input type="text" name="fname" placeholder="Enter first name" id="fname" pattern="[a-zA-Z]{3,10}" title="Between 3 and 10 English letters" required /></li>
            <li>Last Name:</li>
            <li><input type="text" name="lname" placeholder="Enter last name" id="lname" pattern="[a-zA-Z]{3,10}" title="Between 3 and 10 English letters" required /></li>
            <li>Birthday year:</li>
            <li><input type="number" name="bday" placeholder="Enter birthday year" id="bday" max="2019" min="1904" title="Between 1904 and 2019" required /></li>
            <li>Gender:</li>
            <li>
                <ul class="FormUl" id="genderList">
                    <li><input type="radio" name="gender" id="Male" value="Male" required /><label for="Male">Male</label></li>
                    <li><input type="radio" name="gender" id="Female" value="Female" required /><label for="Female">Female</label></li>
                </ul>
            </li>
            <li>Hobbies:</li>
            <li>
                <ul class="FormUl" id="hobbiesList">
                    <li><input type="checkbox" name="hobbies" id="hobbies-0" value="0" /><label for="hobbies-0">Programming</label></li>
                    <li><input type="checkbox" name="hobbies" id="hobbies-1" value="1" /><label for="hobbies-1">Arts</label></li>
                    <li><input type="checkbox" name="hobbies" id="hobbies-2" value="2" /><label for="hobbies-2">Gaming</label></li>
                    <li><input type="checkbox" name="hobbies" id="hobbies-3" value="3" /><label for="hobbies-3">Boyscout</label></li>
                    <li><input type="checkbox" name="hobbies" id="hobbies-4" value="4" /><label for="hobbies-4">Movies</label></li>
                </ul>
            </li>
            <li>
                <label for="city">City:</label>
                <select id="city" name="city">
                  <option value="Hadera" selected>Hadera</option>
                  <option value="Tel Aviv">Tel Aviv</option>
                  <option value="Jerusalem">Jerusalem</option>
                  <option value="Petah Tikva">Petah Tikva</option>
                  <option value="Eilat">Eilat</option>
                </select>
            </li>
            <li>Email:</li>
            <li><input type="email" name="email" placeholder="Enter email address" id="email" required /></li>
            <li>Phone Number:</li>
            <li>
                <select id="prefix" name="prefix" style="width: 20%;">
                  <option value="050">050</option>
                  <option value="052">052</option>
                  <option value="053">053</option>
                  <option value="054" selected>054</option>
                  <option value="055">055</option>
                  <option value="058">058</option>
                </select>
                <input style="width: 75%;" type="text" pattern="[0-9]{7}" title="7 digits after prefix" name="phone" placeholder="Enter phone number" id="tel" required />
            </li>
            <li>Password:</li>
            <li><input type="password" name="pw" placeholder="Enter password" oninput="document.getElementById('pwordCon').setCustomValidity(this.value !== document.getElementById('pwordCon').value ? 'Passwords do not match' : '');" pattern="^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\d\s]).{8,50}$" title="Have capital and non capital English letters, numbers, punctuation and between 8-50 characters" id="pword" required /></li>
            <li>Confirm Password:</li>
            <li><input type="password" name="pwConfirm" placeholder="Confirm password" oninput="this.setCustomValidity(this.value !== document.getElementById('pword').value ? 'Passwords do not match' : '');" id="pwordCon" required /></li>
            <li><input type="submit" name="submit" value="Sign Up" /></li>
        </ul>
    </form>
</asp:Content>
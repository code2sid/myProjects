<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="KarrStyle.Pages.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 772px;
            height: 289px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            Car Accessories India - Buy Car Accessories Online</h1>
        <p>
            <asp:Label ID="lblDescription" runat="server" Text="Car accessories online shopping in India is the new trend."></asp:Label>
        </p>
    </div>
    <div>
        <div class="menuHover">
            <table class="menu2" width="218">
                <tbody>
                    <tr>
                        <td class="AJAccMenuTD">
                            <ul id="sl-nav">
                                <li><a id="TopCategoryLink_1" href="http://www.autojunction.in/car-accessories/car-lights">
                                    <h2>
                                        Car Lights</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_1_1" href="http://www.autojunction.in/car-accessories/car-lights/new-light">
                                            Performance Lights </a></li>
                                    </ul>
                                </li>
                                <li><a id="TopCategoryLink_2" href="http://www.autojunction.in/car-accessories/car-utilities">
                                    <h2>
                                        Car Utilities</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_2_1" href="http://www.autojunction.in/car-accessories/car-utilities/utility-accessories">
                                            Useful Car Accessories </a></li>
                                        <li><a id="SubItemLink_2_2" href="http://www.autojunction.in/car-accessories/car-utilities/car-inverter">
                                            Car Inverter </a></li>
                                        <li><a id="SubItemLink_2_3" href="http://www.autojunction.in/car-accessories/car-utilities/car-cooler-box-and-heater">
                                            Car Fridge </a></li>
                                    </ul>
                                </li>
                                <li><a id="TopCategoryLink_3" href="http://www.autojunction.in/car-accessories/car-interior">
                                    <h2>
                                        Car Interior Accessories</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_3_1" href="http://www.autojunction.in/car-accessories/car-interior/car-perfumes">
                                            Car Perfume </a></li>
                                        <li><a id="SubItemLink_3_2" href="http://www.autojunction.in/car-accessories/car-interior/foot-mats-and-dash-mats">
                                            Floor Mats </a></li>
                                    </ul>
                                </li>
                                <li><a id="TopCategoryLink_4" href="http://www.autojunction.in/car-accessories/car-care">
                                    <h2>
                                        Car Care</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_4_1" href="http://www.autojunction.in/car-accessories/car-care/car-care-accessory">
                                            Car Wash Equipment </a></li>
                                        <li><a id="SubItemLink_4_2" href="http://www.autojunction.in/car-accessories/car-care/car-polish">
                                            Car Polish </a></li>
                                        <li><a id="SubItemLink_4_3" href="http://www.autojunction.in/car-accessories/car-care/car-protectant">
                                            Car Scratch Remover </a></li>
                                        <li><a id="SubItemLink_4_4" href="http://www.autojunction.in/car-accessories/car-care/cleaner-and-shiner">
                                            Car Cleaning </a></li>
                                        <li><a id="SubItemLink_4_5" href="http://www.autojunction.in/car-accessories/car-care/glass-cleaner">
                                            Glass Cleaner </a></li>
                                        <li><a id="SubItemLink_4_6" href="http://www.autojunction.in/car-accessories/car-care/car-vacuum-cleaners">
                                            Car Vacuum Cleaner </a></li>
                                    </ul>
                                </li>
                                <li><a id="TopCategoryLink_5" href="http://www.autojunction.in/car-accessories/gps-and-navigation">
                                    <h2>
                                        GPS Navigation and Tracking</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_5_1" href="http://www.autojunction.in/car-accessories/gps-and-navigation/navigator">
                                            Navigator </a></li>
                                        <li><a id="SubItemLink_5_2" href="http://www.autojunction.in/car-accessories/gps-and-navigation/vehicle-tracking-system">
                                            Vehicle Tracking System </a></li>
                                    </ul>
                                </li>
                                <li><a id="TopCategoryLink_6" href="http://www.autojunction.in/car-accessories/car-infotainment">
                                    <h2>
                                        In-Car Entertainment</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_6_1" href="http://www.autojunction.in/car-accessories/car-infotainment/speaker">
                                            Car Speakers </a></li>
                                        <li><a id="SubItemLink_6_2" href="http://www.autojunction.in/car-accessories/car-infotainment/amplifiers">
                                            Car Amplifier </a></li>
                                        <li><a id="SubItemLink_6_3" href="http://www.autojunction.in/car-accessories/car-infotainment/tft-monitors">
                                            Car DVD Player </a></li>
                                        <li><a id="SubItemLink_6_4" href="http://www.autojunction.in/car-accessories/car-infotainment/woofers">
                                            Subwoofer </a></li>
                                    </ul>
                                </li>
                                <li><a id="TopCategoryLink_7" href="http://www.autojunction.in/car-accessories/safety-and-security">
                                    <h2>
                                        Car Security System</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_7_1" href="http://www.autojunction.in/car-accessories/safety-and-security/car-security-system">
                                            Central Locking </a></li>
                                        <li><a id="SubItemLink_7_2" href="http://www.autojunction.in/car-accessories/safety-and-security/gear-lock">
                                            Gear Lock </a></li>
                                        <li><a id="SubItemLink_7_3" href="http://www.autojunction.in/car-accessories/safety-and-security/reverse-parking-aid">
                                            Reverse Camera </a></li>
                                    </ul>
                                </li>
                                <li><a id="TopCategoryLink_8" href="http://www.autojunction.in/car-accessories/performance-products">
                                    <h2>
                                        Performance Products</h2>
                                    <span class="spanacce">Press the Right arrow key to navigate through sub categories</span>
                                </a>
                                    <ul>
                                        <li><a id="SubItemLink_8_1" href="http://www.autojunction.in/car-accessories/performance-products/engine-treatment">
                                            Engine Treatment </a></li>
                                    </ul>
                                </li>
                            </ul>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>

            asdasdasd
            <img alt="" class="style1" src="../Images/swfDesign.png" /></div>
    </div>
</asp:Content>

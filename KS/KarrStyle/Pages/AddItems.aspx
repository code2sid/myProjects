<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddItems.aspx.cs" Inherits="KarrStyle.Pages.AddItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdProducts" runat="server" CssClass="table_grid" 
        AutoGenerateColumns="false" DataKeyNames="ProductID"
        AllowSorting="true" EmptyDataText="There is no data." ShowHeaderWhenEmpty="true"
        Width="100%" ShowFooter="true" OnRowCommand="grdProducts_RowCommand" 
        onrowdatabound="grdProducts_RowDataBound">
        <%--  OnSorting="grdGlobalSiteYear_Sorting"
        OnRowCreated="grdGlobalSiteYear_RowCreated"--%>
        <Columns>
            <asp:TemplateField HeaderText="Product Type" SortExpression="ProductTypeID">
                <FooterTemplate>
                    <asp:DropDownList ID="ddlProductType" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProductType" runat="server" ForeColor="Red" ControlToValidate="ddlProductType"
                        ValidationGroup="GrdValid" ErrorMessage="*"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="right" />
                <ItemTemplate>
                    <asp:Label ID="lblProductType" runat="server" Text='<%#  Eval("ProductType") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Name" SortExpression="ProductName">
                <FooterTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Width="100px" Style="text-align: center"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ForeColor="Red" ControlToValidate="txtProductName"
                        ValidationGroup="GrdValid" ErrorMessage="*"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="right" />
                <ItemTemplate>
                    <asp:Label ID="lblProductName" runat="server" Text='<%#  Eval("ProductName") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product File">
                <FooterTemplate>
                    <asp:Label ID="lblProductFileUpload" runat="server" Text="">Upload File</asp:Label>
                    <asp:FileUpload ID="fuProductFile" runat="server" />
                </FooterTemplate>
                <FooterStyle HorizontalAlign="right" />
                <ItemTemplate>
                    <%--<asp:Label ID="lblProductFile" runat="server" Text='<%#  Eval("ProductFile") %>' />--%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <FooterTemplate>
                    <asp:DropDownList ID="ddlQuantity" runat="server">
                        <asp:ListItem Selected="True" Text="1" Value="1" >1</asp:ListItem>
                        <asp:ListItem Text="2" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="3" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="4" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="6" Value="6" />
                        <asp:ListItem Text="7" Value="7" />
                        <asp:ListItem Text="8" Value="8" />
                        <asp:ListItem Text="9" Value="9" />
                        <asp:ListItem Text="10" Value="10" />
                    </asp:DropDownList>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="right" />
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" runat="server" Text='<%#  Eval("Quantity") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                   <asp:ImageButton CausesValidation="false" ID="imgBtnInfo" ImageUrl="~/images/edit.png"
                        Visible="true" CommandName="edit" 
                        runat="server"></asp:ImageButton> 
                </ItemTemplate>
                <ItemStyle HorizontalAlign="left"></ItemStyle>
                <FooterTemplate>
                    <asp:ImageButton ID="imgBtnInfo" ImageUrl="~/images/Add_Record.png" ValidationGroup="GrdValid"
                        CommandName="Add" runat="server"></asp:ImageButton>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="left" />
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle CssClass="alt" />
    </asp:GridView>
</asp:Content>

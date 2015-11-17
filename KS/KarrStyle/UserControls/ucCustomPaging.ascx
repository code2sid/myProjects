<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomPaging.ascx.cs" Inherits="KarrStyle.UserControls.ucCustomPaging" %>


<asp:UpdatePanel ID="UPucPaging" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUCPaging" runat="server" DefaultButton="btnGo">
    
    
        <table align="right" width="500" id="tb2" runat="server" cellpadding="0" cellspacing="0"
            border="0" class="table_grid2 bold">
            <tr>
                <td>
                    <asp:LinkButton ID="m_cmdfirst" ToolTip="First" Text="|<<" runat="server" OnClick="m_cmdfirst_Click"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="m_cmdPrev2" ToolTip="Previous" Text="<<" runat="server" OnClick="m_cmdPrev2_Click"></asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="lblPaging" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="m_cmdNext2" ToolTip="Next" Text=">>" runat="server" OnClick="m_cmdNext2_Click"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="m_cmdLast" ToolTip="Last" Text=">>|" runat="server" OnClick="m_cmdLast_Click"></asp:LinkButton>
                </td>
                <td>
                    <label class="lable">
                        Page</label>
                </td>
                <td valign="bottom">
                    <asp:TextBox ID="txtPageNo" runat="server" class="w_40"  MaxLength="9"
                        onkeypress="return isNumberKey(event)"></asp:TextBox>
                </td>
                <td valign="top">
                    <asp:Button ID="btnGo" runat="server" Text="Go" class="custom-button" OnClick="btnGo_Click" />
                </td>
            </tr>
        </table>

        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="m_cmdfirst" />
        <asp:AsyncPostBackTrigger ControlID="m_cmdPrev2" />
        <asp:AsyncPostBackTrigger ControlID="m_cmdNext2" />
        <asp:AsyncPostBackTrigger ControlID="m_cmdLast" />        
        <asp:AsyncPostBackTrigger ControlID="btnGo" />
    </Triggers>
</asp:UpdatePanel>

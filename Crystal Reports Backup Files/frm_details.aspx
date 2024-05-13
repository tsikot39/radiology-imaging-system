<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frm_details.aspx.vb" Inherits="rid.frm_details" Theme="Skin1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<style type="text/css">
        .style1
        {
            font-family: Tahoma;
            font-size: 8pt;
        }
        .style2
        {
            font-family: Tahoma;
            font-size: 10pt;
        }          
        .style3
        {
            font-family: Tahoma;
            font-size: 14pt;
        } 
        .gvheader
        {
            background-color: #507CD1;
        }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            padding-top: 10px;
            padding-left: 10px;
            padding-right: 10px;
            overflow: scroll;
            height: 600px;
            width: 800px;
            position: absolute;
        }
        .hiddencol
        {
            display: none;
        }
</style>
</head>
<body bgcolor="#EFF3FB">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <table width="100%">
            <tr>
                <td colspan="2" align="right">
                    <asp:Label ID="Label29" runat="server" Text="USER:" CssClass="style1" />
                    <asp:Label ID="lbllogin" runat="server" Text="Label" CssClass="style1"/>
                    <asp:LoginName ID="LoginName1" runat="server" CssClass="style1" Visible="false" />|
                    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="LOGOUT" CssClass="style1" LogoutAction="RedirectToLoginPage" />&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle">
                    <img src="logo.gif" alt="PCMC" style="vertical-align: top; height: 25px; width: 25px" />
                    <span class="style3">PHILIPPINE CHILDREN'S MEDICAL CENTER</span>                                                   
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label18" runat="server" Text="RADIOLOGY IMAGING REPORT SYSTEM" CssClass="style2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <%--NEW RESULT--%>
                    <asp:Button ID="btnback" runat="server" Text="BACK" CssClass="style1" />
                    <asp:Button ID="btnaddresult" runat="server" Text="NEW RESULT" CssClass="style1" />
                    <ajaxToolkit:ModalPopupExtender ID="modalpopup" runat="server" TargetControlID="btnaddresult" PopupControlID="panel1" BackgroundCssClass="modalBackground" />
                    <asp:Panel ID="panel1" runat="server" CssClass="modalPopup" style="display: none">
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td colspan="3" align="left" style="background-color: #507CD1; color: yellow; padding: 4px; margin: 0px">
                                        <asp:Label ID="Label10" runat="server" Text="NEW RESULT" CssClass="style1"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lblphysician" runat="server" Text="Requesting Physician" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtphysician" runat="server" CssClass="style1" Width="250px" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtphysician" ValidationGroup="popup"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lblroom" runat="server" Text="Ward/Room Number" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlroom" runat="server" CssClass="style1" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlroom" ValidationGroup="popup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbldoe" runat="server" Text="Date of Examination" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtdoe" runat="server" CssClass="style1" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtdoe" ValidationGroup="popup" />
                                            <ajaxToolkit:CalendarExtender ID="ajaxdoe" runat="server" TargetControlID="txtdoe" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbldi" runat="server" Text="Date Interpreted" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtdi" runat="server" CssClass="style1" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtdi" ValidationGroup="popup" />
                                            <ajaxToolkit:CalendarExtender ID="ajaxde" runat="server" TargetControlID="txtdi" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lblradiologist" runat="server" Text="Radiologist" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlradiologist" runat="server" CssClass="style1" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="ddlradiologist" ValidationGroup="popup" />                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification1" runat="server" Text="1. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification1" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification1_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres1" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres1" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres1_SelectedIndexChanged" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes1" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes1" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes1a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification2" runat="server" Text="2. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification2" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification2_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres2" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres2" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres2_SelectedIndexChanged" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes2" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes2" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" rows="5" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes2a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" rows="5" ValidationGroup="popup" /></td>
                                    </tr>    
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification3" runat="server" Text="3. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification3" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification3_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres3" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres3" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres3_SelectedIndexChanged" CssClass="style1" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes3" runat="server" Text="Description" CssClass="style1"></asp:Label></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes3" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes3a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification4" runat="server" Text="4. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification4" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification4_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres4" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres4" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres4_SelectedIndexChanged" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes4" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes4" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes4a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification5" runat="server" Text="5. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification5" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification5_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres5" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres5" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres5_SelectedIndexChanged" CssClass="style1" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes5" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes5" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes5a" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification6" runat="server" Text="6. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification6" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification6_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres6" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres6" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres6_SelectedIndexChanged" CssClass="style1" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes6" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes6" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td><asp:TextBox ID="txtdes6a" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification7" runat="server" Text="7. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification7" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification7_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres7" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres7" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres7_SelectedIndexChanged" CssClass="style1" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes7" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes7" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes7a" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification8" runat="server" Text="8. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification8" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification8_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres8" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres8" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres8_SelectedIndexChanged" CssClass="style1" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes8" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes8" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes8a" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification9" runat="server" Text="9. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification9" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification9_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres9" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres9" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres9_SelectedIndexChanged" CssClass="style1" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes9" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes9" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes9a" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lblclassification10" runat="server" Text="10. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclassification10" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddlclassification10_SelectedIndexChanged" ValidationGroup="popup">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="lblres10" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:DropDownList ID="ddlres10" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlres10_SelectedIndexChanged" CssClass="style1" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><asp:Label ID="lbldes10" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes10" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txtdes10a" runat="server" CssClass="style1" Columns="100" Rows="5" TextMode="MultiLine" ValidationGroup="popup" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="style1" Width="50px" ValidationGroup="popup" />
                                            <asp:Button ID="btncancel" runat="server" Text="CANCEL" CssClass="style1" Width="50px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <table style="border: 1px solid gray">
                    <tr>
                        <td align="left" colspan="2" style="background-color: #507CD1; color: Yellow; padding: 4px; margin: 0px">
                            <asp:Label ID="Label1" runat="server" Text="PATIENT INFORMATION" CssClass="style1"/>
                        </td>   
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="Label5" runat="server" Text="File Number" CssClass="style1" /></td>
                        <td align="left"><asp:Label ID="lblfileno" runat="server" Text="Label" CssClass="style1" /></td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="Label4" runat="server" Text="HRN" CssClass="style1" /></td>
                        <td align="left"><asp:Label ID="lblhrn" runat="server" Text="Label" CssClass="style1" /></td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="Label6" runat="server" Text="Last Name" CssClass="style1" />  </td>
                        <td align="left"><asp:Label ID="lbllname" runat="server" Text="Label" CssClass="style1" /></td>     
                    </tr>   
                    <tr>
                        <td align="left"><asp:Label ID="Label7" runat="server" Text="First Name" CssClass="style1" />  </td>
                        <td align="left"><asp:Label ID="lblfname" runat="server" Text="Label" CssClass="style1" /></td>
                    </tr>    
                    <tr>
                        <td align="left"><asp:Label ID="Label8" runat="server" Text="Age" CssClass="style1" /></td>
                        <td align="left"><asp:Label ID="lblage" runat="server" Text="Label" CssClass="style1" /></td>
                    </tr>      
                    <tr>
                        <td align="left"><asp:Label ID="Label9" runat="server" Text="Sex" CssClass="style1" /></td>
                        <td align="left"><asp:Label ID="lblsex" runat="server" Text="Label" CssClass="style1" /></td>
                    </tr>                                                     
                    </table>
                </td>                
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text="PATIENT RESULTS" CssClass="style2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvdetails" runat="server" AllowPaging="true" PageSize="15" AutoGenerateColumns="false" OnPageIndexChanging="OnPaging" EmptyDataText="NO RESULTS FOUND." EmptyDataRowStyle-HorizontalAlign="Center" CssClass="style1">
                        <Columns>           
                            <asp:BoundField DataField="resultno" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"  />                                                                   
                            <asp:BoundField DataField="physician" HeaderText="REQUESTING PHYSICIAN" HeaderStyle-Font-Bold="false" />                            
                            <asp:BoundField DataField="ward_no" HeaderText="ROOM NUMBER" HeaderStyle-Font-Bold="false" />
                            <asp:BoundField DataField="date_exam" HeaderText="DATE OF EXAMINATION" HeaderStyle-Font-Bold="false" />
                            <asp:BoundField DataField="date_interpreted" HeaderText="DATE INTERPRETED" HeaderStyle-Font-Bold='false' />
                            <asp:BoundField DataField="radiologist" HeaderText="RADIOLOGIST" HeaderStyle-Font-Bold="false" />
                            <asp:BoundField DataField="classification1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des1a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des2a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des3a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des4a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des5a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification6" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res6" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des6" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des6a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification7" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res7" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des7" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des7a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification8" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res8" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des8" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des8a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification9" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res9" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des9" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des9a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="classification10" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="res10" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:BoundField DataField="des10" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField DataField="des10a" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkedit" runat="server" Text="EDIT INFO" OnClick="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkprint" runat="server" NavigateUrl='<%# Eval("resultno", "~/frm_report.aspx?resultno={0}")%>' Target="_blank" Text="VIEW RESULT" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%--EDIT RESULT--%>
                    <asp:LinkButton ID="lnkfake" runat="server" />
                    <ajaxToolkit:ModalPopupExtender ID="modaledit" runat="server" TargetControlID="lnkfake" PopupControlID="paneledit" BackgroundCssClass="modalBackground" />
                    <asp:Panel ID="paneledit" runat="server" CssClass="modalPopup">
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td colspan="3" align="left" style="background-color: #507CD1; color: yellow; padding: 4px; margin: 0px">
                                        <asp:Label ID="Label30" runat="server" Text="EDIT PATIENT RESULT INFORMATION" CssClass="style1"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditresultno" runat="server" Text="ResultNo" CssClass="hiddencol" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditresultno" runat="server" CssClass="hiddencol" Width="250px" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditphysician" runat="server" Text="Requesting Physician" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditphysician" runat="server" CssClass="style1" Width="250px" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditroom" runat="server" Text="Ward/Room Number" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditroom" runat="server" CssClass="style1" ValidationGroup="popupedit">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditdoe" runat="server" Text="Date of Examination" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txteditdoe" runat="server" CssClass="style1" ValidationGroup="popupedit" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txteditdoe" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditdi" runat="server" Text="Date Interpreted" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txteditdi" runat="server" CssClass="style1" ValidationGroup="popupedit" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txteditdi" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditradiologist" runat="server" Text="Radiologist" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditradiologist" runat="server" CssClass="style1" ValidationGroup="popupedit">
                                                <asp:ListItem Text="--Select Item--" Value="" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification1" runat="server" Text="1. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification1" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification1_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres1" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres1" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres1_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes1" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes1" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes1a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification2" runat="server" Text="2. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification2" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification2_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres2" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres2" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres2_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes2" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes2" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes2a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification3" runat="server" Text="3. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification3" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification3_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres3" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres3" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres3_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes3" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes3" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes3a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification4" runat="server" Text="4. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification4" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification4_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres4" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres4" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres4_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes4" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes4" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes4a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification5" runat="server" Text="5. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification5" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification5_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres5" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres5" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres5_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes5" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes5" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes5a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification6" runat="server" Text="6. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification6" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification6_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres6" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres6" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres6_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes6" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes6" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes6a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification7" runat="server" Text="7. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification7" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification7_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres7" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres7" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres7_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes7" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes7" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes7a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification8" runat="server" Text="8. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification8" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification8_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres8" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres8" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres8_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes8" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes8" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes8a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification9" runat="server" Text="9. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification9" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification9_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres9" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres9" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres9_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes9" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes9" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes9a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditclassification10" runat="server" Text="10. Select Classification" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditclassification10" runat="server" CssClass="style1" AutoPostBack="true" OnSelectedIndexChanged="ddleditclassification10_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><asp:Label ID="lbleditres10" runat="server" Text="Result" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddleditres10" runat="server" CssClass="style1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddleditres10_SelectedIndexChanged" ValidationGroup="popupedit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"><asp:Label ID="lbleditdes10" runat="server" Text="Description" CssClass="style1" /></td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes10" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="txteditdes10a" runat="server" CssClass="style1" TextMode="MultiLine" Columns="100" Rows="5" ValidationGroup="popupedit" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btneditsave" runat="server" Text="SAVE" CssClass="style1" Width="50px" ValidationGroup="popupedit" />
                                            <asp:Button ID="btneditcancel" runat="server" Text="CANCEL" CssClass="style1" Width="50px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center"><asp:Label ID="Label2" runat="server" Text="Hospital Information Support Services | Developed by John Corpus | 2015 © Copyright" CssClass="style1"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>

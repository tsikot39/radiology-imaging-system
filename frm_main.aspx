<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frm_main.aspx.vb" Inherits="rid.frm_main" Theme="Skin1" %>

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
        }
        .hiddencol
          {
            display: none;
          }
</style>
</head>
<body bgcolor="#EFF3FB">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <table width="100%">
            <tr>
                <td colspan="2" align="right">
                    <asp:Label ID="Label3" runat="server" Text="USER:" CssClass="style1" />
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
                <td colspan="2" align="center">
                    <asp:Label ID="Label4" runat="server" Text="RADIOLOGY IMAGING REPORT SYSTEM" CssClass="style2" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center">                    
                    <asp:Button ID="btnhome" runat="server" Text="HOME" CssClass="style1" />
                    <asp:Button ID="btnaddpatient" runat="server" Text="NEW PATIENT" CssClass="style1" />
                    <ajaxToolkit:ModalPopupExtender ID="modalpop" runat="server" TargetControlID="btnaddpatient" PopupControlID="panel1" BackgroundCssClass="modalBackground" />
                    <asp:Panel ID="panel1" runat="server" CssClass="modalPopup" style="display: none">
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td align="left" colspan="2" style="background-color: #507CD1; color: Yellow; padding: 4px; margin: 0px" class="style1">
                                            <asp:Label ID="Label2" runat="server" Text="NEW PATIENT"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                    <td align="left">
                                            <asp:Label ID="Label10" runat="server" Text="File Number" CssClass="style1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtfileno" runat="server" Width="200px" CssClass="style1" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtfileno" ValidationGroup="popup" />
                                        </td>
                                    </tr>
                                    <td align="left">
                                            <asp:Label ID="lblhrn" runat="server" Text="HRN" CssClass="style1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txthrn" runat="server" Width="200px" CssClass="style1" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txthrn" ValidationGroup="popup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbllname" runat="server" Text="Last Name" CssClass="style1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtlname" runat="server" Width="200px" CssClass="style1" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtlname" ValidationGroup="popup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblfname" runat="server" Text="First Name" CssClass="style1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtfname" runat="server" Width="200px" CssClass="style1" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtfname" ValidationGroup="popup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblage" runat="server" Text="Age" CssClass="style1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtage" runat="server" Width="50px" CssClass="style1" ValidationGroup="popup" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtage" ValidationGroup="popup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblsex" runat="server" Text="Sex" CssClass="style1"></asp:Label>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:RadioButtonList ID="rblgender" runat="server" DataSourceID="sqlgender" DataTextField="gender" CssClass="style1" ValidationGroup="popup"/>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="rblgender" ValidationGroup="popup" />
                                            <asp:SqlDataSource ID="sqlgender" runat="server" SelectCommand="select gender from tbl_gender" ConnectionString='<%$ ConnectionStrings:rid %>' />                   
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                        <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="style1" Width="50px" ValidationGroup="popup" />
                                        <asp:Button ID="btncancel" runat="server" Text="CANCEL" CssClass="style1" Width="50px" />                             
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>                     
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label1" runat="server" Text="Patient's Name" CssClass="style1"></asp:Label>
                    <asp:TextBox ID="tbsearch" runat="server" Width="200px" CssClass="style1"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="SEARCH" CssClass="style1" />        
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                        <asp:GridView ID="gvsearch" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="15" CssClass="style1">
                            <Columns>
                                <asp:BoundField DataField="fileno" HeaderText="FILE NUMBER" HeaderStyle-Font-Bold="false"  />
                                <asp:BoundField DataField="hrn" HeaderText="HOSPITAL RECORD NUMBER" HeaderStyle-Font-Bold="false" />
                                <asp:BoundField DataField="lname" HeaderText="LAST NAME" HeaderStyle-Font-Bold="false" />
                                <asp:BoundField DataField="fname" HeaderText="FIRST NAME" HeaderStyle-Font-Bold="false" />  
                                <asp:BoundField DataField="age" HeaderText="AGE" HeaderStyle-Font-Bold="false" />
                                <asp:BoundField DataField="sex" HeaderText="SEX" HeaderStyle-Font-Bold="false" />      
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" runat="server" Text="EDIT INFO" OnClick="Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>       
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkview" runat="server" NavigateUrl='<%# Eval("fileno", "~/frm_details.aspx?fileno={0}")%>' Target="_parent" Text="VIEW RESULTS" />
                                    </ItemTemplate>
                                </asp:TemplateField>    
                            </Columns>                         
                        </asp:GridView>  
                        <asp:LinkButton ID="lnkfake" runat="server" />
                        <ajaxToolkit:ModalPopupExtender ID="modaledit" runat="server" TargetControlID="lnkfake" PopupControlID="paneledit" BackgroundCssClass="modalBackground" />
                        <asp:Panel ID="paneledit" runat="server" CssClass="modalPopup">
                            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td align="left" colspan="2" style="background-color: #507CD1; color: Yellow; padding: 4px; margin: 0px" class="style1">
                                                <asp:Label ID="Label5" runat="server" Text="EDIT PATIENT INFORMATION"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbleditfileno" runat="server" Text="File Number" CssClass="style1" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txteditfileno" runat="server" Width="200px" CssClass="style1" ValidationGroup="popupedit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbledithrn" runat="server" Text="HRN" CssClass="style1" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtedithrn" runat="server" Width="200px" CssClass="style1" ValidationGroup="popupedit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label6" runat="server" Text="Last Name" CssClass="style1" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txteditlname" runat="server" Width="200px" CssClass="style1" ValidationGroup="popupedit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label7" runat="server" Text="First Name" CssClass="style1" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txteditfname" runat="server" Width="200px" CssClass="style1" ValidationGroup="popupedit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label8" runat="server" Text="Age" CssClass="style1" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txteditage" runat="server" Width="50px" CssClass="style1" ValidationGroup="popupedit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label9" runat="server" Text="Sex" CssClass="style1" />
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:RadioButtonList ID="rbleditgender" DataSourceID="sqleditgender" DataTextField="gender" runat="server" CssClass="style1" ValidationGroup="popupedit" /> 
                                                <asp:SqlDataSource ID="sqleditgender" runat="server" SelectCommand="select gender from tbl_gender" ConnectionString='<%$ ConnectionStrings:rid %>' />                                                                                      
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                            <asp:Button ID="btnsaveedit" runat="server" Text="SAVE" CssClass="style1" Width="50px" ValidationGroup="popupedit" />
                                            <asp:Button ID="btncanceledit" runat="server" Text="CANCEL" CssClass="style1" Width="50px" />                             
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                </td>  
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2" class="style1">Hospital Information Support Services | Developed by John Corpus | 2015 © Copyright</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

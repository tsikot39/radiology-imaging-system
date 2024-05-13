<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frm_report.aspx.vb" Inherits="rid.frm_report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript">
    function Print() {
        var dvReport = document.getElementById("dvreport");
        var frame1 = dvReport.getElementsByTagName("iframe")[0];
        if (navigator.appName.indexOf("Internet Explorer") != -1) {
            frame1.name = frame1.id;
            window.frames[frame1.id].focus();
            window.frames[frame1.id].print();
        }
        else {
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.print();
        }
    }
    function Close() {
        window.close();
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvreport">
        <table>
            <tr>
                <td align="center" valign="top">
                    <CR:CrystalReportViewer ID="crv" runat="server" 
                        HasPrintButton="False" EnableDatabaseLogonPrompt="False" 
                        EnableParameterPrompt="False" ToolPanelView="None" Visible="true" DisplayToolbar="False" Height="50px" SeparatePages="False" Width="350px" />
                </td>
                <td>&nbsp;</td>
                <td valign="top">
                    <asp:Button ID="btnprint" runat="server" Text="PRINT" CssClass="style1" OnClientClick="Print()" />
                </td>
                <td valign="top">
                    <asp:Button ID="btnclose" runat="server" Text="CLOSE PAGE" CssClass="style1" OnClientClick="javascript:window.close()" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

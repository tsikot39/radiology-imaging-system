Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Drawing
Imports System.Web.Security
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared

Public Class frm_report

    Inherits System.Web.UI.Page

    Dim rpt As result

    Private Sub ConfigureCrystalReport()
        rpt = New result

        Dim con As New ConnectionInfo
        con.ServerName = "10.0.0.2"
        con.DatabaseName = "rid"
        con.UserID = "sa"
        con.Password = "q1w2e3"

        Dim selection As String

        selection = "{view_report.resultno} = '" & Request.QueryString("resultno").ToString & "'"

        crv.SelectionFormula = selection
        crv.ReportSource = rpt
        SetDBLogonForReport(con)
        'rpt.Close()
        'rpt.Dispose()
    End Sub

    Private Sub SetDBLogonForReport(ByVal con As ConnectionInfo)
        Dim myTableLogonInfos As TableLogOnInfos = crv.LogOnInfo

        For Each myTableLogonInfo As TableLogOnInfo In myTableLogonInfos
            myTableLogonInfo.ConnectionInfo = con
        Next
    End Sub

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        ConfigureCrystalReport()
    End Sub

End Class
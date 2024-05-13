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

Public Class frm_main
    Inherits System.Web.UI.Page

    Dim con As String = WebConfigurationManager.ConnectionStrings("rid").ConnectionString

    Dim varchkyr As String = ""
    Dim varchkyr1 As String = ""
    Dim varlastid As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strPrevPage As String = ""

        If Request.UrlReferrer = Nothing Then
            Response.Redirect("login.aspx")
        End If

        If strPrevPage = "" Then
            strPrevPage = Request.UrlReferrer.Segments(Request.UrlReferrer.Segments.Length - 1)
        End If

        If Not IsPostBack Then
            BindData()
        End If

        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        Dim sqlcon As New SqlConnection(con)
        sqlcon.Open()
        Dim sqlcom As New SqlCommand("select empname from Users where Username = '" & System.Web.HttpContext.Current.User.Identity.Name & "'", sqlcon)
        Dim dr As SqlDataReader = sqlcom.ExecuteReader

        If dr.Read Then
            lbllogin.Text = dr.Item("empname").ToString
            dr.Close()
        End If
        sqlcon.Close()
    End Sub

    Private Sub BindData()
        Dim sqlcon As New SqlConnection(con)
        sqlcon.Open()
        Dim cmd As New SqlCommand("select * from tbl_patientinfo order by id desc", sqlcon)
        Dim dt As DataTable = GetData(cmd)
        gvsearch.DataSource = dt
        gvsearch.DataBind()
        sqlcon.Close()
    End Sub

    Private Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()
        Dim strConnString As String = System.Configuration. _
         ConfigurationManager.ConnectionStrings("rid").ConnectionString()
        Dim conGetData As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.Connection = conGetData
        Try
            conGetData.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            conGetData.Close()
            sda.Dispose()
            conGetData.Dispose()
        End Try
    End Function

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        If tbsearch.Text.Length = 0 Then
            Dim sqlcon As New SqlConnection(con)
            sqlcon.Open()
            Dim cmd As New SqlCommand("select * from tbl_patientinfo order by id desc", sqlcon)
            Dim dt As DataTable = GetData(cmd)
            gvsearch.DataSource = dt
            gvsearch.DataBind()
            sqlcon.Close()
        Else
            Dim sqlcon As New SqlConnection(con)
            sqlcon.Open()
            Dim cmd As New SqlCommand("select * from tbl_patientinfo where lname like '%" & tbsearch.Text & "%' or fname like '%" & tbsearch.Text & "%' order by id desc", sqlcon)
            Dim dt As DataTable = GetData(cmd)
            gvsearch.DataSource = dt
            gvsearch.DataBind()
            sqlcon.Close()
        End If
    End Sub

    Protected Sub OnPaging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvsearch.PageIndexChanging
        BindData()
        gvsearch.PageIndex = e.NewPageIndex
        gvsearch.DataBind()
    End Sub

    Protected Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        BindData()
        gvsearch.PageIndex = 0
        gvsearch.DataBind()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As System.EventArgs) Handles btnsave.Click
        Dim drcon As New SqlConnection(con)
        drcon.Open()
        Dim drcom As New SqlCommand("select fileno from tbl_patientinfo where fileno = '" & txtfileno.Text & "'", drcon)
        Dim dr As SqlDataReader = drcom.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                MsgBox("File Number already exist!")
                txtfileno.Text = ""
            End While
            dr.Close()
            drcon.Close()
        Else
            drcon.Close()
            Dim sqlcon As New SqlConnection(con)
            sqlcon.Open()
            Dim cmd As New SqlCommand("insert into tbl_patientinfo " _
                                      & "(fileno, " _
                                      & "hrn, " _
                                      & "lname, " _
                                      & "fname, " _
                                      & "age, " _
                                      & "sex, " _
                                      & "loguser, " _
                                      & "logdatetime) " _
                                      & "values " _
                                      & "('" & txtfileno.Text.ToUpper & "', " _
                                      & "'" & txthrn.Text.ToUpper & "', " _
                                      & "'" & txtlname.Text.ToUpper & "', " _
                                      & "'" & txtfname.Text.ToUpper & "', " _
                                      & "'" & txtage.Text & "', " _
                                      & "'" & rblgender.Text & "', " _
                                      & "'" & lbllogin.Text & "', " _
                                      & "'" & DateTime.Now.ToString & "')", sqlcon)

            cmd.ExecuteNonQuery()
            sqlcon.Close()
            Response.Redirect(Request.RawUrl)
        End If

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        txtlname.Text = ""
        txtfname.Text = ""
        txtage.Text = ""
        rblgender.SelectedIndex = -1
        modalpop.Hide()
    End Sub

    Private Sub btnsaveedit_Click(sender As Object, e As EventArgs) Handles btnsaveedit.Click
        Dim sqleditpatient As New SqlConnection(con)
        sqleditpatient.Open()
        Dim cmdeditpatient As New SqlCommand("update tbl_patientinfo " _
                                             & "set " _
                                             & "lname = '" & txteditlname.Text.ToUpper & "', " _
                                             & "fname = '" & txteditfname.Text.ToUpper & "', " _
                                             & "age='" & txteditage.Text & "', " _
                                             & "sex = '" & rbleditgender.Text & "', " _
                                             & "loguser = '" & lbllogin.Text & "', " _
                                             & "logdatetime = '" & DateTime.Now.ToString & "' " _
                                             & "where fileno = '" & txteditfileno.Text & "'", sqleditpatient)
        cmdeditpatient.ExecuteNonQuery()
        sqleditpatient.Close()
        Response.Redirect(Request.RawUrl)
    End Sub

    Private Sub btncanceledit_Click(sender As Object, e As EventArgs) Handles btncanceledit.Click
        modaledit.Hide()
    End Sub

    Protected Sub Edit(ByVal sender As Object, ByVal e As EventArgs)
        Dim row As GridViewRow = CType(CType(sender, LinkButton).Parent.Parent, GridViewRow)
        txteditfileno.ReadOnly = True
        txteditfileno.Text = row.Cells(0).Text
        txtedithrn.ReadOnly = True
        txtedithrn.Text = row.Cells(1).Text
        txteditlname.Text = row.Cells(2).Text
        txteditfname.Text = row.Cells(3).Text
        txteditage.Text = row.Cells(4).Text
        rbleditgender.Text = row.Cells(5).Text
        modaledit.Show()
    End Sub
End Class
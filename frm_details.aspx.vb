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

Public Class frm_details
    Inherits System.Web.UI.Page

    Dim con As String = WebConfigurationManager.ConnectionStrings("rid").ConnectionString
    Dim x As String = DateTime.Now.ToString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strPrevPage As String = ""

        If Request.UrlReferrer = Nothing Then
            Response.Redirect("login.aspx")
        End If

        If strPrevPage = "" Then
            strPrevPage = Request.UrlReferrer.Segments(Request.UrlReferrer.Segments.Length - 1)
        End If

        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        Dim sqllogin As New SqlConnection(con)
        sqllogin.Open()
        Dim sqlcom As New SqlCommand("select empname from Users where Username = '" & System.Web.HttpContext.Current.User.Identity.Name & "'", sqllogin)
        Dim drlogin As SqlDataReader = sqlcom.ExecuteReader

        If drlogin.Read Then
            lbllogin.Text = drlogin.Item("empname").ToString
            drlogin.Close()
        End If
        sqllogin.Close()

        Dim sqlcon As New SqlConnection(con)
        sqlcon.Open()
        Dim cmd As New SqlCommand("select * from tbl_patientinfo where fileno = '" & Request.QueryString("fileno").ToString & "'", sqlcon)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.Read Then
            lblfileno.Text = dr.Item("fileno")
            lblhrn.Text = dr.Item("hrn")
            lbllname.Text = dr.Item("lname")
            lblfname.Text = dr.Item("fname")
            lblage.Text = dr.Item("age")
            lblsex.Text = dr.Item("sex")
        End If
        dr.Close()
        sqlcon.Close()

        If Not IsPostBack Then
            BindData()
        End If

    End Sub

    Protected Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("frm_main.aspx")
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

    Protected Sub OnPaging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvdetails.PageIndexChanging
        gvdetails.PageIndex = e.NewPageIndex
        gvdetails.DataBind()
        BindData()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As System.EventArgs) Handles btnsave.Click
        Dim varlastid As String = "'"
        Dim varfinalid As String = ""

        Dim sqllastid As New SqlConnection(con)
        sqllastid.Open()
        Dim cmdlastid As New SqlCommand("select max(lastid) from tbl_fileno", sqllastid)
        Dim drlastid As SqlDataReader = cmdlastid.ExecuteReader

        If drlastid.Read Then
            varlastid = drlastid.Item(0) + 1
            varfinalid = lblfileno.Text & "-" & varlastid
            drlastid.Close()
        End If

        Dim sqlcon As New SqlConnection(con)
        Dim sqlcom As New SqlCommand("insert into tbl_patientresults " _
                                  & "(fileno, physician, ward_no, date_exam, date_interpreted, radiologist, " _
                                  & "classification1, res1, des1, des1a, " _
                                  & "classification2, res2, des2, des2a, " _
                                  & "classification3, res3, des3, des3a, " _
                                  & "classification4, res4, des4, des4a, " _
                                  & "classification5, res5, des5, des5a, " _
                                  & "classification6, res6, des6, des6a, " _
                                  & "classification7, res7, des7, des7a, " _
                                  & "classification8, res8, des8, des8a, " _
                                  & "classification9, res9, des9, des9a, " _
                                  & "classification10, res10, des10, des10a, " _
                                  & "loguser, logdatetime, resultno) " _
                                  & "values " _
                                  & "('" & lblfileno.Text & "', '" & txtphysician.Text.ToUpper & "', '" & ddlroom.Text & "', '" & txtdoe.Text & "', '" & txtdi.Text & "', '" & ddlradiologist.Text & "', " _
                                  & "'" & ddlclassification1.Text & "', '" & ddlres1.Text & "', '" & txtdes1.Text & "', '" & txtdes1a.Text & "', " _
                                  & "'" & ddlclassification2.Text & "', '" & ddlres2.Text & "', '" & txtdes2.Text & "', '" & txtdes2a.Text & "', " _
                                  & "'" & ddlclassification3.Text & "', '" & ddlres3.Text & "', '" & txtdes3.Text & "', '" & txtdes3a.Text & "', " _
                                  & "'" & ddlclassification4.Text & "', '" & ddlres4.Text & "', '" & txtdes4.Text & "', '" & txtdes4a.Text & "', " _
                                  & "'" & ddlclassification5.Text & "', '" & ddlres5.Text & "', '" & txtdes5.Text & "', '" & txtdes5a.Text & "', " _
                                  & "'" & ddlclassification6.Text & "', '" & ddlres6.Text & "', '" & txtdes6.Text & "', '" & txtdes6a.Text & "', " _
                                  & "'" & ddlclassification7.Text & "', '" & ddlres7.Text & "', '" & txtdes7.Text & "', '" & txtdes7a.Text & "', " _
                                  & "'" & ddlclassification8.Text & "', '" & ddlres8.Text & "', '" & txtdes8.Text & "', '" & txtdes8a.Text & "', " _
                                  & "'" & ddlclassification9.Text & "', '" & ddlres9.Text & "', '" & txtdes9.Text & "', '" & txtdes9a.Text & "', " _
                                  & "'" & ddlclassification10.Text & "', '" & ddlres10.Text & "', '" & txtdes10.Text & "', '" & txtdes10a.Text & "', " _
                                  & "'" & lbllogin.Text & "', '" & DateTime.Now.ToString & "', '" & varlastid & "') " _
                                  & "update tbl_fileno set lastid = '" & varlastid & "'", sqlcon)
        sqlcon.Open()
        sqlcom.ExecuteNonQuery()
        sqlcon.Close()

        btnsave.Enabled = False
        Response.Redirect(Request.RawUrl)
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        txtphysician.Text = ""
        ddlroom.SelectedIndex = -1
        modalpopup.Hide()
    End Sub

    Private Sub btneditsave_Click(sender As Object, e As EventArgs) Handles btneditsave.Click
        Dim sqlcon As New SqlConnection(con)
        Dim cmd As New SqlCommand("update tbl_patientresults " _
                                  & "set physician='" & txteditphysician.Text.ToUpper & "', ward_no='" & ddleditroom.Text & "', date_exam='" & txteditdoe.Text & "', " _
                                  & "date_interpreted='" & txteditdi.Text & "', radiologist='" & ddleditradiologist.Text & "', " _
                                  & "classification1='" & ddleditclassification1.Text & "', res1='" & ddleditres1.Text & "', des1='" & txteditdes1.Text & "', des1a='" & txteditdes1a.Text & "', " _
                                  & "classification2='" & ddleditclassification2.Text & "', res2='" & ddleditres2.Text & "', des2='" & txteditdes2.Text & "', des2a='" & txteditdes2a.Text & "', " _
                                  & "classification3='" & ddleditclassification3.Text & "', res3='" & ddleditres3.Text & "', des3='" & txteditdes3.Text & "', des3a='" & txteditdes3a.Text & "', " _
                                  & "classification4='" & ddleditclassification4.Text & "', res4='" & ddleditres4.Text & "', des4='" & txteditdes4.Text & "', des4a='" & txteditdes4a.Text & "', " _
                                  & "classification5='" & ddleditclassification5.Text & "', res5='" & ddleditres5.Text & "', des5='" & txteditdes5.Text & "', des5a='" & txteditdes5a.Text & "', " _
                                  & "classification6='" & ddleditclassification6.Text & "', res6='" & ddleditres6.Text & "', des6='" & txteditdes6.Text & "', des6a='" & txteditdes6a.Text & "', " _
                                  & "classification7='" & ddleditclassification7.Text & "', res7='" & ddleditres7.Text & "', des7='" & txteditdes7.Text & "', des7a='" & txteditdes7a.Text & "', " _
                                  & "classification8='" & ddleditclassification8.Text & "', res8='" & ddleditres8.Text & "', des8='" & txteditdes8.Text & "', des8a='" & txteditdes8a.Text & "', " _
                                  & "classification9='" & ddleditclassification9.Text & "', res9='" & ddleditres9.Text & "', des9='" & txteditdes9.Text & "', des9a='" & txteditdes9a.Text & "', " _
                                  & "classification10='" & ddleditclassification10.Text & "', res10='" & ddleditres10.Text & "', des10='" & txteditdes10.Text & "', des10a='" & txteditdes10a.Text & "', " _
                                  & "loguser='" & lbllogin.Text & "', logdatetime='" & DateTime.Now.ToString & "' where resultno = '" & txteditresultno.Text & "'", sqlcon)
        sqlcon.Open()
        cmd.ExecuteNonQuery()
        sqlcon.Close()
        btneditsave.Enabled = False
        Response.Redirect(Request.RawUrl)
    End Sub

    Private Sub btneditcancel_Click(sender As Object, e As EventArgs) Handles btneditcancel.Click
        modaledit.Hide()
    End Sub

    '------------------------------------------------------------------------ BIND DATA ------------------------------------------------------------------------------------------------------
    Private Sub BindData()
        'GRIDVIEW
        Dim sqlcon As New SqlConnection(con)
        sqlcon.Open()
        Dim cmd As New SqlCommand("select * from tbl_patientresults where fileno = '" & Request.QueryString("fileno").ToString & "' order by id desc", sqlcon)
        Dim dt As DataTable = GetData(cmd)
        gvdetails.DataSource = dt
        gvdetails.DataBind()
        sqlcon.Close()

        'ROOM
        ddlroom.AppendDataBoundItems = True
        Dim sqlconroom As New SqlConnection(con)
        Dim sqlcomroom As New SqlCommand("select * from tbl_room order by room asc", sqlconroom)
        sqlconroom.Open()
        ddlroom.DataSource = sqlcomroom.ExecuteReader
        ddlroom.DataTextField = "room"
        ddlroom.DataValueField = "room"
        ddlroom.DataBind()
        sqlconroom.Close()
        sqlconroom.Dispose()

        'RADIOLOGIST
        ddlradiologist.AppendDataBoundItems = True
        Dim sqlconradio As New SqlConnection(con)
        Dim sqlcomradio As New SqlCommand("select * from tbl_radiologist order by radiologist asc", sqlconradio)
        sqlconradio.Open()
        ddlradiologist.DataSource = sqlcomradio.ExecuteReader
        ddlradiologist.DataTextField = "radiologist"
        ddlradiologist.DataValueField = "radiologist"
        ddlradiologist.DataBind()
        sqlconradio.Close()
        sqlconradio.Dispose()

        'CLASSIFICATION1
        ddlclassification1.AppendDataBoundItems = True
        Dim sqlconclass1 As New SqlConnection(con)
        Dim sqlcomclass1 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass1)
        sqlconclass1.Open()
        ddlclassification1.DataSource = sqlcomclass1.ExecuteReader
        ddlclassification1.DataTextField = "ClassificationName"
        ddlclassification1.DataValueField = "ClassificationID"
        ddlclassification1.DataBind()
        sqlconclass1.Close()
        sqlconclass1.Dispose()

        'CLASSIFICATION2
        ddlclassification2.AppendDataBoundItems = True
        Dim sqlconclass2 As New SqlConnection(con)
        Dim sqlcomclass2 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass2)
        sqlconclass2.Open()
        ddlclassification2.DataSource = sqlcomclass2.ExecuteReader
        ddlclassification2.DataTextField = "ClassificationName"
        ddlclassification2.DataValueField = "ClassificationID"
        ddlclassification2.DataBind()
        sqlconclass2.Close()
        sqlconclass2.Dispose()

        'CLASSIFICATION3
        ddlclassification3.AppendDataBoundItems = True
        Dim sqlconclass3 As New SqlConnection(con)
        Dim sqlcomclass3 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass3)
        sqlconclass3.Open()
        ddlclassification3.DataSource = sqlcomclass3.ExecuteReader
        ddlclassification3.DataTextField = "ClassificationName"
        ddlclassification3.DataValueField = "ClassificationID"
        ddlclassification3.DataBind()
        sqlconclass3.Close()
        sqlconclass3.Dispose()

        'CLASSIFICATION4
        ddlclassification4.AppendDataBoundItems = True
        Dim sqlconclass4 As New SqlConnection(con)
        Dim sqlcomclass4 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass4)
        sqlconclass4.Open()
        ddlclassification4.DataSource = sqlcomclass4.ExecuteReader
        ddlclassification4.DataTextField = "ClassificationName"
        ddlclassification4.DataValueField = "ClassificationID"
        ddlclassification4.DataBind()
        sqlconclass4.Close()
        sqlconclass4.Dispose()

        'CLASSIFICATION5
        ddlclassification5.AppendDataBoundItems = True
        Dim sqlconclass5 As New SqlConnection(con)
        Dim sqlcomclass5 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass5)
        sqlconclass5.Open()
        ddlclassification5.DataSource = sqlcomclass5.ExecuteReader
        ddlclassification5.DataTextField = "ClassificationName"
        ddlclassification5.DataValueField = "ClassificationID"
        ddlclassification5.DataBind()
        sqlconclass5.Close()
        sqlconclass5.Dispose()

        'CLASSIFICATION6
        ddlclassification6.AppendDataBoundItems = True
        Dim sqlconclass6 As New SqlConnection(con)
        Dim sqlcomclass6 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass6)
        sqlconclass6.Open()
        ddlclassification6.DataSource = sqlcomclass6.ExecuteReader
        ddlclassification6.DataTextField = "ClassificationName"
        ddlclassification6.DataValueField = "ClassificationID"
        ddlclassification6.DataBind()
        sqlconclass6.Close()
        sqlconclass6.Dispose()

        'CLASSIFICATION7
        ddlclassification7.AppendDataBoundItems = True
        Dim sqlconclass7 As New SqlConnection(con)
        Dim sqlcomclass7 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass7)
        sqlconclass7.Open()
        ddlclassification7.DataSource = sqlcomclass7.ExecuteReader
        ddlclassification7.DataTextField = "ClassificationName"
        ddlclassification7.DataValueField = "ClassificationID"
        ddlclassification7.DataBind()
        sqlconclass7.Close()
        sqlconclass7.Dispose()

        'CLASSIFICATION8
        ddlclassification8.AppendDataBoundItems = True
        Dim sqlconclass8 As New SqlConnection(con)
        Dim sqlcomclass8 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass8)
        sqlconclass8.Open()
        ddlclassification8.DataSource = sqlcomclass8.ExecuteReader
        ddlclassification8.DataTextField = "ClassificationName"
        ddlclassification8.DataValueField = "ClassificationID"
        ddlclassification8.DataBind()
        sqlconclass8.Close()
        sqlconclass8.Dispose()

        'CLASSIFICATION9
        ddlclassification9.AppendDataBoundItems = True
        Dim sqlconclass9 As New SqlConnection(con)
        Dim sqlcomclass9 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass9)
        sqlconclass9.Open()
        ddlclassification9.DataSource = sqlcomclass9.ExecuteReader
        ddlclassification9.DataTextField = "ClassificationName"
        ddlclassification9.DataValueField = "ClassificationID"
        ddlclassification9.DataBind()
        sqlconclass9.Close()
        sqlconclass9.Dispose()

        'CLASSIFICATION10
        ddlclassification10.AppendDataBoundItems = True
        Dim sqlconclass10 As New SqlConnection(con)
        Dim sqlcomclass10 As New SqlCommand("select * from tbl_class order by ClassificationName asc", sqlconclass10)
        sqlconclass10.Open()
        ddlclassification10.DataSource = sqlcomclass10.ExecuteReader
        ddlclassification10.DataTextField = "ClassificationName"
        ddlclassification10.DataValueField = "ClassificationID"
        ddlclassification10.DataBind()
        sqlconclass10.Close()
        sqlconclass10.Dispose()

    End Sub

    '------------------------------------------------------------------------ EDIT DATA POPULATION -------------------------------------------------------------------------------------------
    Protected Sub Edit(ByVal sender As Object, ByVal e As EventArgs)
        Dim row As GridViewRow = CType(CType(sender, LinkButton).Parent.Parent, GridViewRow)
        txteditresultno.Text = row.Cells(0).Text
        txteditphysician.Text = row.Cells(1).Text

        'EDIT ROOM
        Try
            ddleditroom.Text = row.Cells(2).Text
            Using connectioneditroom As New SqlConnection(con)
                Using commandeditroom As New SqlCommand("select * from tbl_room order by room asc")
                    commandeditroom.CommandType = CommandType.Text
                    commandeditroom.Connection = connectioneditroom
                    connectioneditroom.Open()
                    ddleditroom.DataSource = commandeditroom.ExecuteReader
                    ddleditroom.DataTextField = "room"
                    ddleditroom.DataValueField = "room"
                    ddleditroom.DataBind()
                    connectioneditroom.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditroom.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        txteditdoe.Text = row.Cells(3).Text
        txteditdi.Text = row.Cells(4).Text

        'EDIT RADIOLOGIST
        Try
            ddleditradiologist.Text = row.Cells(5).Text
            Using connectioneditradio As New SqlConnection(con)
                Using commandeditradio As New SqlCommand("select * from tbl_radiologist order by radiologist asc")
                    commandeditradio.CommandType = CommandType.Text
                    commandeditradio.Connection = connectioneditradio
                    connectioneditradio.Open()
                    ddleditradiologist.DataSource = commandeditradio.ExecuteReader
                    ddleditradiologist.DataTextField = "radiologist"
                    ddleditradiologist.DataValueField = "radiologist"
                    ddleditradiologist.DataBind()
                    connectioneditradio.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditradiologist.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT CLASSIFICATION 1
        Try
            ddleditclassification1.Text = row.Cells(6).Text
            Using connectioneditclass1 As New SqlConnection(con)
                Using commandeditclass1 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass1.CommandType = CommandType.Text
                    commandeditclass1.Connection = connectioneditclass1
                    connectioneditclass1.Open()
                    ddleditclassification1.DataSource = commandeditclass1.ExecuteReader
                    ddleditclassification1.DataTextField = "ClassificationName"
                    ddleditclassification1.DataValueField = "ClassificationID"
                    ddleditclassification1.DataBind()
                    connectioneditclass1.Close()
                End Using
            End Using
            ddleditclassification1.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification1.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 1
        Try
            ddleditres1.Text = row.Cells(7).Text
            Using connectioneditres1 As New SqlConnection(con)
                Using commandeditres1 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres1.CommandType = CommandType.Text
                    commandeditres1.Connection = connectioneditres1
                    connectioneditres1.Open()
                    ddleditres1.DataSource = commandeditres1.ExecuteReader
                    ddleditres1.DataTextField = "SubClassificationName"
                    ddleditres1.DataValueField = "SubClassificationID"
                    ddleditres1.DataBind()
                    connectioneditres1.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres1.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes1.Text = row.Cells(8).Text.Replace("&nbsp;", "")
        txteditdes1a.Text = row.Cells(9).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 2
        Try
            ddleditclassification2.Text = row.Cells(10).Text
            Using connectioneditclass2 As New SqlConnection(con)
                Using commandeditclass2 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass2.CommandType = CommandType.Text
                    commandeditclass2.Connection = connectioneditclass2
                    connectioneditclass2.Open()
                    ddleditclassification2.DataSource = commandeditclass2.ExecuteReader
                    ddleditclassification2.DataTextField = "ClassificationName"
                    ddleditclassification2.DataValueField = "ClassificationID"
                    ddleditclassification2.DataBind()
                    connectioneditclass2.Close()
                End Using
            End Using
            ddleditclassification2.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification2.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 2
        Try
            ddleditres2.Text = row.Cells(11).Text
            Using connectioneditres2 As New SqlConnection(con)
                Using commandeditres2 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres2.CommandType = CommandType.Text
                    commandeditres2.Connection = connectioneditres2
                    connectioneditres2.Open()
                    ddleditres2.DataSource = commandeditres2.ExecuteReader
                    ddleditres2.DataTextField = "SubClassificationName"
                    ddleditres2.DataValueField = "SubClassificationID"
                    ddleditres2.DataBind()
                    connectioneditres2.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres2.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes2.Text = row.Cells(12).Text.Replace("&nbsp;", "")
        txteditdes2a.Text = row.Cells(13).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 3
        Try
            ddleditclassification3.Text = row.Cells(14).Text
            Using connectioneditclass3 As New SqlConnection(con)
                Using commandeditclass3 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass3.CommandType = CommandType.Text
                    commandeditclass3.Connection = connectioneditclass3
                    connectioneditclass3.Open()
                    ddleditclassification3.DataSource = commandeditclass3.ExecuteReader
                    ddleditclassification3.DataTextField = "ClassificationName"
                    ddleditclassification3.DataValueField = "ClassificationID"
                    ddleditclassification3.DataBind()
                    connectioneditclass3.Close()
                End Using
            End Using
            ddleditclassification3.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification3.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 3
        Try
            ddleditres3.Text = row.Cells(15).Text
            Using connectioneditres3 As New SqlConnection(con)
                Using commandeditres3 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres3.CommandType = CommandType.Text
                    commandeditres3.Connection = connectioneditres3
                    connectioneditres3.Open()
                    ddleditres3.DataSource = commandeditres3.ExecuteReader
                    ddleditres3.DataTextField = "SubClassificationName"
                    ddleditres3.DataValueField = "SubClassificationID"
                    ddleditres3.DataBind()
                    connectioneditres3.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres3.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes3.Text = row.Cells(16).Text.Replace("&nbsp;", "")
        txteditdes3a.Text = row.Cells(17).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 4
        Try
            ddleditclassification4.Text = row.Cells(18).Text
            Using connectioneditclass4 As New SqlConnection(con)
                Using commandeditclass4 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass4.CommandType = CommandType.Text
                    commandeditclass4.Connection = connectioneditclass4
                    connectioneditclass4.Open()
                    ddleditclassification4.DataSource = commandeditclass4.ExecuteReader
                    ddleditclassification4.DataTextField = "ClassificationName"
                    ddleditclassification4.DataValueField = "ClassificationID"
                    ddleditclassification4.DataBind()
                    connectioneditclass4.Close()
                End Using
            End Using
            ddleditclassification4.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification4.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 4
        Try
            ddleditres4.Text = row.Cells(19).Text
            Using connectioneditres4 As New SqlConnection(con)
                Using commandeditres4 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres4.CommandType = CommandType.Text
                    commandeditres4.Connection = connectioneditres4
                    connectioneditres4.Open()
                    ddleditres4.DataSource = commandeditres4.ExecuteReader
                    ddleditres4.DataTextField = "SubClassificationName"
                    ddleditres4.DataValueField = "SubClassificationID"
                    ddleditres4.DataBind()
                    connectioneditres4.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres4.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes4.Text = row.Cells(20).Text.Replace("&nbsp;", "")
        txteditdes4a.Text = row.Cells(21).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 5
        Try
            ddleditclassification5.Text = row.Cells(22).Text
            Using connectioneditclass5 As New SqlConnection(con)
                Using commandeditclass5 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass5.CommandType = CommandType.Text
                    commandeditclass5.Connection = connectioneditclass5
                    connectioneditclass5.Open()
                    ddleditclassification5.DataSource = commandeditclass5.ExecuteReader
                    ddleditclassification5.DataTextField = "ClassificationName"
                    ddleditclassification5.DataValueField = "ClassificationID"
                    ddleditclassification5.DataBind()
                    connectioneditclass5.Close()
                End Using
            End Using
            ddleditclassification5.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification5.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 5
        Try
            ddleditres5.Text = row.Cells(23).Text
            Using connectioneditres5 As New SqlConnection(con)
                Using commandeditres5 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres5.CommandType = CommandType.Text
                    commandeditres5.Connection = connectioneditres5
                    connectioneditres5.Open()
                    ddleditres5.DataSource = commandeditres5.ExecuteReader
                    ddleditres5.DataTextField = "SubClassificationName"
                    ddleditres5.DataValueField = "SubClassificationID"
                    ddleditres5.DataBind()
                    connectioneditres5.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres5.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes5.Text = row.Cells(24).Text.Replace("&nbsp;", "")
        txteditdes5a.Text = row.Cells(25).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 6
        Try
            ddleditclassification6.Text = row.Cells(26).Text
            Using connectioneditclass6 As New SqlConnection(con)
                Using commandeditclass6 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass6.CommandType = CommandType.Text
                    commandeditclass6.Connection = connectioneditclass6
                    connectioneditclass6.Open()
                    ddleditclassification6.DataSource = commandeditclass6.ExecuteReader
                    ddleditclassification6.DataTextField = "ClassificationName"
                    ddleditclassification6.DataValueField = "ClassificationID"
                    ddleditclassification6.DataBind()
                    connectioneditclass6.Close()
                End Using
            End Using
            ddleditclassification6.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification6.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 6
        Try
            ddleditres6.Text = row.Cells(27).Text
            Using connectioneditres6 As New SqlConnection(con)
                Using commandeditres6 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres6.CommandType = CommandType.Text
                    commandeditres6.Connection = connectioneditres6
                    connectioneditres6.Open()
                    ddleditres6.DataSource = commandeditres6.ExecuteReader
                    ddleditres6.DataTextField = "SubClassificationName"
                    ddleditres6.DataValueField = "SubClassificationID"
                    ddleditres6.DataBind()
                    connectioneditres6.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres6.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes6.Text = row.Cells(28).Text.Replace("&nbsp;", "")
        txteditdes6a.Text = row.Cells(29).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 7
        Try
            ddleditclassification7.Text = row.Cells(30).Text
            Using connectioneditclass7 As New SqlConnection(con)
                Using commandeditclass7 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass7.CommandType = CommandType.Text
                    commandeditclass7.Connection = connectioneditclass7
                    connectioneditclass7.Open()
                    ddleditclassification7.DataSource = commandeditclass7.ExecuteReader
                    ddleditclassification7.DataTextField = "ClassificationName"
                    ddleditclassification7.DataValueField = "ClassificationID"
                    ddleditclassification7.DataBind()
                    connectioneditclass7.Close()
                End Using
            End Using
            ddleditclassification7.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification7.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 7
        Try
            ddleditres7.Text = row.Cells(31).Text
            Using connectioneditres7 As New SqlConnection(con)
                Using commandeditres7 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres7.CommandType = CommandType.Text
                    commandeditres7.Connection = connectioneditres7
                    connectioneditres7.Open()
                    ddleditres7.DataSource = commandeditres7.ExecuteReader
                    ddleditres7.DataTextField = "SubClassificationName"
                    ddleditres7.DataValueField = "SubClassificationID"
                    ddleditres7.DataBind()
                    connectioneditres7.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres7.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes7.Text = row.Cells(32).Text.Replace("&nbsp;", "")
        txteditdes7a.Text = row.Cells(33).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 8
        Try
            ddleditclassification8.Text = row.Cells(34).Text
            Using connectioneditclass8 As New SqlConnection(con)
                Using commandeditclass8 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass8.CommandType = CommandType.Text
                    commandeditclass8.Connection = connectioneditclass8
                    connectioneditclass8.Open()
                    ddleditclassification8.DataSource = commandeditclass8.ExecuteReader
                    ddleditclassification8.DataTextField = "ClassificationName"
                    ddleditclassification8.DataValueField = "ClassificationID"
                    ddleditclassification8.DataBind()
                    connectioneditclass8.Close()
                End Using
            End Using
            ddleditclassification8.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification8.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 8
        Try
            ddleditres8.Text = row.Cells(35).Text
            Using connectioneditres8 As New SqlConnection(con)
                Using commandeditres8 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres8.CommandType = CommandType.Text
                    commandeditres8.Connection = connectioneditres8
                    connectioneditres8.Open()
                    ddleditres8.DataSource = commandeditres8.ExecuteReader
                    ddleditres8.DataTextField = "SubClassificationName"
                    ddleditres8.DataValueField = "SubClassificationID"
                    ddleditres8.DataBind()
                    connectioneditres8.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres8.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes8.Text = row.Cells(36).Text.Replace("&nbsp;", "")
        txteditdes8a.Text = row.Cells(37).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 9
        Try
            ddleditclassification9.Text = row.Cells(38).Text
            Using connectioneditclass9 As New SqlConnection(con)
                Using commandeditclass9 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass9.CommandType = CommandType.Text
                    commandeditclass9.Connection = connectioneditclass9
                    connectioneditclass9.Open()
                    ddleditclassification9.DataSource = commandeditclass9.ExecuteReader
                    ddleditclassification9.DataTextField = "ClassificationName"
                    ddleditclassification9.DataValueField = "ClassificationID"
                    ddleditclassification9.DataBind()
                    connectioneditclass9.Close()
                End Using
            End Using
            ddleditclassification9.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification9.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 9
        Try
            ddleditres9.Text = row.Cells(39).Text
            Using connectioneditres9 As New SqlConnection(con)
                Using commandeditres9 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres9.CommandType = CommandType.Text
                    commandeditres9.Connection = connectioneditres9
                    connectioneditres9.Open()
                    ddleditres9.DataSource = commandeditres9.ExecuteReader
                    ddleditres9.DataTextField = "SubClassificationName"
                    ddleditres9.DataValueField = "SubClassificationID"
                    ddleditres9.DataBind()
                    connectioneditres9.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres9.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes9.Text = row.Cells(40).Text.Replace("&nbsp;", "")
        txteditdes9a.Text = row.Cells(41).Text.Replace("&nbsp;", "")

        'EDIT CLASSIFICATION 10
        Try
            ddleditclassification10.Text = row.Cells(42).Text
            Using connectioneditclass10 As New SqlConnection(con)
                Using commandeditclass10 As New SqlCommand("select * from tbl_class order by ClassificationName asc")
                    commandeditclass10.CommandType = CommandType.Text
                    commandeditclass10.Connection = connectioneditclass10
                    connectioneditclass10.Open()
                    ddleditclassification10.DataSource = commandeditclass10.ExecuteReader
                    ddleditclassification10.DataTextField = "ClassificationName"
                    ddleditclassification10.DataValueField = "ClassificationID"
                    ddleditclassification10.DataBind()
                    connectioneditclass10.Close()
                End Using
            End Using
            ddleditclassification10.Items.Insert(0, New ListItem("--Select Item--", "0"))
        Catch ex As Exception
            ddleditclassification10.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try

        'EDIT RESULT 10
          Try
            ddleditres10.Text = row.Cells(43).Text
            Using connectioneditres10 As New SqlConnection(con)
                Using commandeditres10 As New SqlCommand("select * from tbl_subclass order by SubClassificationName asc")
                    commandeditres10.CommandType = CommandType.Text
                    commandeditres10.Connection = connectioneditres10
                    connectioneditres10.Open()
                    ddleditres10.DataSource = commandeditres10.ExecuteReader
                    ddleditres10.DataTextField = "SubClassificationName"
                    ddleditres10.DataValueField = "SubClassificationID"
                    ddleditres10.DataBind()
                    connectioneditres10.Close()
                End Using
            End Using
        Catch ex As Exception
            ddleditres10.Items.Insert(0, New ListItem("--Select Item--", "0"))
        End Try
        txteditdes10.Text = row.Cells(44).Text.Replace("&nbsp;", "")
        txteditdes10a.Text = row.Cells(45).Text.Replace("&nbsp;", "")

        modaledit.Show()
    End Sub

    Protected Sub ddlclassification1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres1.Items.Clear()
        ddlres1.Items.Add(New ListItem("--Select Item--", ""))
        txtdes1.Text = ""
        txtdes1a.Text = ""
        ddlres1.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification1.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres1.DataSource = com.ExecuteReader
        ddlres1.DataTextField = "SubClassificationName"
        ddlres1.DataValueField = "SubClassificationID"
        ddlres1.DataBind()
        If ddlres1.Items.Count > 1 Then
            ddlres1.Enabled = True
        Else
            ddlres1.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes1.Text = ""
        txtdes1a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres1.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes1.Text = dr("Desc1").ToString
                txtdes1a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres2.Items.Clear()
        ddlres2.Items.Add(New ListItem("--Select Item--", ""))
        txtdes2.Text = ""
        txtdes2a.Text = ""
        ddlres2.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification2.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres2.DataSource = com.ExecuteReader
        ddlres2.DataTextField = "SubClassificationName"
        ddlres2.DataValueField = "SubClassificationID"
        ddlres2.DataBind()
        If ddlres2.Items.Count > 1 Then
            ddlres2.Enabled = True
        Else
            ddlres2.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes2.Text = ""
        txtdes2a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres2.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes2.Text = dr("Desc1").ToString
                txtdes2a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres3.Items.Clear()
        ddlres3.Items.Add(New ListItem("--Select Item--", ""))
        txtdes3.Text = ""
        txtdes3a.Text = ""
        ddlres3.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification3.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres3.DataSource = com.ExecuteReader
        ddlres3.DataTextField = "SubClassificationName"
        ddlres3.DataValueField = "SubClassificationID"
        ddlres3.DataBind()
        If ddlres3.Items.Count > 1 Then
            ddlres3.Enabled = True
        Else
            ddlres3.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes3.Text = ""
        txtdes3a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres3.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes3.Text = dr("Desc1").ToString
                txtdes3a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres4.Items.Clear()
        ddlres4.Items.Add(New ListItem("--Select Item--", ""))
        txtdes4.Text = ""
        txtdes4a.Text = ""
        ddlres4.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification4.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres4.DataSource = com.ExecuteReader
        ddlres4.DataTextField = "SubClassificationName"
        ddlres4.DataValueField = "SubClassificationID"
        ddlres4.DataBind()
        If ddlres4.Items.Count > 1 Then
            ddlres4.Enabled = True
        Else
            ddlres4.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes4.Text = ""
        txtdes4a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres4.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes4.Text = dr("Desc1").ToString
                txtdes4a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification5_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres5.Items.Clear()
        ddlres5.Items.Add(New ListItem("--Select Item--", ""))
        txtdes5.Text = ""
        txtdes5a.Text = ""
        ddlres5.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification5.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres5.DataSource = com.ExecuteReader
        ddlres5.DataTextField = "SubClassificationName"
        ddlres5.DataValueField = "SubClassificationID"
        ddlres5.DataBind()
        If ddlres5.Items.Count > 1 Then
            ddlres5.Enabled = True
        Else
            ddlres5.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres5_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes5.Text = ""
        txtdes5a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres5.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes5.Text = dr("Desc1").ToString
                txtdes5a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification6_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres6.Items.Clear()
        ddlres6.Items.Add(New ListItem("--Select Item--", ""))
        txtdes6.Text = ""
        txtdes6a.Text = ""
        ddlres6.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification6.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres6.DataSource = com.ExecuteReader
        ddlres6.DataTextField = "SubClassificationName"
        ddlres6.DataValueField = "SubClassificationID"
        ddlres6.DataBind()
        If ddlres6.Items.Count > 1 Then
            ddlres6.Enabled = True
        Else
            ddlres6.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres6_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes6.Text = ""
        txtdes6a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres6.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes6.Text = dr("Desc1").ToString
                txtdes6a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres7.Items.Clear()
        ddlres7.Items.Add(New ListItem("--Select Item--", ""))
        txtdes7.Text = ""
        txtdes7a.Text = ""
        ddlres7.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification7.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres7.DataSource = com.ExecuteReader
        ddlres7.DataTextField = "SubClassificationName"
        ddlres7.DataValueField = "SubClassificationID"
        ddlres7.DataBind()
        If ddlres7.Items.Count > 1 Then
            ddlres7.Enabled = True
        Else
            ddlres7.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes7.Text = ""
        txtdes7a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres7.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes7.Text = dr("Desc1").ToString
                txtdes7a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification8_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres8.Items.Clear()
        ddlres8.Items.Add(New ListItem("--Select Item--", ""))
        txtdes8.Text = ""
        txtdes8a.text = ""
        ddlres8.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification8.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres8.DataSource = com.ExecuteReader
        ddlres8.DataTextField = "SubClassificationName"
        ddlres8.DataValueField = "SubClassificationID"
        ddlres8.DataBind()
        If ddlres8.Items.Count > 1 Then
            ddlres8.Enabled = True
        Else
            ddlres8.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres8_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes8.Text = ""
        txtdes8a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres8.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes8.Text = dr("Desc1").ToString
                txtdes8a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification9_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres9.Items.Clear()
        ddlres9.Items.Add(New ListItem("--Select Item--", ""))
        txtdes9.Text = ""
        txtdes9a.Text = ""
        ddlres9.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddlclassification9.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres9.DataSource = com.ExecuteReader
        ddlres9.DataTextField = "SubClassificationName"
        ddlres9.DataValueField = "SubClassificationID"
        ddlres9.DataBind()
        If ddlres9.Items.Count > 1 Then
            ddlres9.Enabled = True
        Else
            ddlres9.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres9_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes9.Text = ""
        txtdes9a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres9.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes9.Text = dr("Desc1").ToString
                txtdes9a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddlclassification10_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlres10.Items.Clear()
        ddlres10.Items.Add(New ListItem("--Select Item--", ""))
        txtdes10.Text = ""
        txtdes10a.Text = ""
        ddlres10.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where SubClassificationID = '" & ddlclassification10.SelectedItem.Value & "'", sqlcon)
        sqlcon.Open()
        ddlres10.DataSource = com.ExecuteReader
        ddlres10.DataTextField = "SubClassificationName"
        ddlres10.DataValueField = "SubClassificationID"
        ddlres10.DataBind()
        If ddlres10.Items.Count > 1 Then
            ddlres10.Enabled = True
        Else
            ddlres10.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddlres10_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtdes10.Text = ""
        txtdes10a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddlres10.SelectedItem.Value & "'", sqlcon)

        sqlcon.Open()

        Dim dr As SqlDataReader = com.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtdes10.Text = dr("Desc1").ToString
                txtdes10a.Text = dr("Desc2").ToString
            End While
        End If

        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres1.Items.Clear()
        ddleditres1.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes1.Text = ""
        txteditdes1a.Text = ""
        ddleditres1.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification1.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres1.DataSource = com.ExecuteReader
        ddleditres1.DataTextField = "SubClassificationName"
        ddleditres1.DataValueField = "SubClassificationID"
        ddleditres1.DataBind()
        If ddleditres1.Items.Count > 1 Then
            ddleditres1.Enabled = True
        Else
            ddleditres1.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes1.Text = ""
        txteditdes1a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres1.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes1.Text = dr("Desc1").ToString
                txteditdes1a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres2.Items.Clear()
        ddleditres2.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes2.Text = ""
        txteditdes2a.Text = ""
        ddleditres2.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification2.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres2.DataSource = com.ExecuteReader
        ddleditres2.DataTextField = "SubClassificationName"
        ddleditres2.DataValueField = "SubClassificationID"
        ddleditres2.DataBind()
        If ddleditres2.Items.Count > 1 Then
            ddleditres2.Enabled = True
        Else
            ddleditres2.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes2.Text = ""
        txteditdes2a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres2.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes2.Text = dr("Desc1").ToString
                txteditdes2a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres3.Items.Clear()
        ddleditres3.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes3.Text = ""
        txteditdes3a.Text = ""
        ddleditres3.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification3.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres3.DataSource = com.ExecuteReader
        ddleditres3.DataTextField = "SubClassificationName"
        ddleditres3.DataValueField = "SubClassificationID"
        ddleditres3.DataBind()
        If ddleditres3.Items.Count > 1 Then
            ddleditres3.Enabled = True
        Else
            ddleditres3.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes3.Text = ""
        txteditdes3a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres3.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes3.Text = dr("Desc1").ToString
                txteditdes3a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres4.Items.Clear()
        ddleditres4.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes4.Text = ""
        txteditdes4a.Text = ""
        ddleditres4.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification4.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres4.DataSource = com.ExecuteReader
        ddleditres4.DataTextField = "SubClassificationName"
        ddleditres4.DataValueField = "SubClassificationID"
        ddleditres4.DataBind()
        If ddleditres4.Items.Count > 1 Then
            ddleditres4.Enabled = True
        Else
            ddleditres4.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes4.Text = ""
        txteditdes4a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres4.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes4.Text = dr("Desc1").ToString
                txteditdes4a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification5_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres5.Items.Clear()
        ddleditres5.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes5.Text = ""
        txteditdes5a.Text = ""
        ddleditres5.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification5.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres5.DataSource = com.ExecuteReader
        ddleditres5.DataTextField = "SubClassificationName"
        ddleditres5.DataValueField = "SubClassificationID"
        ddleditres5.DataBind()
        If ddleditres5.Items.Count > 1 Then
            ddleditres5.Enabled = True
        Else
            ddleditres5.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres5_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes5.Text = ""
        txteditdes5a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres5.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes5.Text = dr("Desc1").ToString
                txteditdes5a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification6_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres6.Items.Clear()
        ddleditres6.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes6.Text = ""
        txteditdes6a.Text = ""
        ddleditres6.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification6.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres6.DataSource = com.ExecuteReader
        ddleditres6.DataTextField = "SubClassificationName"
        ddleditres6.DataValueField = "SubClassificationID"
        ddleditres6.DataBind()
        If ddleditres6.Items.Count > 1 Then
            ddleditres6.Enabled = True
        Else
            ddleditres6.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres6_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes6.Text = ""
        txteditdes6a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres6.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes6.Text = dr("Desc1").ToString
                txteditdes6a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres7.Items.Clear()
        ddleditres7.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes7.Text = ""
        txteditdes7a.Text = ""
        ddleditres7.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification7.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres7.DataSource = com.ExecuteReader
        ddleditres7.DataTextField = "SubClassificationName"
        ddleditres7.DataValueField = "SubClassificationID"
        ddleditres7.DataBind()
        If ddleditres7.Items.Count > 1 Then
            ddleditres7.Enabled = True
        Else
            ddleditres7.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes7.Text = ""
        txteditdes7a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres7.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes7.Text = dr("Desc1").ToString
                txteditdes7a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification8_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres8.Items.Clear()
        ddleditres8.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes8.Text = ""
        txteditdes8a.Text = ""
        ddleditres8.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification8.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres8.DataSource = com.ExecuteReader
        ddleditres8.DataTextField = "SubClassificationName"
        ddleditres8.DataValueField = "SubClassificationID"
        ddleditres8.DataBind()
        If ddleditres8.Items.Count > 1 Then
            ddleditres8.Enabled = True
        Else
            ddleditres8.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres8_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes8.Text = ""
        txteditdes8a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres8.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes8.Text = dr("Desc1").ToString
                txteditdes8a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification9_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres9.Items.Clear()
        ddleditres9.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes9.Text = ""
        txteditdes9a.Text = ""
        ddleditres9.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification9.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres9.DataSource = com.ExecuteReader
        ddleditres9.DataTextField = "SubClassificationName"
        ddleditres9.DataValueField = "SubClassificationID"
        ddleditres9.DataBind()
        If ddleditres9.Items.Count > 1 Then
            ddleditres9.Enabled = True
        Else
            ddleditres9.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres9_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes9.Text = ""
        txteditdes9a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres9.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes9.Text = dr("Desc1").ToString
                txteditdes9a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Protected Sub ddleditclassification10_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddleditres10.Items.Clear()
        ddleditres10.Items.Add(New ListItem("--Select Item--", ""))
        txteditdes10.Text = ""
        txteditdes10a.Text = ""
        ddleditres10.AppendDataBoundItems = True
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclass where ClassificationID = '" & ddleditclassification10.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        ddleditres10.DataSource = com.ExecuteReader
        ddleditres10.DataTextField = "SubClassificationName"
        ddleditres10.DataValueField = "SubClassificationID"
        ddleditres10.DataBind()
        If ddleditres10.Items.Count > 1 Then
            ddleditres10.Enabled = True
        Else
            ddleditres10.Enabled = False
        End If
        sqlcon.Close()
    End Sub

    Protected Sub ddleditres10_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txteditdes10.Text = ""
        txteditdes10a.Text = ""
        Dim sqlcon As New SqlConnection(con)
        Dim com As New SqlCommand("select * from tbl_subclassdesc where SubClassificationID = '" & ddleditres10.SelectedValue & "'", sqlcon)
        sqlcon.Open()
        Dim dr As SqlDataReader = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                txteditdes10.Text = dr("Desc1").ToString
                txteditdes10a.Text = dr("Desc2").ToString
            End While
        End If
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub
End Class
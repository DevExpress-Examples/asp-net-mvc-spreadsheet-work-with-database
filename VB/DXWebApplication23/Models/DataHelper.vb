Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Web
Imports DevExpress.Spreadsheet

Namespace DXWebApplication23.Models
    Public Class DataHelper
        Public Shared Function GetDocument() As Byte()
            Dim context As New DataClassesDataContext()
            Return context.Docs.FirstOrDefault().DocBytes.ToArray()
        End Function

        Public Shared Sub SaveDocument(ByVal bytes() As Byte)
            Dim context As New DataClassesDataContext()
            context.Docs.FirstOrDefault().DocBytes = bytes
            context.SubmitChanges()
        End Sub
    End Class

    Public Class SpreadsheetData
        Private privateDocumentId As String
        Public Property DocumentId() As String
            Get
                Return privateDocumentId
            End Get
            Set(ByVal value As String)
                privateDocumentId = value
            End Set
        End Property
        Private privateDocumentFormat As DocumentFormat
        Public Property DocumentFormat() As DocumentFormat
            Get
                Return privateDocumentFormat
            End Get
            Set(ByVal value As DocumentFormat)
                privateDocumentFormat = value
            End Set
        End Property
        Private privateDocument As Byte()
        Public Property Document() As Byte()
            Get
                Return privateDocument
            End Get
            Set(ByVal value As Byte())
                privateDocument = value
            End Set
        End Property
    End Class
End Namespace
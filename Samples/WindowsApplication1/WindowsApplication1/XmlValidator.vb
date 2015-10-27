Imports System
Imports System.IO
Imports System.Text
Imports System.Xml

Namespace Greg.XmlEditor.Business.Concrete
	Public Class XmlValidator
		Private log As StringBuilder

		Public Sub New()
			Me.Reset()
		End Sub

		Public Function Validate(ByVal xmlString As String) As Boolean
			Me.Reset()
			Dim result = False
			Try
				Using reader = XmlReader.Create(New StringReader(xmlString))
					Do While reader.Read()
					Loop
					reader.Close()
				End Using

				Me.log.Append("Document sintax check successful!")

				result = True
			Catch ex As XmlException
				Me.LogError(ex.Message)
			End Try

			Return result
		End Function

		Public Function Validate(ByVal xmlString As String, ByVal xmlSchemaPath As String) As Boolean
			Me.Reset()
			Dim result = False
			Try
				Dim settings = New XmlReaderSettings()
				settings.Schemas.Add("", xmlSchemaPath)
				settings.ValidationType = ValidationType.Schema

				Using reader = XmlReader.Create(New StringReader(xmlString), settings)
					Do While reader.Read()
					Loop
					reader.Close()
				End Using


				log.Append("Document sintax check successful!")

				result = True
			Catch ex As Exception
				Me.LogError(ex.Message)
			End Try

			Return result
		End Function

		Public ReadOnly Property ValidationResult() As String
			Get
				Return log.ToString()
			End Get
		End Property

		Private Sub Reset()
			log = New StringBuilder()
		End Sub

		Private Sub LogError(ByVal [error] As String)
			log.Append([error])
			log.AppendLine()
		End Sub
	End Class
End Namespace
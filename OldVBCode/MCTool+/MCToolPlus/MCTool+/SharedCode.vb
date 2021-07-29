Imports System.IO
Module SharedCode
    Public Class ErrorHandler
        Public Shared Sub HandleError(GenError As Exception)
            Select Case GenError.GetType
                Case GetType(AccessViolationException)
                    MsgBox("Unable to get access to the specified directory.", MsgBoxStyle.Exclamation, "Access Error")
                Case GetType(UnauthorizedAccessException)
                    MsgBox("Unable to get write access to specified directory.", MsgBoxStyle.Exclamation, "Write Access Error")
                Case GetType(FileNotFoundException)
                    MsgBox("Unable to find the specified file.", MsgBoxStyle.Exclamation, "File not found Error")
                Case GetType(DirectoryNotFoundException)
                    MsgBox("Unable to find the specified directory.", MsgBoxStyle.Exclamation, "Directory not found Error")
                Case GetType(IOException)
                    MsgBox($"Unable to create/modify the specified file.", MsgBoxStyle.Exclamation, "I/O Error")
                Case Else
                    MsgBox("Unknown Error", MsgBoxStyle.Critical, "Application")
            End Select
        End Sub
    End Class
End Module

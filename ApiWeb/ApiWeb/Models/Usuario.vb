'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Usuario
    Public Property IdUsuario As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Correo As String
    Public Property idRol As Integer
    Public Property Cedula As Nullable(Of Short)
    Public Property Telefono As Nullable(Of Short)

    Public Overridable Property Roles As Roles
    Public Overridable Property Solicitud As ICollection(Of Solicitud) = New HashSet(Of Solicitud)

End Class
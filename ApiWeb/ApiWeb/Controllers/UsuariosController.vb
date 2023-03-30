Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports ApiWeb

Namespace Controllers
    Public Class UsuariosController
        Inherits System.Web.Http.ApiController

        Private db As New TareaProg3Entities

        ' GET: api/Usuarios
        Function GetUsuario() As IQueryable(Of Usuario)
            Return db.Usuario
        End Function

        ' GET: api/Usuarios/5
        <ResponseType(GetType(Usuario))>
        Function GetUsuario(ByVal id As Integer) As IHttpActionResult
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return NotFound()
            End If

            Return Ok(usuario)
        End Function

        ' PUT: api/Usuarios/5
        <ResponseType(GetType(Void))>
        Function PutUsuario(ByVal id As Integer, ByVal usuario As Usuario) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = usuario.IdUsuario Then
                Return BadRequest()
            End If

            db.Entry(usuario).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (UsuarioExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Usuarios
        <ResponseType(GetType(Usuario))>
        Function PostUsuario(ByVal usuario As Usuario) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Usuario.Add(usuario)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = usuario.IdUsuario}, usuario)
        End Function

        ' DELETE: api/Usuarios/5
        <ResponseType(GetType(Usuario))>
        Function DeleteUsuario(ByVal id As Integer) As IHttpActionResult
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return NotFound()
            End If

            db.Usuario.Remove(usuario)
            db.SaveChanges()

            Return Ok(usuario)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function UsuarioExists(ByVal id As Integer) As Boolean
            Return db.Usuario.Count(Function(e) e.IdUsuario = id) > 0
        End Function
    End Class
End Namespace
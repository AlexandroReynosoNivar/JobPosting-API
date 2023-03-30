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
    Public Class RolesController
        Inherits System.Web.Http.ApiController

        Private db As New TareaProg3Entities

        ' GET: api/Roles
        Function GetRoles() As IQueryable(Of Roles)
            Return db.Roles
        End Function

        ' GET: api/Roles/5
        <ResponseType(GetType(Roles))>
        Function GetRoles(ByVal id As Integer) As IHttpActionResult
            Dim roles As Roles = db.Roles.Find(id)
            If IsNothing(roles) Then
                Return NotFound()
            End If

            Return Ok(roles)
        End Function

        ' PUT: api/Roles/5
        <ResponseType(GetType(Void))>
        Function PutRoles(ByVal id As Integer, ByVal roles As Roles) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = roles.IDRol Then
                Return BadRequest()
            End If

            db.Entry(roles).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (RolesExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Roles
        <ResponseType(GetType(Roles))>
        Function PostRoles(ByVal roles As Roles) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Roles.Add(roles)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = roles.IDRol}, roles)
        End Function

        ' DELETE: api/Roles/5
        <ResponseType(GetType(Roles))>
        Function DeleteRoles(ByVal id As Integer) As IHttpActionResult
            Dim roles As Roles = db.Roles.Find(id)
            If IsNothing(roles) Then
                Return NotFound()
            End If

            db.Roles.Remove(roles)
            db.SaveChanges()

            Return Ok(roles)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function RolesExists(ByVal id As Integer) As Boolean
            Return db.Roles.Count(Function(e) e.IDRol = id) > 0
        End Function
    End Class
End Namespace
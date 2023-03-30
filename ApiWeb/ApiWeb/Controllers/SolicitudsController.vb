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
    Public Class SolicitudsController
        Inherits System.Web.Http.ApiController

        Private db As New TareaProg3Entities

        ' GET: api/Solicituds
        Function GetSolicitud() As IQueryable(Of Solicitud)
            Return db.Solicitud
        End Function

        ' GET: api/Solicituds/5
        <ResponseType(GetType(Solicitud))>
        Function GetSolicitud(ByVal id As Integer) As IHttpActionResult
            Dim solicitud As Solicitud = db.Solicitud.Find(id)
            If IsNothing(solicitud) Then
                Return NotFound()
            End If

            Return Ok(solicitud)
        End Function

        ' PUT: api/Solicituds/5
        <ResponseType(GetType(Void))>
        Function PutSolicitud(ByVal id As Integer, ByVal solicitud As Solicitud) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = solicitud.IdSolicitud Then
                Return BadRequest()
            End If

            db.Entry(solicitud).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (SolicitudExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Solicituds
        <ResponseType(GetType(Solicitud))>
        Function PostSolicitud(ByVal solicitud As Solicitud) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Solicitud.Add(solicitud)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = solicitud.IdSolicitud}, solicitud)
        End Function

        ' DELETE: api/Solicituds/5
        <ResponseType(GetType(Solicitud))>
        Function DeleteSolicitud(ByVal id As Integer) As IHttpActionResult
            Dim solicitud As Solicitud = db.Solicitud.Find(id)
            If IsNothing(solicitud) Then
                Return NotFound()
            End If

            db.Solicitud.Remove(solicitud)
            db.SaveChanges()

            Return Ok(solicitud)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function SolicitudExists(ByVal id As Integer) As Boolean
            Return db.Solicitud.Count(Function(e) e.IdSolicitud = id) > 0
        End Function
    End Class
End Namespace
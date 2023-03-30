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
    Public Class VacantesController
        Inherits System.Web.Http.ApiController

        Private db As New TareaProg3Entities

        ' GET: api/Vacantes
        Function GetVacantes() As IQueryable(Of Vacantes)
            Return db.Vacantes
        End Function

        ' GET: api/Vacantes/5
        <ResponseType(GetType(Vacantes))>
        Function GetVacantes(ByVal id As Integer) As IHttpActionResult
            Dim vacantes As Vacantes = db.Vacantes.Find(id)
            If IsNothing(vacantes) Then
                Return NotFound()
            End If

            Return Ok(vacantes)
        End Function

        ' PUT: api/Vacantes/5
        <ResponseType(GetType(Void))>
        Function PutVacantes(ByVal id As Integer, ByVal vacantes As Vacantes) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = vacantes.IdVacante Then
                Return BadRequest()
            End If

            db.Entry(vacantes).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (VacantesExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Vacantes
        <ResponseType(GetType(Vacantes))>
        Function PostVacantes(ByVal vacantes As Vacantes) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Vacantes.Add(vacantes)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = vacantes.IdVacante}, vacantes)
        End Function

        ' DELETE: api/Vacantes/5
        <ResponseType(GetType(Vacantes))>
        Function DeleteVacantes(ByVal id As Integer) As IHttpActionResult
            Dim vacantes As Vacantes = db.Vacantes.Find(id)
            If IsNothing(vacantes) Then
                Return NotFound()
            End If

            db.Vacantes.Remove(vacantes)
            db.SaveChanges()

            Return Ok(vacantes)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function VacantesExists(ByVal id As Integer) As Boolean
            Return db.Vacantes.Count(Function(e) e.IdVacante = id) > 0
        End Function
    End Class
End Namespace
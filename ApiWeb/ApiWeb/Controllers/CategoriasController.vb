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
    Public Class CategoriasController
        Inherits System.Web.Http.ApiController

        Private db As New TareaProg3Entities

        ' GET: api/Categorias
        Function GetCategoria() As IQueryable(Of Categoria)
            Return db.Categoria
        End Function

        ' GET: api/Categorias/5
        <ResponseType(GetType(Categoria))>
        Function GetCategoria(ByVal id As Integer) As IHttpActionResult
            Dim categoria As Categoria = db.Categoria.Find(id)
            If IsNothing(categoria) Then
                Return NotFound()
            End If

            Return Ok(categoria)
        End Function

        ' PUT: api/Categorias/5
        <ResponseType(GetType(Void))>
        Function PutCategoria(ByVal id As Integer, ByVal categoria As Categoria) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = categoria.IdCategoria Then
                Return BadRequest()
            End If

            db.Entry(categoria).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CategoriaExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Categorias
        <ResponseType(GetType(Categoria))>
        Function PostCategoria(ByVal categoria As Categoria) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Categoria.Add(categoria)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = categoria.IdCategoria}, categoria)
        End Function

        ' DELETE: api/Categorias/5
        <ResponseType(GetType(Categoria))>
        Function DeleteCategoria(ByVal id As Integer) As IHttpActionResult
            Dim categoria As Categoria = db.Categoria.Find(id)
            If IsNothing(categoria) Then
                Return NotFound()
            End If

            db.Categoria.Remove(categoria)
            db.SaveChanges()

            Return Ok(categoria)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CategoriaExists(ByVal id As Integer) As Boolean
            Return db.Categoria.Count(Function(e) e.IdCategoria = id) > 0
        End Function
    End Class
End Namespace
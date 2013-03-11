Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace Data

 Partial Public Class SqlDataProvider

  Public Overrides Sub ApproveComment(commentId As Int32)
   SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "ApproveComment", commentId)
  End Sub

  Public Overrides Sub DeleteBlogPermissions(blogId As Int32)
   SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "DeleteBlogPermissions", blogId)
  End Sub

  Public Overrides Function GetBlog(blogId As Int32, userId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetBlog", blogId, userId), IDataReader)
  End Function

  Public Overrides Function GetBlogPermissionsByBlog(blogId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetBlogPermissionsByBlog", blogId), IDataReader)
  End Function

  Public Overrides Function GetBlogsByModule(moduleId As Int32, userId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetBlogsByModule", moduleId, userId), IDataReader)
  End Function

  Public Overrides Function GetEntries(moduleId As Int32, blogID As Int32, published As Int32, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetEntries", moduleId, blogID, published, endDate, authorUserId, pageIndex, pageSize, orderBy), IDataReader)
  End Function

  Public Overrides Function GetEntriesByTerm(moduleId As Int32, blogID As Int32, termID As Int32, published As Int32, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetEntriesByTerm", moduleId, blogID, termID, published, endDate, authorUserId, pageIndex, pageSize, orderBy), IDataReader)
  End Function

  Public Overrides Function GetTerm(termId As Int32, moduleId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetTerm", termId, moduleId), IDataReader)
  End Function

  Public Overrides Function GetTermsByEntry(contentItemId As Int32, moduleId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetTermsByEntry", contentItemId, moduleId), IDataReader)
  End Function

  Public Overrides Function GetTermsByModule(moduleId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetTermsByModule", moduleId), IDataReader)
  End Function

  Public Overrides Function GetTermsByVocabulary(moduleId As Int32, vocabularyId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetTermsByVocabulary", moduleId, vocabularyId), IDataReader)
  End Function

  Public Overrides Function GetUserPermissionsByModule(moduleID As Int32, userId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetUserPermissionsByModule", moduleID, userId), IDataReader)
  End Function

  Public Overrides Function GetUsersByBlogPermission(portalId As Int32, blogId As Int32, permissionId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetUsersByBlogPermission", portalId, blogId, permissionId), IDataReader)
  End Function

  Public Overrides Function SearchEntries(moduleId As Int32, blogID As Int32, searchText As String, searchTitle As Boolean, searchContents As Boolean, published As Int32, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "SearchEntries", moduleId, blogID, searchText, searchTitle, searchContents, published, endDate, authorUserId, pageIndex, pageSize, orderBy), IDataReader)
  End Function

  Public Overrides Function SearchEntriesByTerm(moduleId As Int32, blogID As Int32, termID As Int32, searchText As String, searchTitle As Boolean, searchContents As Boolean, published As Int32, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "SearchEntriesByTerm", moduleId, blogID, termID, searchText, searchTitle, searchContents, published, endDate, authorUserId, pageIndex, pageSize, orderBy), IDataReader)
  End Function

 End Class

End Namespace

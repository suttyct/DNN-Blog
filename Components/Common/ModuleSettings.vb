﻿'
' Bring2mind - http://www.bring2mind.net
' Copyright (c) 2013
' by Bring2mind
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System.Xml
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Services.Tokens
Imports DotNetNuke.Modules.Blog.Common.Globals

Namespace Common
 <Serializable()>
 Public Class ModuleSettings
  Implements IPropertyAccess

#Region " Private Members "
  Private _allSettings As Hashtable = Nothing
  Private _moduleId As Integer = -1
  Private _importedModuleId As Integer = -1
#End Region

#Region " Properties "
  Public Property AllowWLW As Boolean = False
  Public Property AllowMultipleCategories As Boolean = True
  Public Property VocabularyId As Integer = -1
  Public Property AllowAttachments As Boolean = True
  Public Property SummaryModel As SummaryType = SummaryType.HtmlIndependent
  Public Property StyleDetectionUrl As String = ""
  Public Property WLWRecentPostsMax As Integer = 10
  Public Property AutoGenerateMissingSummary As Boolean = True
  Public Property AutoGeneratedSummaryLength As Integer = 1000

  Public Property ModifyPageDetails As Boolean = True

  Public Property RssEmail As String = ""
  Public Property RssDefaultNrItems As Integer = 20
  Public Property RssMaxNrItems As Integer = 50
  Public Property RssTtl As Integer = 30
  Public Property RssImageWidth As Integer = 144
  Public Property RssImageHeight As Integer = 96
  Public Property RssImageSizeAllowOverride As Boolean = True
  Public Property RssAllowContentInFeed As Boolean = True
  Public Property RssDefaultCopyright As String = ""

  Public Property PortalTemplatesPath As String = ""
  Private Property PortalModulePath As String = ""
  Private Property PortalModuleMapPath As String = ""
  Private _portalTemplatesMapPath As String = ""
  Public ReadOnly Property PortalTemplatesMapPath As String
   Get
    Return _portalTemplatesMapPath
   End Get
  End Property
  Public ReadOnly Property ModuleId As Integer
   Get
    Return _moduleId
   End Get
  End Property
#End Region

#Region " Constructors "
  Public Sub New(moduleId As Integer)

   _moduleId = moduleId
   _allSettings = (New DotNetNuke.Entities.Modules.ModuleController).GetModuleSettings(moduleId)
   _allSettings.ReadValue("AllowWLW", AllowWLW)
   _allSettings.ReadValue("AllowMultipleCategories", AllowMultipleCategories)
   _allSettings.ReadValue("VocabularyId", VocabularyId)
   _allSettings.ReadValue("AllowAttachments", AllowAttachments)
   _allSettings.ReadValue("SummaryModel", SummaryModel)
   _allSettings.ReadValue("StyleDetectionUrl", StyleDetectionUrl)
   _allSettings.ReadValue("WLWRecentPostsMax", WLWRecentPostsMax)
   _allSettings.ReadValue("ModifyPageDetails", ModifyPageDetails)
   _allSettings.ReadValue("AutoGenerateMissingSummary", AutoGenerateMissingSummary)
   _allSettings.ReadValue("AutoGeneratedSummaryLength", AutoGeneratedSummaryLength)

   _allSettings.ReadValue("RssEmail", RssEmail)
   _allSettings.ReadValue("RssDefaultNrItems", RssDefaultNrItems)
   _allSettings.ReadValue("RssMaxNrItems", RssMaxNrItems)
   _allSettings.ReadValue("RssTtl", RssTtl)
   _allSettings.ReadValue("RssImageWidth", RssImageWidth)
   _allSettings.ReadValue("RssImageHeight", RssImageHeight)
   _allSettings.ReadValue("RssImageSizeAllowOverride", RssImageSizeAllowOverride)
   _allSettings.ReadValue("RssAllowContentInFeed", RssAllowContentInFeed)
   _allSettings.ReadValue("RssDefaultCopyright", RssDefaultCopyright)

   _PortalModulePath = DotNetNuke.Entities.Portals.PortalSettings.Current.HomeDirectory
   If Not _PortalModulePath.EndsWith("/") Then
    _PortalModulePath &= "/"
   End If
   _PortalModulePath &= String.Format("Blog/", moduleId)

   _PortalModuleMapPath = DotNetNuke.Entities.Portals.PortalSettings.Current.HomeDirectoryMapPath
   If Not _PortalModuleMapPath.EndsWith("\") Then
    _PortalModuleMapPath &= "\"
   End If
   _PortalModuleMapPath &= String.Format("Blog\", moduleId)

   _portalTemplatesMapPath = String.Format("{0}Templates\", _PortalModuleMapPath)
   If Not IO.Directory.Exists(_portalTemplatesMapPath) Then
    IO.Directory.CreateDirectory(_portalTemplatesMapPath)
   End If
   _PortalTemplatesPath = String.Format("{0}Templates/", _PortalModulePath)

  End Sub

  Public Shared Function GetModuleSettings(moduleId As Integer) As ModuleSettings
   Dim CacheKey As String = "ModuleSettings" & moduleId.ToString
   Dim settings As ModuleSettings = CType(DotNetNuke.Common.Utilities.DataCache.GetCache(CacheKey), ModuleSettings)
   If settings Is Nothing Then
    settings = New ModuleSettings(moduleId)
    DotNetNuke.Common.Utilities.DataCache.SetCache(CacheKey, settings)
   End If
   Return settings
  End Function
#End Region

#Region " Public Members "
  Public Overridable Sub UpdateSettings()

   Dim objModules As New DotNetNuke.Entities.Modules.ModuleController
   objModules.UpdateModuleSetting(_moduleId, "AllowWLW", AllowWLW.ToString)
   objModules.UpdateModuleSetting(_moduleId, "AllowMultipleCategories", AllowMultipleCategories.ToString)
   objModules.UpdateModuleSetting(_moduleId, "VocabularyId", VocabularyId.ToString)
   objModules.UpdateModuleSetting(_moduleId, "AllowAttachments", AllowAttachments.ToString)
   objModules.UpdateModuleSetting(_moduleId, "SummaryModel", CInt(SummaryModel).ToString)
   objModules.UpdateModuleSetting(_moduleId, "StyleDetectionUrl", StyleDetectionUrl)
   objModules.UpdateModuleSetting(_moduleId, "WLWRecentPostsMax", WLWRecentPostsMax.ToString)
   objModules.UpdateModuleSetting(_moduleId, "ModifyPageDetails", ModifyPageDetails.ToString)
   objModules.UpdateModuleSetting(_moduleId, "AutoGenerateMissingSummary", AutoGenerateMissingSummary.ToString)
   objModules.UpdateModuleSetting(_moduleId, "AutoGeneratedSummaryLength", AutoGeneratedSummaryLength.ToString)

   objModules.UpdateModuleSetting(_moduleId, "RssEmail", RssEmail)
   objModules.UpdateModuleSetting(_moduleId, "RssDefaultNrItems", RssDefaultNrItems.ToString)
   objModules.UpdateModuleSetting(_moduleId, "RssMaxNrItems", RssMaxNrItems.ToString)
   objModules.UpdateModuleSetting(_moduleId, "RssTtl", RssTtl.ToString)
   objModules.UpdateModuleSetting(_moduleId, "RssImageWidth", RssImageWidth.ToString)
   objModules.UpdateModuleSetting(_moduleId, "RssImageHeight", RssImageHeight.ToString)
   objModules.UpdateModuleSetting(_moduleId, "RssImageSizeAllowOverride", RssImageSizeAllowOverride.ToString)
   objModules.UpdateModuleSetting(_moduleId, "RssAllowContentInFeed", RssAllowContentInFeed.ToString)
   objModules.UpdateModuleSetting(_moduleId, "RssDefaultCopyright", RssDefaultCopyright)
   If _importedModuleId > -1 Then objModules.UpdateModuleSetting(_moduleId, "ImportedModuleID", _importedModuleId.ToString)

   Dim CacheKey As String = "ModuleSettings" & _moduleId.ToString
   DotNetNuke.Common.Utilities.DataCache.SetCache(CacheKey, Me)
  End Sub
#End Region

#Region " IPropertyAccess Implementation "
  Public Function GetProperty(strPropertyName As String, strFormat As String, formatProvider As System.Globalization.CultureInfo, AccessingUser As DotNetNuke.Entities.Users.UserInfo, AccessLevel As DotNetNuke.Services.Tokens.Scope, ByRef PropertyNotFound As Boolean) As String Implements DotNetNuke.Services.Tokens.IPropertyAccess.GetProperty
   Dim OutputFormat As String = String.Empty
   Dim portalSettings As DotNetNuke.Entities.Portals.PortalSettings = DotNetNuke.Entities.Portals.PortalController.GetCurrentPortalSettings()
   If strFormat = String.Empty Then
    OutputFormat = "D"
   Else
    OutputFormat = strFormat
   End If
   Select Case strPropertyName.ToLower
    Case "email"
     Return PropertyAccess.FormatString(Me.RssEmail, strFormat)
    Case "allowmultiplecategories"
     Return Me.AllowMultipleCategories.ToString(formatProvider)
    Case "allowattachments"
     Return Me.AllowAttachments.ToString(formatProvider)
    Case "summarymodel"
     Return CInt(SummaryModel).ToString

    Case "portaltemplatespath"
     Return PropertyAccess.FormatString(Me.PortalTemplatesPath, strFormat)
    Case "portalmodulepath"
     Return PropertyAccess.FormatString(_PortalModulePath, strFormat)
    Case "apppath"
     Return DotNetNuke.Common.ApplicationPath
    Case "imagehandlerpath"
     Return DotNetNuke.Common.ResolveUrl(glbImageHandlerPath)
    Case Else
     PropertyNotFound = True
   End Select

   Return Null.NullString
  End Function

  Public ReadOnly Property Cacheability() As DotNetNuke.Services.Tokens.CacheLevel Implements DotNetNuke.Services.Tokens.IPropertyAccess.Cacheability
   Get
    Return CacheLevel.fullyCacheable
   End Get
  End Property
#End Region

#Region " Serialization "
  Public Sub Serialize(writer As XmlWriter)
   writer.WriteStartElement("Settings")
   writer.WriteElementString("ModuleID", ModuleId.ToString)
   writer.WriteElementString("AllowWLW", AllowWLW.ToString)
   writer.WriteElementString("AllowMultipleCategories", AllowMultipleCategories.ToString)
   writer.WriteElementString("VocabularyId", VocabularyId.ToString)
   writer.WriteElementString("AllowAttachments", AllowAttachments.ToString)
   writer.WriteElementString("SummaryModel", SummaryModel.ToString)
   writer.WriteElementString("StyleDetectionUrl", StyleDetectionUrl)
   writer.WriteElementString("WLWRecentPostsMax", WLWRecentPostsMax.ToString)
   writer.WriteElementString("ModifyPageDetails", ModifyPageDetails.ToString)
   writer.WriteElementString("AutoGenerateMissingSummary", AutoGenerateMissingSummary.ToString)
   writer.WriteElementString("AutoGeneratedSummaryLength", AutoGeneratedSummaryLength.ToString)

   writer.WriteElementString("RssEmail", RssEmail)
   writer.WriteElementString("RssDefaultNrItems", RssDefaultNrItems.ToString)
   writer.WriteElementString("RssMaxNrItems", RssMaxNrItems.ToString)
   writer.WriteElementString("RssTtl", RssTtl.ToString)
   writer.WriteElementString("RssImageWidth", RssImageWidth.ToString)
   writer.WriteElementString("RssImageHeight", RssImageHeight.ToString)
   writer.WriteElementString("RssImageSizeAllowOverride", RssImageSizeAllowOverride.ToString)
   writer.WriteElementString("RssAllowContentInFeed", RssAllowContentInFeed.ToString)
   writer.WriteElementString("RssDefaultCopyright", RssDefaultCopyright)
   writer.WriteEndElement() ' settings
  End Sub

  Public Sub FromXml(xml As XmlNode)
   If xml Is Nothing Then Exit Sub
   xml.ReadValue("ModuleID", _importedModuleId)
   xml.ReadValue("AllowWLW", AllowWLW)
   xml.ReadValue("AllowMultipleCategories", AllowMultipleCategories)
   xml.ReadValue("VocabularyId", VocabularyId)
   xml.ReadValue("AllowAttachments", AllowAttachments)
   xml.ReadValue("SummaryModel", SummaryModel)
   xml.ReadValue("StyleDetectionUrl", StyleDetectionUrl)
   xml.ReadValue("WLWRecentPostsMax", WLWRecentPostsMax)
   xml.ReadValue("ModifyPageDetails", ModifyPageDetails)
   xml.ReadValue("AutoGenerateMissingSummary", AutoGenerateMissingSummary)
   xml.ReadValue("AutoGeneratedSummaryLength", AutoGeneratedSummaryLength)

   xml.ReadValue("RssEmail", RssEmail)
   xml.ReadValue("RssDefaultNrItems", RssDefaultNrItems)
   xml.ReadValue("RssMaxNrItems", RssMaxNrItems)
   xml.ReadValue("RssTtl", RssTtl)
   xml.ReadValue("RssImageWidth", RssImageWidth)
   xml.ReadValue("RssImageHeight", RssImageHeight)
   xml.ReadValue("RssImageSizeAllowOverride", RssImageSizeAllowOverride)
   xml.ReadValue("RssAllowContentInFeed", RssAllowContentInFeed)
   xml.ReadValue("RssDefaultCopyright", RssDefaultCopyright)
  End Sub
#End Region

 End Class
End Namespace

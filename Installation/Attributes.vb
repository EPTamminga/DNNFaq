Imports System
Namespace DNNtc

#Region " Attributes "

    ''' <summary>
    ''' This class is used to indicate which UserControls should be in the install package
    ''' </summary>
    Public Class ModuleControlProperties
        Inherits Attribute
        ''' <summary>
        ''' Creates a attribute with the right properties to create a control.
        ''' </summary>
        ''' <param name="Key">Key for thsi control</param>
        ''' <param name="Title">Title of this control</param>
        ''' <param name="UserControlType"></param>
        ''' <param name="HelpUrl">Fully qualified URL for Help on this module</param>
        ''' <param name="SupportsPartialRendering">True if this module supports Partial Rendering, False otherwise</param>
        Public Sub New(ByVal Key As String, ByVal Title As String, ByVal UserControlType As ControlType, ByVal HelpUrl As String, ByVal SupportsPartialRendering As Boolean)
            'Intentially left empty
        End Sub
    End Class

    ''' <summary>
    ''' Module permission attribute
    ''' </summary>
    <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True)> _
    Public Class ModulePermission
        Inherits Attribute
        ''' <summary>
        ''' Empty Constructor for Intellisense
        ''' </summary>
        ''' <param name="Code"></param>
        ''' <param name="Key"></param>
        ''' <param name="Name"></param>
        Public Sub New(ByVal Code As String, ByVal Key As String, ByVal Name As String)
            'Intentially left empty
        End Sub
    End Class

    Public Class BusinessControllerClass
        Inherits Attribute
        'Intentially left empty
    End Class

    Public Class UpgradeEventMessage
        Inherits Attribute
        Public Sub New(ByVal VersionList As String)
            'Intentially left empty
        End Sub
    End Class

    <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True)> _
    Public Class ModuleDependencies
        Inherits Attribute
        Public Sub New(ByVal Type As ModuleDependency, ByVal Value As String)
            'Intentially left empty
        End Sub
    End Class

#End Region

#Region " Enums "

    Public Enum ControlType
        SkinObject
        Anonymous
        View
        Edit
        Admin
        Host
    End Enum

    Public Enum ModuleDependency
        CoreVersion
        Package
        Permission
        Type
    End Enum

#End Region

End Namespace
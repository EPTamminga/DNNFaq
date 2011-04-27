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

    ''' <summary>
    ''' Defines the businessControllerClass
    ''' </summary>
    Public Class BusinessControllerClass
        Inherits Attribute
        'Intentially left empty
    End Class

    ''' <summary>
    ''' Defines the Upgradable interface implementations
    ''' </summary>
    Public Class UpgradeEventMessage
        Inherits Attribute
        ''' <summary>
        ''' Initializes a new instance of the <see cref="UpgradeEventMessage" /> class.
        ''' </summary>
        ''' <param name="VersionList">The version list.</param>
        Public Sub New(ByVal VersionList As String)
            'Intentially left empty
        End Sub
    End Class

    ''' <summary>
    ''' Define the Module dependencies
    ''' </summary>
    <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True)> _
    Public Class ModuleDependencies
        Inherits Attribute
        ''' <summary>
        ''' Initializes a new instance of the <see cref="ModuleDependencies" /> class.
        ''' </summary>
        ''' <param name="Type">The type.</param>
        ''' <param name="Value">The value.</param>
        Public Sub New(ByVal Type As ModuleDependency, ByVal Value As String)
            'Intentially left empty
        End Sub
    End Class

#End Region

#Region " Enums "

    ''' <summary>
    ''' Different type of controls
    ''' </summary>
    Public Enum ControlType
        ''' <summary>
        ''' This is a SkinObkect control
        ''' </summary>
        SkinObject
        ''' <summary>
        ''' This is an Anonymous control
        ''' </summary>
        Anonymous
        ''' <summary>
        ''' This is a View control
        ''' </summary>
        View
        ''' <summary>
        ''' This is an edit control
        ''' </summary>
        Edit
        ''' <summary>
        ''' This is an Admin control
        ''' </summary>
        Admin
        ''' <summary>
        ''' This is a Host Control
        ''' </summary>
        Host
    End Enum

    ''' <summary>
    ''' Dependencytpe of a module
    ''' </summary>
    Public Enum ModuleDependency
        ''' <summary>
        ''' Depends on a minimum core version
        ''' </summary>
        CoreVersion
        ''' <summary>
        ''' Depends on the installation of a packages
        ''' </summary>
        Package
        ''' <summary>
        ''' Depends on a permission
        ''' </summary>
        Permission
        ''' <summary>
        ''' Permission Type
        ''' </summary>
        Type
    End Enum

#End Region

End Namespace
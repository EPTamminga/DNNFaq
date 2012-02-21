using System;

namespace DNNtc
{
	
#region  Attributes
	
	/// <summary>
	/// This class is used to indicate which UserControls should be in the install package
	/// </summary>
	public class ModuleControlProperties : Attribute
	{
	    /// <summary>
	    /// Creates a attribute with the right properties to create a control.
	    /// </summary>
	    /// <param name="Key">Key for thsi control</param>
	    /// <param name="Title">Title of this control</param>
	    /// <param name="UserControlType"></param>
	    /// <param name="HelpUrl">Fully qualified URL for Help on this module</param>
	    /// <param name="supportsPartialRendering"> </param>
	    /// <param name="SupportsPartialRendering">True if this module supports Partial Rendering, False otherwise</param>
	    public ModuleControlProperties(string Key, string Title, ControlType UserControlType, string HelpUrl, bool supportsPartialRendering, bool SupportsPartialRendering)
		{
			//Intentially left empty
		}
	}
	
	/// <summary>
	/// Module permission attribute
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]public class ModulePermission : Attribute
	{
		
		/// <summary>
		/// Empty Constructor for Intellisense
		/// </summary>
		/// <param name="Code"></param>
		/// <param name="Key"></param>
		/// <param name="Name"></param>
		public ModulePermission(string Code, string Key, string Name)
		{
			//Intentially left empty
		}
	}
	
	/// <summary>
	/// Defines the businessControllerClass
	/// </summary>
	public class BusinessControllerClass : Attribute
	{
		
		//Intentially left empty
	}
	
	/// <summary>
	/// Defines the Upgradable interface implementations
	/// </summary>
	public class UpgradeEventMessage : Attribute
	{
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UpgradeEventMessage" /> class.
		/// </summary>
		/// <param name="VersionList">The version list.</param>
		public UpgradeEventMessage(string VersionList)
		{
			//Intentially left empty
		}
	}
	
	/// <summary>
	/// Define the Module dependencies
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]public class ModuleDependencies : Attribute
	{
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ModuleDependencies" /> class.
		/// </summary>
		/// <param name="Type">The type.</param>
		/// <param name="Value">The value.</param>
		public ModuleDependencies(ModuleDependency Type, string Value)
		{
			//Intentially left empty
		}
	}
	
#endregion
	
#region  Enums

	/// <summary>
	/// Enum for type of component used.
	/// </summary>
	public enum ComponentType
	{
		Script,
		Assembly,
		Module
	}
	
	/// <summary>
	/// Different type of controls
	/// </summary>
	public enum ControlType
	{
		/// <summary>
		/// This is a SkinObkect control
		/// </summary>
		SkinObject,
		/// <summary>
		/// This is an Anonymous control
		/// </summary>
		Anonymous,
		/// <summary>
		/// This is a View control
		/// </summary>
		View,
		/// <summary>
		/// This is an edit control
		/// </summary>
		Edit,
		/// <summary>
		/// This is an Admin control
		/// </summary>
		Admin,
		/// <summary>
		/// This is a Host Control
		/// </summary>
		Host
	}
	
	/// <summary>
	/// Dependencytpe of a module
	/// </summary>
	public enum ModuleDependency
	{
		/// <summary>
		/// Depends on a minimum core version
		/// </summary>
		CoreVersion,
		/// <summary>
		/// Depends on the installation of a packages
		/// </summary>
		Package,
		/// <summary>
		/// Depends on a permission
		/// </summary>
		Permission,
		/// <summary>
		/// Permission Type
		/// </summary>
		Type
	}
	
#endregion
	
}

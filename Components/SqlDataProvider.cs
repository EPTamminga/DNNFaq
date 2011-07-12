//
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2011
// by DotNetNuke Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;

namespace DotNetNuke.Modules.FAQs
{
	
	public class SqlDataProvider : DataProvider
	{

		#region Private Members

        private const string ProviderType = "data";

        private readonly string _connectionString;
        private readonly string _databaseOwner;
        private readonly string _objectQualifier;
        private readonly ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
        private readonly string _providerPath;
		
		#endregion
		
		#region Constructors
		
		public SqlDataProvider()
		{
			
			// Read the configuration specific information for this provider
            Provider objProvider = (Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];
			
			// This code handles getting the connection string from either the connectionString / appsetting section and uses the connectionstring section by default if it exists.
			// Get Connection string from web.config
			_connectionString = Config.GetConnectionString();
			
			// If above funtion does not return anything then connectionString must be set in the dataprovider section.
			if (_connectionString == "")
			{
				// Use connection string specified in provider
				_connectionString = (string) (objProvider.Attributes["connectionString"]);
			}
			
			_providerPath = (string) (objProvider.Attributes["providerPath"]);
			
			_objectQualifier = (string) (objProvider.Attributes["objectQualifier"]);
			if (_objectQualifier != "" && _objectQualifier.EndsWith("_") == false)
			{
				_objectQualifier += "_";
			}
			
			_databaseOwner = (string) (objProvider.Attributes["databaseOwner"]);
			if (_databaseOwner != "" && _databaseOwner.EndsWith(".") == false)
			{
				_databaseOwner += ".";
			}
		}
		
		#endregion
		
		#region Properties
		
		public string ConnectionString
		{
			get
			{
				return _connectionString;
			}
		}
		
		public string ProviderPath
		{
			get
			{
				return _providerPath;
			}
		}
		
		public string ObjectQualifier
		{
			get
			{
				return _objectQualifier;
			}
		}
		
		public string DatabaseOwner
		{
			get
			{
				return _databaseOwner;
			}
		}
		
		#endregion
		
		#region FAQ Methods
		public override IDataReader GetFAQ(int faqId, int moduleId)
		{
			return ((IDataReader) (SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQGet", faqId, moduleId)));
		}
		
		public override int AddFAQ(int moduleId, int categoryId, string question, string answer, string createdByUser, DateTime dateAdded, DateTime dateModified, int viewCount)
		{
			return System.Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQAdd", moduleId, categoryId, question, answer, createdByUser, dateAdded, dateModified, viewCount));
		}
		
		public override void UpdateFAQ(int faqId, int moduleId, int categoryId, string question, string answer, string createdByUser, DateTime dateModified)
		{
			SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQUpdate", faqId, moduleId, categoryId, question, answer, createdByUser, dateModified);
		}
		
		public override void DeleteFAQ(int faqId, int moduleId)
		{
			SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQDelete", faqId, moduleId);
		}
		
		public override IDataReader SearchFAQList(int moduleId, int orderBy)
		{
			return ((IDataReader) (SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQSearch", moduleId, orderBy)));
		}
		
		#endregion
		
		#region Category Methods

		public override IDataReader GetCategory(int faqCategoryId, int moduleId)
		{
			return ((IDataReader) (SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQCategoryGet", faqCategoryId, moduleId)));
		}
		
		public override IDataReader ListCategory(int moduleId)
		{
			return ((IDataReader) (SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQCategoryList", moduleId)));
		}
		
		public override int AddCategory(int moduleId, string faqCategoryName, string faqCategoryDescription)
		{
			return System.Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQCategoryAdd", moduleId, faqCategoryName, faqCategoryDescription));
		}
		
		public override void UpdateCategory(int faqCategoryId, int moduleId, string faqCategoryName, string faqCategoryDescription)
		{
			SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQCategoryUpdate", faqCategoryId, moduleId, faqCategoryName, faqCategoryDescription);
		}
		
		public override void DeleteCategory(int faqCategoryId)
		{
			SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQCategoryDelete", faqCategoryId);
		}
		
		public override void IncrementViewCount(int faqId)
		{
			SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner + ObjectQualifier + "FAQIncrementViewCount", faqId);
		}
		
		#endregion
		
	}
	
}

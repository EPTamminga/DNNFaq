using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Services.Tokens;

namespace DotNetNuke.Modules.FAQs
{
	public class FAQsTokenReplace:TokenReplace
	{
		public FAQsTokenReplace (): base(Scope.DefaultSettings)
		{
			UseObjectLessExpression = true;
			PropertySource[ObjectLessToken] = new FAQsInfo();
		}

		public FAQsTokenReplace(FAQsInfo faqs) : base(Scope.DefaultSettings)
		{
			UseObjectLessExpression = true;
			PropertySource[ObjectLessToken] = faqs;
			PropertySource["faq"] = faqs;
		}

		public string ReplaceFAQsTokens(string strSourceText)
		{
			return base.ReplaceTokens(strSourceText);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlSoundConverter
{
	public static class NamingSchemeBlacklists
	{
		public static string IllegalFilepathCharacters = "<>:?*\"|/\\\t";

		public static string scrubString(string textIn, string blacklistedChars)
		{
			string result = "";

			foreach (char character in textIn)
			{
				if (!blacklistedChars.Contains(character))
				{
					result += character;
				}
			}

			return result;
		}
	}


	public class NamingSchemeWildcardEntry
	{
		public string wildcardText = null;
		public Func<TreeNode, string> resultMethod = null;

		public NamingSchemeWildcardEntry(string wildcardTextIn = null, Func<TreeNode, string> resultMethodIn = null)
		{
			wildcardText = wildcardTextIn;
			resultMethod = resultMethodIn;
		}
	}

	public class NamingSchemeStruct
	{
		public string baseString = null;
		public string blacklistedChars = "";
		public Dictionary<string, NamingSchemeWildcardEntry> wildCards = null;

		public NamingSchemeStruct(string baseStringIn = "")
		{
			baseString = baseStringIn;
			wildCards = new Dictionary<string, NamingSchemeWildcardEntry>();
		}

		public string getName(TreeNode nodeIn)
		{
			string result = "";
			string bufferString = baseString;

			foreach (KeyValuePair<string, NamingSchemeWildcardEntry> wildCard in wildCards)
			{
				if (!String.IsNullOrEmpty(wildCard.Key))
				{
					bufferString = bufferString.Replace(wildCard.Value.wildcardText, wildCard.Value.resultMethod.Invoke(nodeIn));
				}
			}

			if (blacklistedChars.Length > 0)
			{
				result = NamingSchemeBlacklists.scrubString(bufferString, blacklistedChars);
			}
			else
			{
				result = bufferString;
			}

			return result;
		}
	}
}

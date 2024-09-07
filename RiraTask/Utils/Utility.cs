using Azure.Core;

namespace RiraTask.Utils
{
	public static class Utility
	{
		public static DateTime ConvertStrToDate(this string str)
		{
			return new DateTime(int.Parse(str.Substring(0, 4)), int.Parse(str.Substring(5, 2)), int.Parse(str.Substring(8, 2)));
		}
	}
}

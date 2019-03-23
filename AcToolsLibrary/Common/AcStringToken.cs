/********************************************************
 *	Author: Andrew Deren
 *	Date: July, 2004
 *	http://www.adersoftware.com
 * 
 *	StringTokenizer class. You can use this class in any way you want
 *  as long as this header remains in this file.
 * 
 **********************************************************/

using System;

namespace AcToolsLibrary.Common
{
	public enum AcStringTokenKind
	{
		Unknown,
		Word,
		Number,
		QuotedString,
		WhiteSpace,
		Symbol,
		EOL,
		EOF
	}

	public class AcStringToken
	{
		private Int32 _line;
		private Int32 _column;
		private String _value;
		private AcStringTokenKind _kind;

		public AcStringToken(AcStringTokenKind kind, String value, Int32 line, Int32 column)
		{
			_kind = kind;
			_value = value;
			_line = line;
			_column = column;
		}

		public int Column
		{
			get { return _column; }
		}

		public AcStringTokenKind Kind
		{
			get { return _kind; }
		}

		public int Line
		{
			get { return _line; }
		}

		public string Value
		{
			get { return _value; }
		}
	}

}

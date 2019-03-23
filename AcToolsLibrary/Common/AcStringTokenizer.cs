/********************************************************8
 *	Author: Andrew Deren
 *	Date: July, 2004
 *	http://www.adersoftware.com
 * 
 *	StringTokenizer class. You can use this class in any way you want
 *  as long as this header remains in this file.
 * 
 **********************************************************/
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace AcToolsLibrary.Common
{
	/// <summary>
	/// StringTokenizer tokenized string (or stream) into tokens.
	/// </summary>
	public class AcStringTokenizer
	{
		private const char EOF = (char)0;

		private Int32 _line;
		private Int32 _column;
		private Int32 _pos;	// position within data

		private String _data;

		private Boolean _ignoreWhiteSpace;
		private List<Char> _symbolChars;

		private Int32 _saveLine;
		private Int32 _saveCol;
		private Int32 _savePos;

		public AcStringTokenizer(TextReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}

			_data = reader.ReadToEnd();

			Reset();
		}

		public AcStringTokenizer(String data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}

			_data = data;

			Reset();
		}

		/// <summary>
		/// get a list of all the token values for the string input
		/// </summary>
		/// <returns></returns>
		public List<String> GetAllTokenValues()
		{
			//Create a new token value list
			List<String> tokenList = new List<String>();

			//Save the old position
			Int32 oldLine, oldColumn, oldPos;
			oldLine = _line;
			oldColumn = _column;
			oldPos = _pos;

			//Set position to start
			_line = 1;
			_column = 1;
			_pos = 0;
			//Get all the tokens
			AcStringToken token;
			do
			{
				token = Next();
				tokenList.Add(token.Value);
			} while (token.Kind != AcStringTokenKind.EOF);

			//Restore previous position
			_line = oldLine;
			_column = oldColumn;
			_pos = oldPos;

			//return token values
			return tokenList;
		}

		/// <summary>
		/// get a list of all the tokens for the string input
		/// </summary>
		/// <returns></returns>
		public List<AcStringToken> GetAllTokens()
		{
			//Create a new token list
			List<AcStringToken> tokenList = new List<AcStringToken>();

			//Save the old position
			Int32 oldLine, oldColumn, oldPos;
			oldLine = _line;
			oldColumn = _column;
			oldPos = _pos;

			//Set position to start
			_line = 1;
			_column = 1;
			_pos = 0;
			//Get all the tokens
			AcStringToken token;
			do
			{
				token = Next();
				tokenList.Add(token);
			} while (token.Kind != AcStringTokenKind.EOF);

			//Restore previous position
			_line = oldLine;
			_column = oldColumn;
			_pos = oldPos;

			//return tokens
			return tokenList;
		}

		/// <summary>
		/// gets or sets which characters are part of AcTokenKind.Symbol
		/// </summary>
		public List<char> SymbolChars
		{
			get { return _symbolChars; }
			set { _symbolChars = value; }
		}

		/// <summary>
		/// if set to true, white space characters will be ignored,
		/// but EOL and whitespace inside of string will still be tokenized
		/// </summary>
		public Boolean IgnoreWhiteSpace
		{
			get { return _ignoreWhiteSpace; }
			set { _ignoreWhiteSpace = value; }
		}

		private void Reset()
		{
			_ignoreWhiteSpace = false;
			_symbolChars = new List<Char>() { '=', '+', '-', '/', ',', '.', '*', '~', '!', '@', '#', '$', '%', '^', '&', '(', ')', '{', '}', '[', ']', ':', ';', '<', '>', '?', '|', '\\' };

			_line = 1;
			_column = 1;
			_pos = 0;
		}

		protected Char LA(Int32 count)
		{
			if (_pos + count >= _data.Length)
			{
				return EOF;
			}
			else
			{
				return _data[_pos + count];
			}
		}

		protected Char Consume()
		{
			Char ret = _data[_pos];
			_pos++;
			_column++;

			return ret;
		}

		protected AcStringToken CreateToken(AcStringTokenKind kind, String value)
		{
			return new AcStringToken(kind, value, _line, _column);
		}

		protected AcStringToken CreateToken(AcStringTokenKind kind)
		{
			String tokenData = _data.Substring(_savePos, _pos - _savePos);
			return new AcStringToken(kind, tokenData, _saveLine, _saveCol);
		}

		public AcStringToken Next()
		{
			while (true)
			{
				Char ch = LA(0);
				switch (ch)
				{
					case EOF:
						return CreateToken(AcStringTokenKind.EOF, String.Empty);
					case ' ':
					case '\t':
						if (_ignoreWhiteSpace)
						{
							Consume();
							continue;
						}
						else
						{
							return ReadWhitespace();
						}
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						return ReadNumber();
					case '\r':
						StartRead();
						Consume();
						if (LA(0) == '\n')
						{
							Consume();	// on DOS/Windows we have \r\n for new line
						}

						_line++;
						_column = 1;

						return CreateToken(AcStringTokenKind.EOL);
					case '\n':
						StartRead();
						Consume();
						_line++;
						_column = 1;

						return CreateToken(AcStringTokenKind.EOL);
					case '"':
						return ReadString();
					default:
						if (Char.IsLetter(ch) || ch == '_')
						{
							return ReadWord();
						}
						else if (IsSymbol(ch))
						{
							StartRead();
							Consume();
							return CreateToken(AcStringTokenKind.Symbol);
						}
						else
						{
							StartRead();
							Consume();
							return CreateToken(AcStringTokenKind.Unknown);
						}
				}
			}
		}

		/// <summary>
		/// save read point positions so that CreateToken can use those
		/// </summary>
		private void StartRead()
		{
			_saveLine = _line;
			_saveCol = _column;
			_savePos = _pos;
		}

		/// <summary>
		/// reads all whitespace characters (does not include newline)
		/// </summary>
		/// <returns></returns>
		protected AcStringToken ReadWhitespace()
		{
			StartRead();
			Consume(); // consume the looked-ahead whitespace char
			while (true)
			{
				Char ch = LA(0);
				if (ch == '\t' || ch == ' ')
				{
					Consume();
				}
				else
				{
					break;
				}
			}
			return CreateToken(AcStringTokenKind.WhiteSpace);
		}

		/// <summary>
		/// reads number. Number is: DIGIT+ ("." DIGIT*)?
		/// </summary>
		/// <returns></returns>
		protected AcStringToken ReadNumber()
		{
			Boolean hadDot = false;
			StartRead();
			Consume(); // read first digit

			while (true)
			{
				Char ch = LA(0);
				if (Char.IsDigit(ch))
				{
					Consume();
				}
				else if (ch == '.' && !hadDot)
				{
					hadDot = true;
					Consume();
				}
				else
				{
					break;
				}
			}
			return CreateToken(AcStringTokenKind.Number);
		}

		/// <summary>
		/// reads word. Word contains any alpha character or _
		/// </summary>
		protected AcStringToken ReadWord()
		{
			StartRead();
			Consume(); // consume first character of the word

			while (true)
			{
				Char ch = LA(0);
				if (Char.IsLetter(ch) || ch == '_')
				{
					Consume();
				}
				else
				{
					break;
				}
			}
			return CreateToken(AcStringTokenKind.Word);
		}

		/// <summary>
		/// reads all characters until next " is found.
		/// If "" (2 quotes) are found, then they are consumed as
		/// part of the string
		/// </summary>
		/// <returns></returns>
		protected AcStringToken ReadString()
		{
			StartRead();
			Consume(); // read "

			while (true)
			{
				Char ch = LA(0);
				if (ch == EOF)
				{
					break;
				}
				else if (ch == '\r')	// handle CR in strings
				{
					Consume();
					if (LA(0) == '\n')	// for DOS & windows
					{
						Consume();
					}

					_line++;
					_column = 1;
				}
				else if (ch == '\n')	// new line in quoted string
				{
					Consume();

					_line++;
					_column = 1;
				}
				else if (ch == '"')
				{
					Consume();
					if (LA(0) != '"')
					{
						break;	// done reading, and this quotes does not have escape character
					}
					else
						Consume(); // consume second ", because first was just an escape
				}
				else
					Consume();
			}
			return CreateToken(AcStringTokenKind.QuotedString);
		}

		/// <summary>
		/// checks whether c is a symbol character.
		/// </summary>
		protected Boolean IsSymbol(Char c)
		{
			foreach (Char symbolChar in _symbolChars)
			{
				if (symbolChar == c)
				{
					return true;
				}
			}
			return false;
		}
	}
}

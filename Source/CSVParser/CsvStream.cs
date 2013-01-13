using System.Collections;
using System.IO;
using System.Text;

namespace CsvFileParser
{
	//The class reads the CSV source in one character at a time and
	//return meaningful chunks of decoded data, namely data items and rows.

	public class CsvStream
	{
		#region Constants

		private const int DEFAULT_BUFFER = 4096;
		private const char CSV_SEPARATOR = ';';
		private const char NEW_LINE = '\x0A';
		private const char CARRIAGE_RETURN = '\x0D';
		private const char WHITE_SPACE = ' ';
		private const char QUOTE = '"';
		private const char PERCENT = '%';
		private const char NULL_SYMBOL = '\0';

		#endregion

		#region Private Fields

		private TextReader _stream;
		private bool _eos;
		private bool _eol;

		private char[] _buffer = new char[DEFAULT_BUFFER];
		private int _position;
		private int _length;

		private bool _quoted;
		private bool _predata = true;
		private bool _postdata;

		private char _symbol;

		#endregion

		#region Constructors

		public CsvStream(TextReader stream)
		{
			_stream = stream;
		}

		#endregion

		#region Private Methods

		private string GetNextItem()
		{
			if (_eol)
			{
				// Previous item was last in line, start new line
				_eol = false;
				return null;
			}

			StringBuilder item = new StringBuilder();

			while (true)
			{
				_symbol = GetNextChar(true);

				if (_eos)
				{
					if (item.Length > 0)
					{
						return item.ToString();
					}

					return null;
				}

				#region Symbols Check

				if ((_postdata || !_quoted) && _symbol == CSV_SEPARATOR)
				{
					// End of item, return
					return item.ToString();
				}

				if ((_predata || _postdata || !_quoted))
				{
					if ((_symbol == NEW_LINE || _symbol == CARRIAGE_RETURN))
					{
						// We are at the end of the line, eat newline characters and exit
						_eol = true;

						if (_symbol == CARRIAGE_RETURN && GetNextChar(false) == NEW_LINE)
						{
							// New line sequence is 0D0A
							GetNextChar(true);
						}

						return item.ToString();
					}
				}

				if (_predata && _symbol == WHITE_SPACE)
				{
					// Whitespace proceeding data, discard
					continue;
				}

				if (_predata && _symbol == QUOTE)
				{
					// Quoted data is starting
					_quoted = true;
					_predata = false;
					continue;
				}

				if (_predata)
				{
					// Data is starting without quotes
					_predata = false;
					item.Append(_symbol);
					continue;
				}

				if (_symbol == QUOTE && _quoted)
				{
					if (GetNextChar(false) == QUOTE)
					{
						// Double quotes within quoted string means add a quote     
						item.Append(GetNextChar(true));
					}

					else
					{
						// End-quote reached
						_postdata = true;
						continue;
					}
				}

				#endregion

				// All cases covered, character must be data
				if (_symbol == PERCENT)
				{
					_symbol = NULL_SYMBOL;
				}

				item.Append(_symbol);
			}
		}

		private char GetNextChar(bool eat)
		{
			if (_position >= _length)
			{
				_length = _stream.ReadBlock(_buffer, 0, _buffer.Length);

				if (_length == 0)
				{
					_eos = true;
					return NULL_SYMBOL;
				}
				_position = 0;
			}

			if (eat)
			{
				return _buffer[_position++];
			}

			return _buffer[_position];
		}

		#endregion

		#region Public Methods

		public string[] GetNextRow()
		{
			ArrayList row = new ArrayList();

			while (true)
			{
				string item = GetNextItem();

				if (item == null)
				{
					if (row.Count == 0)
					{
						return null;
					}

					return (string[])row.ToArray(typeof(string));
				}

				row.Add(item);
			}
		}
		#endregion
	}
}


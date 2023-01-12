using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Parser.DataModel
{
    [Serializable]
    public struct CellIndex
    {
        public int Col { get; set; }
        public int Row { get; set; }

        public override int GetHashCode()
        {
            return Col ^ Row;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CellIndex))
                return false;
            var other = (CellIndex)obj;

            return other.Col == Col && other.Row == Row;
        }

        public override string ToString()
        {
            return string.Format("R{0}C{1}", Row, Col);
        }

        public static bool TryParse(string s, out CellIndex cellIndex)
        {
            var m = Regex.Match(s, @"^R(\d+)C(\d+)$");
            if (m.Success)
            {
                cellIndex = new CellIndex() {Col = int.Parse(m.Groups[2].Value), Row = int.Parse(m.Groups[1].Value)};
                return true;
            }

            cellIndex = default(CellIndex);

            return false;
        }
    }
}

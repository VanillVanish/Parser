using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Parser.DataModel
{
    [Serializable]
    public class DataSheet
    {
        public Dictionary<CellIndex, Cell> Cells { get; private set; }

        public DataSheet()
        {
            Cells = new Dictionary<CellIndex, Cell>();
        }

        public void Calculate()
        {
            CalcDependents();
            var list = new List<KeyValuePair<CellIndex, Cell>>(Cells);
            list.Sort
                ((p1, p2) =>
                     {
                         if (p1.Value.Dependents.Contains(p2.Key)) return 1;
                         if (p2.Value.Dependents.Contains(p1.Key)) return -1;

                         return 0;
                     }
                );
            var parser = new ParserNS.DataSheetParser(this);
            foreach(var cell in list)
            {
                var obj = parser.Calc(cell.Value.Expression);
                if (!double.TryParse(obj.ToString(), out cell.Value.CachedValue))
                    cell.Value.CachedValue = 0;
            }
            
        }

        private void CalcDependents()
        {
            var regex = new Regex(@"R(\d+)C(\d+)");
            foreach (var cell in Cells.Values)
            {
                cell.Dependents.Clear();
                foreach(Match m in regex.Matches(cell.Expression))
                    cell.Dependents.Add(new CellIndex{Col = int.Parse(m.Groups[2].Value), Row = int.Parse(m.Groups[1].Value)});
            }
        }
    }
}

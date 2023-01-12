using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Parser.DataModel;

namespace ParserNS
{
    public class DataSheetParser : Parser
    {
        private DataSheet sheet;

        public DataSheetParser(DataSheet sheet)
        {
            this.sheet = sheet;
        }

        protected override void PushConst(string lex, Stack arguments)
        {
            CellIndex i;
            if(CellIndex.TryParse(lex, out i))
            {
                Cell cell;
                if (sheet.Cells.TryGetValue(i, out cell))
                {
                    arguments.Push(cell.CachedValue);
                    return;
                }
            }

            base.PushConst(lex, arguments);
        }
    }
}

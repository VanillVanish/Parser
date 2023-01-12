using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Parser.DataModel
{
    [Serializable]
    public class Cell
    {
        public string Expression;
        [NonSerialized]
        public double CachedValue = 0;
        [NonSerialized]
        public HashSet<CellIndex> Dependents = new HashSet<CellIndex>();

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Dependents = new HashSet<CellIndex>();
        }
    }
}
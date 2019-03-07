using System.Collections.Generic;

namespace ScriptCycle.Prototypes.Models {

    public class GPI {
        public string name { get; set; }
        public string gpi_name { get; set; }
        public string level { get; set; }
        public int size { get; set; }
    }

    public class GPITreeItem {
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public List<GPITreeItem> children { get; set; } = new List<GPITreeItem>();
    }
}
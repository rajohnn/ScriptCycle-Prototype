using System.Data.Entity;

namespace ScriptCycle.Prototypes.Data {

    public class ScriptCycleContext : DbContext {
        public ScriptCycleContext() : base("name=SCPrototype") {
            
        }
    }
}
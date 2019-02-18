using ScriptCycle.Prototypes.Data;

namespace ScriptCycle.Prototypes.Repo {

    public class RepoBase {
        protected ScriptCycleContext _ctx;

        public RepoBase(ScriptCycleContext ctx) {
            _ctx = ctx;
        }
    }
}
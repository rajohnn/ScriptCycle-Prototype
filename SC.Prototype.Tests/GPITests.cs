using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ScriptCycle.Prototypes.Data;
using ScriptCycle.Prototypes.Models;
using ScriptCycle.Prototypes.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SC.Prototype.Tests {

    [TestClass]
    public class GPITests {

        [TestMethod]
        public void RetrieveRawGPI_Test() {
            var ctx = new ScriptCycleContext();
            var repo = new DrugRepo(ctx);
            var results = repo.GetGPI();

            Assert.IsTrue(results.Count > 0);
            Console.WriteLine("GPI Result count: " + results.Count);
        }

        [TestMethod]
        public void ConvertRawGPItoTree_Test() {
            string filter = "35";
            bool hasError = false;
            var ctx = new ScriptCycleContext();
            var repo = new DrugRepo(ctx);
            var results = repo.GetGPI(filter);

            var errors = new List<string>();
            var list = new List<GPITreeItem>();

            var startNode = results.SingleOrDefault(r => r.name == filter);
           

            var gpiTreeItem = new GPITreeItem {
                name = startNode.name,
                description = startNode.gpi_name,
                size = 0
            };
            list.Add(gpiTreeItem);

            for (int i = 4; i < 16; i = i + 2) {
                string level = i.ToString();
                if (i < 10)
                    level = string.Format("0{0}", i);

                var gpis = results.Where(g => g.level == level).ToList();

                gpis.ForEach(gpi => {
                    if (i == 2)
                        list.Add(new GPITreeItem { name = gpi.name, description = gpi.gpi_name });
                    else {
                        string name = gpi.name.Substring(0, gpi.name.Length - 2);
                        foreach (var node in list) {
                            var found = Find(node, name);
                            if (found != null) {
                                found.children.Add(new GPITreeItem { name = gpi.name, description = gpi.gpi_name });
                            }
                            else {
                                errors.Add("Cound not find node for " + name + ".");
                                hasError = true;
                            }
                        }
                    }
                });
            }

            if (errors.Count > 0) {
                Console.WriteLine("Errors Detected:");
                errors.ForEach(e => { Console.WriteLine(e); });
            }
            var json = JsonConvert.SerializeObject(gpiTreeItem);
            File.WriteAllText(@"c:\temp\gpi_" + filter + ".json", json);

            Assert.IsTrue(hasError == false);
        }

        private GPITreeItem Find(GPITreeItem item, string name) {
            if (item == null) return null;
            if (item.name == name)
                return item;

            foreach (var child in item.children) {
                var found = Find(child, name);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}
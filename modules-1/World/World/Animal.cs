using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    internal class Animal
    {
        public string Name { get; set; }

        public double Age { get; set; }

        public string Species { get; set; }

        public string OriginalHabitat { get; set; }

        public void SetAnimal(string name, double age, string species, string originalHabitat)
        {
            OriginalHabitat = originalHabitat.ToLower();
            Name = name.ToLower();
            Age = age;
            Species = species.ToLower();
        }
    }
}

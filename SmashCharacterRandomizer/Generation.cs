using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashCharacterRandomizer
{
    public class Generation
    {
        public string choice;
        public List<string> names;
        public int number;
        public List<string> characters;

        public Generation()
        {
            choice = null;
            names = null;
            number = 0;
            characters = null;
        }
        public Generation(string choice, List<string> names, int number, List<string> characters)
        {
            this.choice = choice;
            this.names = names;
            this.number = number;
            this.characters = characters;
        }
    }
}

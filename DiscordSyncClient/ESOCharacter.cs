using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordSyncClient
{
    public class ESOCharacter
    {
        public string Name { get; set; }
        public bool IsChampion { get; set; }
        public int Level { get; set; }
        public int Gender { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int Alliance { get; set; }

        public ESOCharacter(string name)
        {
            this.Name = name;
        }
    }
}

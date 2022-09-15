using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace R4iny.Desk.Library.Data
{
    public class Database : JsonSerializable
    {
        [JsonIgnore]
        public string DatabasePath { get; set; }
        public string RootPath { get; set; }

        public List<Entry> Entries { get; set; } = new List<Entry>();

        public int Reset()
        {
            this.RootPath = "";
            this.Entries.Clear();

            return this.Save();
        }

        public int Save()
        {
            string serialized = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(this.DatabasePath, serialized);

            return 0;
        }

        public int AddEntry(Entry entry)
        {
            this.Entries.Add(entry);

            return 0;
        }
    }
}

using Newtonsoft.Json;

namespace R4iny.Desk.Library.Data
{
    public class JsonSerializable
    {
        public new string ToString() => this.ToString(false);
        public string ToString(bool isIndented) => JsonConvert.SerializeObject(this, isIndented ? Formatting.Indented : Formatting.None);
    }
}

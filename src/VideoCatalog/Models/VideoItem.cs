using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCatalog.Models
{
    public class VideoItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("bulletText")]
        public string TextInfo { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("runningTime")]
        public double RunningTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("artUrl")]
        public string ArtUrl { get; set; }

        [JsonProperty("related")]
        public IEnumerable<string> RelatedIds { get; set; }

        public string RunTimeSpan
        {
            get
            {
                return TimeSpan.FromMilliseconds(RunningTime).ToString("hh\\:mm\\:ss");
            }
        }
    }
}

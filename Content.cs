using Newtonsoft.Json;

namespace imageAndVisionChatGpt;


public class Content
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public string? Text { get; set; }
    [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
    public ImageUrl? ImageUrl { get; set; }
}

public class ImageUrl
{
    [JsonProperty("url")]
    public string Url { get; set; }
}
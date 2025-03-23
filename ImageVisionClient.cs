using System.Reflection;
using Newtonsoft.Json;
using RestSharp;

namespace imageAndVisionChatGpt;

public class ImageVisionClient
{
    private readonly string _apiKey;
public ImageVisionClient(string apiKey){
_apiKey=apiKey;

}

public async Task<string> GetImageVision(string prompt)
{
      var client = new RestClient("https://api.openai.com/v1/chat");
  var request = new RestRequest("completions", Method.Post);
  request.AddHeader("Authorization", $"Bearer {_apiKey}");
  request.AddHeader("Content-Type", "application/json");

        string imageUrl = "https://images.pexels.com/photos/1108099/pexels-photo-1108099.jpeg";// Environment.CurrentDirectory+"\\image\\dogTwin.jpg";
    var contentList = new List<Content>
{
    new Content { Type = "text", Text = prompt },
    new Content
    {
        Type = "image_url",
        ImageUrl = new ImageUrl
        {
            Url = imageUrl
        }
    }
};

var message = new List<Message>{new Message{
    role = "user",
    content = contentList
}
};

var requestBody = new ImageVisionModel{
    model = "gpt-4o-mini",
    messages =message
};

string formattedJson = JsonConvert.SerializeObject(requestBody, Formatting.Indented);

 request.AddParameter("application/json", JsonConvert.SerializeObject(requestBody), ParameterType.RequestBody);
  var response = await client.ExecuteAsync(request);
 if (response.IsSuccessful)
 {
     dynamic completion = JsonConvert.DeserializeObject(response.Content);
     var responseString = (string)completion.choices[0].message.content;
     return responseString;
 }
 else
 {
     throw new Exception("Unable to get response from open AI.");
 }
}

}

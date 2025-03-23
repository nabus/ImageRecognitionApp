using imageAndVisionChatGpt;
var imageVisionApi = new ImageVisionClient("Open-AI-API-Key");//Your api key goes here.
Console.WriteLine("Go ahead and ask to Vision API:");
string prompt = Console.ReadLine();//your input

string response = await imageVisionApi.GetImageVision(prompt);
Console.WriteLine("Vision API Says: ");//response from chat gpt
Console.WriteLine(response);
Console.ReadLine();
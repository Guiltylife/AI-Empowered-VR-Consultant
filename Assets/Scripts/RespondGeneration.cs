using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class RespondGeneration : MonoBehaviour
{
    public string inputSentences;
    public string outputSentences;
    [SerializeField]
    SceneController sceneController;

    private OpenAIAPI api;
    private List<ChatMessage> messages;

    // Start is called before the first frame update
    void Start()
    {
        api = new OpenAIAPI("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");
        StartConversation();
    }

    private void StartConversation()
    {
        messages = new List<ChatMessage> {
            new ChatMessage(ChatMessageRole.System, @"
You are a professional counsellor who relieves anxiety for users.
Step1: Respond to the user's input.
Step2: Select the most suitable time for the counselling among the three times of the day: ""morning"", ""dusk"" and ""night"" according to the content of the response.
Step3: Choose the most suitable emoticon for you among three emoticons: ""smile"", ""doubt"" and ""sadness"" according to the content of the response.
Please reply in JSON format, with the result of the step1 in the ""respond"" field, the result of the step2 in the ""time"" field, the result of the step3 in the ""expression"" field.
Example: {""respond"": ""You have taken the very positive step of seeking help and expressing your feelings. Anxiety is an emotion that many people experience, so you are not alone. There are ways we can try to ease your anxiety."" , ""time"": ""early morning"", ""expression"": ""smile""}")
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (inputSentences != "")
        {
            GetResponse(inputSentences);
            inputSentences = "";
        }
    }

    private async void GetResponse(string message)
    {
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = message;
        if (userMessage.Content.Length > 100)
        {
            // Limit response to 100 characters
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        messages.Add(userMessage);

        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPT4Turbo,
            Temperature = 0.1,
            MaxTokens = 4096,
            Messages = messages
        });

        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;

        messages.Add(responseMessage);

        Debug.Log("Last massage: " + responseMessage.Content);
        JObject jo = (JObject)JsonConvert.DeserializeObject(responseMessage.Content);
        Debug.Log("respond: " + jo["respond"].ToString());
        Debug.Log("time: " + jo["time"].ToString());
        Debug.Log("expression: " + jo["expression"].ToString());
        outputSentences = jo["respond"].ToString();
        sceneController.Notify("sky", jo["time"].ToString());
    }
}

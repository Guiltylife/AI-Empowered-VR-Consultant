using System.IO;
using HuggingFace.API;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour
{
    [SerializeField] RespondGeneration respondGeneration;
    [SerializeField] CharacterController characterController;
    [SerializeField] UIController uiController;

    private AudioClip clip;
    private byte[] bytes;
    private bool recording;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (recording && Microphone.GetPosition(null) >= clip.samples)
        {
            StopRecording();
        }
    }

    public void StartRecording()
    {
        clip = Microphone.Start(null, false, 20, 44100);
        recording = true;
    }

    public void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        Debug.Log(position);

        if (position > 44100 * 1)
        {
            var samples = new float[position * clip.channels];
            clip.GetData(samples, 0);
            bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
            recording = false;
            uiController.Notify("thinking", true);
            characterController.Notify("state", "think");
            SendRecording();
        }
    }

    private void SendRecording()
    {
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
            respondGeneration.inputSentences = response;
            Debug.Log("Recognition: " + response);
        }, error => {
            Debug.LogError(error);
            characterController.Notify("state", "idle");
            uiController.Notify("thinking", false);
            uiController.Notify("error1", true);
        });
    }

    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
        {
            using (var writer = new BinaryWriter(memoryStream))
            {
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + samples.Length * 2);
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((ushort)1);
                writer.Write((ushort)channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2);
                writer.Write((ushort)(channels * 2));
                writer.Write((ushort)16);
                writer.Write("data".ToCharArray());
                writer.Write(samples.Length * 2);

                foreach (var sample in samples)
                {
                    writer.Write((short)(sample * short.MaxValue));
                }
            }
            return memoryStream.ToArray();
        }
    }
}
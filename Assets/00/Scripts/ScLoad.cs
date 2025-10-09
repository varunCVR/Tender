using System;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
/*using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;*/


public class ScLoad : MonoBehaviour
{
    /*[Obsolete]
    MqttClient client = new MqttClient(IPAddress.Parse(@"192.168.0.2"));
    System.Random rnd = new System.Random();
    private string clientId;
    string Scene = "";
    
    // private string deviceIdString = "dY0536";
    public string deviceId = "dY0536";
    
    DateTime start;
    string startTime, startDate, endTime, endDate;

    void Start()
    {
        // deviceId = deviceIdString;
        client.Publish("connected/nilVR", Encoding.UTF8.GetBytes(deviceId + " on"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        Debug.Log(deviceId + " on");
        clientId = rnd.Next().ToString();
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        client.Connect(clientId);
        
        start = DateTime.Now;
        startTime = start.ToString("hh:mm:ss tt");
        startDate = start.ToString("dd/MM/yyyy");

        startDate = string.Join("/", startDate.Split('-'));
        
       

        // subscribe to the topic "/home/temperature" with QoS 2 
        client.Subscribe(new string[] { "/nilVR" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

    }

    public void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        int i = e.Message.Length;
        Scene = Encoding.Default.GetString(e.Message);
        // Update();


    }

    void Update()
    {
        if (Scene != "")
        {
            /*if (GameManager.instance.prevScenename !=
             * 
             * 
             * 
             * null)
            {
                SceneManager.UnloadSceneAsync(GameManager.instance.prevScenename);
            }#1#
            SceneManager.LoadScene(Scene);
            // GameManager.instance.prevScenename = Scene;
            Scene = "";
        }

    }
    
    public void Finish()
    {
        DateTime end = DateTime.Now;
        string endTime = end.ToString("hh:mm:ss tt");
        string endDate = end.ToString("dd/MM/yyyy");

        endDate = string.Join("/", endDate.Split('-'));

        TimeSpan timeDiff = end - start;
        DateTime durationDt = Convert.ToDateTime(timeDiff.ToString());
        string duration = durationDt.ToString("HH:mm:ss");

        string message = deviceId + "," + startTime + "," + endTime + "," + startDate + "," + endDate + "," + duration;

        client.Publish("activeTime/nilVR", Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
        client.Publish("connected/nilVR", Encoding.UTF8.GetBytes(deviceId + " off"),
            MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,
            false);

        // Application.Quit();
        SceneManager.LoadScene("Menu");
    }

    public void QuitApplication()
    {
        client.Publish("connected/nilVR", Encoding.UTF8.GetBytes(deviceId + " off"),MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,false);
        Debug.Log(deviceId + " off");
        Application.Quit();
    }*/
}

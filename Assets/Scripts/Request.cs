using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;



[System.Serializable]
public class Time
{
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }
    public int hour { get; set; }
    public int minute { get; set; }
    public int seconds { get; set; }
    public int milliSeconds { get; set; }
    public DateTime dateTime { get; set; }
    public string date { get; set; }
    public string time { get; set; }
    public string timeZone { get; set; }
    public string dayOfWeek { get; set; }
    public bool dstActive { get; set; }

}

[System.Serializable]
public class TimeReserve
{
    public string timezone { get; set; }
    public string formatted { get; set; }
    public long timestamp { get; set; }
    public int weekDay { get; set; }
    public int day { get; set; }
    public int month { get; set; }
    public int year { get; set; }
    public int hour { get; set; }
    public int minute { get; set; }

}

public class Request : MonoBehaviour
{
    [SerializeField] private string _url;
    [SerializeField] private string _url2;



    private void Start()
    {
        
        StartCoroutine(SendRequest());
        StartCoroutine(Caller());
    }


    private IEnumerator Caller()
    {
        StartCoroutine(SendRequest());
        yield return new WaitForSeconds(3600);
        StartCoroutine(SendRequestReserve());
        yield return new WaitForSeconds(3600);


    }

    private IEnumerator SendRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get( this._url );     
        
        yield return request.SendWebRequest();
        string json = request.downloadHandler.text;
               
        Time time = JsonConvert.DeserializeObject<Time>(json);
       

        ClockUI.CurrentHour = Convert.ToInt32(time.hour);
        ClockUI.CurrentMinute = Convert.ToInt32(time.minute);
        ClockUI.CurrentSeconds = Convert.ToInt32(time.seconds);

    }

    private IEnumerator SendRequestReserve()
    {
        UnityWebRequest request2 = UnityWebRequest.Get(this._url2);

        yield return request2.SendWebRequest();
        string json2 = request2.downloadHandler.text;

        TimeReserve time2 = JsonConvert.DeserializeObject<TimeReserve>(json2);


        if(ClockUI.CurrentHour != Convert.ToInt32(time2.hour))
            ClockUI.CurrentHour = Convert.ToInt32(time2.hour);

        if(ClockUI.CurrentMinute != Convert.ToInt32(time2.minute))
            ClockUI.CurrentMinute = Convert.ToInt32(time2.minute);

        

    }









}





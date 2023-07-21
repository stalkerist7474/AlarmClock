using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class ClockUI : MonoBehaviour
{
    public static ClockUI Instance;
    public static int CurrentHour;
    public static int CurrentMinute;
    public static int CurrentSeconds;
    public static bool ArrowMove = true;
    public static bool OnAlarm = false;

    
    [SerializeField] private Transform _clockHourHand;
    [SerializeField] private Transform _clockMinuteHand;
    [SerializeField] private Transform _clockSecondsHand;
    [SerializeField] private TMP_Text _textTime;
    [SerializeField] private int _setHour;
    [SerializeField] private  int _setMinute;
    [SerializeField] private int _setSeconds;

    private TMP_Text _textAlarm;
      
    
    
    

    private void Awake()
    {
        CurrentHour = _setHour;
        CurrentMinute = _setMinute;
        CurrentSeconds = _setSeconds;



        _clockHourHand = transform.Find("HourHand");
        _clockMinuteHand = transform.Find("MinuteHand");
        _clockSecondsHand = transform.Find("SecondsHand");
        _textTime = GameObject.Find("Display").GetComponent<TMP_Text>();
        _textAlarm = GameObject.Find("DisplayAlarm").GetComponent<TMP_Text>();    


        
    }
    private void Start()
    {
        ResetTime();
        StartCoroutine(TimeFlow());

        _textAlarm.text = "";



    }
    private void Update()
    {
        

        _textTime.text = CurrentHour.ToString("00") + ":" + CurrentMinute.ToString("00") + ":" + CurrentSeconds.ToString("00");

        if(ArrowMove)
        {
            
            _clockHourHand.eulerAngles = new Vector3(0, 0, (ConvertNumberHourToAngle(CurrentHour)) - (int)(CurrentMinute * 0.5)); // ������� ������� ������� � �������������� �� �����
            _clockMinuteHand.eulerAngles = new Vector3(0, 0, ConvertNumberMinuteToAngle(CurrentMinute));// ������� �������� �������
            _clockSecondsHand.eulerAngles = new Vector3(0, 0, ConvertNumberSecondsToAngle(CurrentSeconds));// ������� ��������� �������
        }

        if (OnAlarm)
        {
            _textAlarm.text = AlarmUI.AlarmHour.ToString("00") + ":" + AlarmUI.AlarmMinute.ToString("00");
            
        }
        if (!OnAlarm)
        {
            _textAlarm.text = "";
        }
        


    }

    IEnumerator TimeFlow()
    {
        while (true)
        {
            CurrentSeconds++;
            yield return new WaitForSeconds(1);
            if (CurrentSeconds == 60)
            {
                CurrentMinute++;
                CurrentSeconds = 0;

                if (CurrentMinute == 60)
                {
                    
                    CurrentHour++;
                    CurrentMinute = 0;

                    if (CurrentHour == 24)
                    {
                        CurrentHour = 0;
                    }
                }
            }

        }
    }

    //������� �������� ����� � ���� �������� ����������
    private int ConvertNumberHourToAngle(int hour)
    {
        return hour * -30;
    }

    private int ConvertNumberMinuteToAngle(int minute)
    {
        return minute * -6;
    }

    private int ConvertNumberSecondsToAngle(int seconds)
    {
        return seconds * -6;
    }

    /////////////////////////////////////////////////////
    //������� �������� ���� � �����

    public int ConvertAngleHourToNumber(int angle)
    {
        return angle / -30;
    }

    public int ConvertAngleMinuteToNumber(int angle)
    {
        return angle / -6;
    }

    private int ConvertAngleSecondsToNumber(int angle)
    {
        return angle / -6;
    }

    /////////////////////////////////////////////////////
    
    private void ResetTime()
    {
        _clockHourHand.eulerAngles = new Vector3(0, 0, ConvertNumberHourToAngle(CurrentHour));
        _clockMinuteHand.eulerAngles = new Vector3(0, 0, ConvertNumberMinuteToAngle(CurrentMinute));
        _clockSecondsHand.eulerAngles = new Vector3(0, 0, ConvertNumberSecondsToAngle(CurrentSeconds));
    }



    


}

using TMPro;
using UnityEngine;

public class AlarmUI : MonoBehaviour
{


    //������������� ���������
    public static int AlarmHour = 99;
    public static int AlarmMinute = 99;
    //��������� ������� �� ����� ������ ��������� ����������
    public static int _arrowHour;
    public static int _arrowMinute;
    //������� �����
    private int _currentHour;
    private int _currentMinute;
    private AudioSource _audio;



    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void OpenPanel(GameObject panel)
    {
        panel.GetComponent<CanvasGroup>().alpha = 1;
        ClockUI.ArrowMove = false;


    }

    public void ClosePanel(GameObject panel)
    {
        panel.GetComponent<CanvasGroup>().alpha = 0;
        ClockUI.ArrowMove = true;

    }

    //��������� ���� ���������� �� ����
    public void GetAlarmDigitalHourHandler(TMP_InputField hour)
    {
        var h = System.Convert.ToInt32(hour.GetComponent<TMP_InputField>().text);
        if (00 <= h)
        {
            if (h <= 24)
            {
                AlarmHour = h;
                ClockUI.OnAlarm = true;
                _audio.mute = true;

            }
        }
        else
        {
            ClockUI.OnAlarm = false;
            Debug.Log("error input");
        }
    }

    //��������� ����� ���������� �� ����
    public void GetAlarmDigitalMinuteHandler(TMP_InputField minute)
    {
        var m = System.Convert.ToInt32(minute.GetComponent<TMP_InputField>().text);


        if (00 <= m)
        {
            if (m <= 60)
            {
                AlarmMinute = m;
                ClockUI.OnAlarm = true;
                _audio.mute = true;

            }
        }
        else
        {
            ClockUI.OnAlarm = false;
            Debug.Log("error input");
        }

    }

    private void Update()
    {
        _currentHour = ClockUI.CurrentHour;
        _currentMinute = ClockUI.CurrentMinute;



        if (AlarmHour == _currentHour && AlarmMinute == _currentMinute && ClockUI.OnAlarm)
        {
            Debug.Log("ALARM ON");

            _audio.mute = false;


        }
    }

    //��������� ���������� �� ��������� ������� - ��������� ������
    public void SetAlarmFromArrows()
    {
        AlarmHour = _arrowHour;
        AlarmMinute = _arrowMinute;
        ClockUI.OnAlarm = true;
        _audio.mute = true;
    }




}

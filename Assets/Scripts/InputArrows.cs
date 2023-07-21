using UnityEngine;
using UnityEngine.EventSystems;

public class InputArrows : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //текуща€ перемещ€ема€ стрелка
    private string _currentDragArrow;


    private Vector3 m_PrevPos = Vector3.zero;
    private Vector3 m_DeltaPos = Vector3.zero;

    //выделение стрелки
    public void OnBeginDrag(PointerEventData eventData)
    {

        _currentDragArrow = eventData.pointerCurrentRaycast.gameObject.name;


    }

    //перетаскивание стрелки
    public void OnDrag(PointerEventData eventData)
    {

        if (_currentDragArrow == "HourHand" || _currentDragArrow == "MinuteHand")
        {

            m_DeltaPos = Input.mousePosition - m_PrevPos;

            transform.Rotate(0, 0, Vector3.Dot(m_DeltaPos, Input.mousePosition.normalized));

            m_PrevPos = Input.mousePosition;




        }


    }

    //отпускание стрелки
    public void OnEndDrag(PointerEventData eventData)
    {

        if (_currentDragArrow == "HourHand")
        {
            if ((int)transform.rotation.eulerAngles.z > 0)
            {

                AlarmUI._arrowHour = (-360 + (int)transform.rotation.eulerAngles.z) / -30;
                _currentDragArrow = "";
            }
            else
            {

                AlarmUI._arrowHour = (int)transform.rotation.eulerAngles.z / -30;
                _currentDragArrow = "";

            }



        }
        if (_currentDragArrow == "MinuteHand")
        {

            if ((int)transform.rotation.eulerAngles.z > 0)
            {

                AlarmUI._arrowMinute = (-360 + (int)transform.rotation.eulerAngles.z) / -6;
                _currentDragArrow = "";
            }
            else
            {

                AlarmUI._arrowMinute = (int)transform.rotation.eulerAngles.z / -6;
                _currentDragArrow = "";

            }

        }
    }


}

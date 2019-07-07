using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GazeHoldEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] float gazeTapTime = 2.0f;
    [SerializeField] UnityEvent onGazeHold;

    float timer;
    bool isHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        timer = 0.0f;
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
    }

    public void Update()
    {
        if (!isHover)
        {
            return;
        }
        timer += Time.deltaTime;
        if (gazeTapTime < timer)
        {
            onGazeHold.Invoke();
            isHover = false;
        }
    }
}
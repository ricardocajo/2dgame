using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{

    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    public Camera cameraUI;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 80f;
    }

    public void PointerDown()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = cameraUI.nearClipPlane + 1;
        Vector3 screenToWorldPos = cameraUI.ScreenToWorldPoint(screenPosition);

        joystick.transform.position = screenToWorldPos;
        joystickBG.transform.position = screenToWorldPos;
        joystickTouchPos = screenToWorldPos;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        Vector2 screenToWorldPos = cameraUI.ScreenToWorldPoint(dragPos);
        joystickVec = (screenToWorldPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(screenToWorldPos, joystickTouchPos);

        if(joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }

        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }

}

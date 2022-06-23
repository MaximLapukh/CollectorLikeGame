using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IGetDirecction
{
    [SerializeField] RectTransform _joystickBack;
    [SerializeField] RectTransform _joystickController;
    private Vector2 _inputDirection;
    private void Awake()
    {
        _inputDirection = Vector2.zero;
    }
    public Vector2 GetDir() => _inputDirection;
    public void OnDrag(PointerEventData eventData)
    {
       if( RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBack,
            eventData.position, eventData.pressEventCamera, out Vector2 localPoint)){

            var tempDirection = new Vector2(
                (localPoint.x / _joystickBack.sizeDelta.x) * 2 ,
                (localPoint.y / _joystickBack.sizeDelta.y) * 2);
            if(tempDirection.magnitude > 1) tempDirection.Normalize();

            _joystickController.anchoredPosition = new Vector2(
                tempDirection.x * _joystickBack.sizeDelta.x / 2,
                tempDirection.y * _joystickBack.sizeDelta.y / 2);

            _inputDirection = tempDirection;

        }
    }

    public void OnDrop()
    {
        _inputDirection = Vector2.zero;
        _joystickController.localPosition = Vector2.zero;
    }
}

using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

public class ButtonScaleAnimationBehaviour : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerExitHandler
{
    [SerializeField] private Transform _targetTransform = null;

    [SerializeField] private Vector3 _from = Vector3.one;

    [SerializeField] private Vector3 _to = new Vector3(0.9f, 0.9f, 0.9f);

    [SerializeField] private float _duration = 0.125f;

    private Tween _scaleTween;

    public void OnPointerDown(PointerEventData eventData)
    {
        KillScaleTween();

        _scaleTween = _targetTransform.DOScale(_to, _duration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        KillScaleTween();

        _scaleTween = _targetTransform.DOScale(_from, _duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        KillScaleTween();

        _scaleTween = _targetTransform.DOScale(_from, _duration);
    }

    private void KillScaleTween()
    {
        if (_scaleTween != null)
        {
            _scaleTween.Kill();

            _scaleTween = null;
        }
    }
}
using System;
using UnityEngine;

public class LocalPointClickInRectangle : MonoBehaviour
{
     private RectTransform _rectTransform => transform as RectTransform;
     public event Action<Vector2> OnMouseClick;

     [SerializeField] private TargetHighlight _targetHighlight;
     
     private void Update()
     {
         if (!Input.GetMouseButtonUp(0))
         {
             return;
         }
         
         RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, Input.mousePosition,
             GetComponentInParent<Canvas>().worldCamera, out var localPoint);
         var normalizedPoint = Rect.PointToNormalized(_rectTransform.rect, localPoint);
         OnMouseClick?.Invoke(normalizedPoint);
         
         _targetHighlight.SetTarget(normalizedPoint, _rectTransform.rect);
         // Debug.Log(normalizedPoint);
     }
 }

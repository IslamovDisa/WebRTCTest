using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHighlight : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private RectTransform _highlightElement;
    [SerializeField] private float _delay = 5.0f;
    [SerializeField] private float _currentDelay;

    private void Update()
    {
        if (!_highlightElement.gameObject.activeSelf)
        {
            return;
        }
        
        if (_currentDelay < _delay)
        {
            _currentDelay += Time.deltaTime;
        }
        else
        {
            _highlightElement.gameObject.SetActive(false);
            _currentDelay = 0.0f;
        }
    }

    public void SetTarget(Vector2 position, Rect parent)
    {
        var point = Rect.NormalizedToPoint(parent, position);
        _highlightElement.localPosition = point;
        _currentDelay = 0.0f;
        _highlightElement.gameObject.SetActive(true);
    }
}

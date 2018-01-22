using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DepressedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField]
	private GameObject Contents;

	[SerializeField]
	private float DepressBy;

	private bool _isDown;
	private bool _isOver;
	private Vector3 _startPos;

	public void Awake()
	{
		_startPos = Contents.transform.localPosition;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_isDown = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_isDown = false;
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		_isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_isOver = false;
	}

	private void Update()
	{
		var depress = _isDown && _isOver ? DepressBy : 0;
		Contents.transform.localPosition = _startPos + new Vector3(0, -depress, 0);
	}
}

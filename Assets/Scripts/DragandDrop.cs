using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class DragandDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
	private RectTransform rectTransform;
	private string filename;
	private float startTime; 

	public void Start () {
		filename = @"UserData/MapData/buildingOrder_" + PlayerID.id + ".csv";
		startTime = Time.time; 
	}

	/*public void OnPointerExit(PointerEventData eventData){
		image.SetActive(false);
	}*/

	private void Awake(){
		rectTransform = GetComponent<RectTransform>();
	}
	/*public void OnPointerDown(PointerEventData eventData){
		Debug.Log("OnPointerDown");
		image.SetActive(true);
	}*/
	public void OnDrag(PointerEventData eventData){
		Debug.Log("OnDrag");
		//image.SetActive(true);
		rectTransform.anchoredPosition += eventData.delta;
	}
	public void OnBeginDrag(PointerEventData eventData){
		Debug.Log("BeginDrag");
		//image.SetActive(true);
	}

	public void OnEndDrag(PointerEventData eventData){
		Debug.Log(rectTransform.position);
		if(rectTransform.position.x < 475 && rectTransform.position.x > 90 && rectTransform.position.y > 40 && rectTransform.position.y < 440)
		{
			TextWriter writer = new StreamWriter(filename, true);

			float currTime = Time.time - startTime; 
			writer.WriteLine(currTime + "," + rectTransform.name);
		}

	}

}

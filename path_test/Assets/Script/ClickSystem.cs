using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*ANCHOR
綁在cubes上
https://www.itread01.com/content/1548321125.html
https://godstamps.blogspot.com/2015/10/unity-unityengineevents.html
讓自定義class的資料顯示在外部
自己寫了一個Event
把cube全抓進來
*/
[System.Serializable]
public class CubeEvent : UnityEvent<Cube> {
}

public class ClickSystem : MonoBehaviour {

	Cube[] cubes;

	// Use this for initialization
	void Start ()
	{
		cubes = Object.FindObjectsOfType<Cube> ();
	}

	public CubeEvent CubeClicked;

	// Update is called once per frame
	void Update ()
	{
		/*ANCHOR
		點擊
		射線
		distance<射線長度

		if有按到東西
		回傳target給CubeClicked的函式
		*/
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			float distance = Mathf.Infinity;
			Cube target = null;
			foreach (var c in cubes)
			{
				var col = c.GetComponent<Collider>();
				if (col.Raycast (ray, out hit, distance))
				{
					distance = hit.distance;
					target = hit.collider.gameObject.GetComponent<Cube> ();
				}
			}

			if (target) {
				CubeClicked.Invoke (target);
			}
		}
	}
}

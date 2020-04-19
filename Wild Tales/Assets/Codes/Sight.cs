using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {
	RaycastHit hit;
	public T see<T>()where T : MonoBehaviour {
		T t = GetComponent<Area>().overlap<T>();
		if (
			t &&
			Physics.Raycast(transform.position, t.transform.position - transform.position, out hit, Mathf.Infinity) &&
			hit.collider.GetComponent<T>()
		) {
			return hit.collider.GetComponent<T>();
		} else
			return null;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyhat : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("hat"))
		{
			Destroy(other.gameObject);
		}
	}
}

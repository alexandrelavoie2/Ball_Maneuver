using UnityEngine;
using System.Collections;

public class Rotate_Object : MonoBehaviour 

{
	void Update () 
	{
		transform.Rotate (new Vector3 (0, 0, 100) * Time.deltaTime);
	}
}
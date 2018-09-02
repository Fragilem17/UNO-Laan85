using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SetFocusDistance : MonoBehaviour {

	public LayerMask maskLayer = 1;
	public Camera cam;
	public Vector3 middle;

	public PostProcessVolume profile;
	private	DepthOfField _depthOfField;

	// Use this for initialization
	void Start () {

		profile.profile.TryGetSettings<DepthOfField>(out _depthOfField);

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = cam.ViewportPointToRay(middle, Camera.MonoOrStereoscopicEye.Mono);

		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

		//print(maskLayer.value + " : " + gameObject.layer);
		if (Physics.Raycast(ray, out hit, 10000, maskLayer))
		{
			float d = Vector3.Distance(transform.position, hit.point);
			//print("RAYING " + hit.transform.gameObject.name + ": " + d);

			_depthOfField.focusDistance.Override(d);

		}
	}
}

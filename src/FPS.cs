using System;
using UnityEngine;

public class FPS : MonoBehaviour
{
	public float f_UpdateInterval = 0.5f;

	private float f_LastInterval;

	private int i_Frames;

	private float f_Fps;

	private void Start()
	{
		this.f_LastInterval = Time.realtimeSinceStartup;
		this.i_Frames = 0;
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(0f, 0f, 300f, 500f), string.Format("<color=red><size=40><b>{0:0}</b></size></color>", this.f_Fps));
	}

	private void Update()
	{
		this.i_Frames++;
		if (Time.realtimeSinceStartup > this.f_LastInterval + this.f_UpdateInterval)
		{
			this.f_Fps = (float)this.i_Frames / (Time.realtimeSinceStartup - this.f_LastInterval);
			this.i_Frames = 0;
			this.f_LastInterval = Time.realtimeSinceStartup;
		}
	}
}

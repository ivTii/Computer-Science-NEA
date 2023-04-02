using System.Collections;
using UnityEngine;
public class ShaderEffect_CorruptedVram : MonoBehaviour {

	float randomNumber;

	float shift = 0;
	public Texture texture;
	public Material material;
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/Distortion") );
	}

    private void Update()
    {
		if (SettingsButtonScript.instance.cameraGlitch == true)
		{
			if (MoveTo.instance.isPlayerClose == true)
			{
				randomNumber = Random.Range(-1.5f, 1.5f);
			}
			else randomNumber = 0;
			shift = randomNumber;
		}
		else shift = 0;

    }

    void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_ValueX", shift);
		material.SetTexture("_Texture", texture);
		Graphics.Blit (source, destination, material);
	}
}

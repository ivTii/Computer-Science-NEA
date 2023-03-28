using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderEffect_CorruptedVram : MonoBehaviour {

	int randomNumber;

	float shift = 10;
	private Texture texture;
	private Material material;

	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/Distortion") );
		texture = Resources.Load<Texture>("Checkerboard-big");
	}

    private void Update()
    {
		if (MoveTo.instance.isPlayerClose == true)
		{
			randomNumber = Random.Range(-1, 1);
		}
		else randomNumber = 0;
		shift = randomNumber;

    }

    void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_ValueX", shift);
		material.SetTexture("_Texture", texture);
		Graphics.Blit (source, destination, material);
	}
}

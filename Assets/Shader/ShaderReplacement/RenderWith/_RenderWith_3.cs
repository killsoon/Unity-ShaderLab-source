using UnityEngine;
using System.Collections;
public class _RenderWith_3 : MonoBehaviour {
	public string replacebyTag="myTag";
	public Shader useShader;
	 Camera rtCam;
     RenderTexture rt;
     void Start()
     {
         rt = new RenderTexture(Screen.width, Screen.height, 16);
     }
    void OnRenderImage(RenderTexture src,RenderTexture dst)
    {
        Graphics.Blit(rt, dst);
    }
	void OnPreCull()
	{
        if (!rtCam)
        {
            GameObject g = new GameObject("render with Shader Cam");
            rtCam = g.AddComponent<Camera>();
            rtCam.enabled = false;
            rtCam.hideFlags = HideFlags.HideAndDontSave;
            //因为我们的替代材质是适应于Forward渲染路径的
            rtCam.renderingPath = RenderingPath.Forward;
        }
        rtCam.CopyFrom(camera);
        rtCam.targetTexture = rt;
     	rtCam.RenderWithShader(useShader,replacebyTag);
	}
}

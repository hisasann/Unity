using UnityEngine;
using System.Collections;
using System.IO;

public class ScreenCapture  {
	
	
	public void CaptureJPG(string filePath, int superSize){
		int width = Screen.width;
		int height = Screen.height;
		
		Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
		texture.ReadPixels (new Rect(0, 0, width, height), 0, 0);
		texture.Apply();
		
		JPGEncoder enc = new JPGEncoder(texture, 100, filePath);
		GameObject.Destroy(texture);

		Debug.Log(filePath+" : saved !");
	}

	public void CapturePNG(string filePath, int superSize){
		int width = Screen.width;
		int height = Screen.height;
		
		Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
		texture.ReadPixels (new Rect(0, 0, width, height), 0, 0);
		texture.Apply();
		
		byte[] bytes = texture.EncodeToPNG();
		GameObject.Destroy(texture);
		
		File.WriteAllBytes(filePath, bytes);		
		
		Debug.Log(filePath+" : saved !");
	}
}

using UnityEngine;

public class WebcamTest : MonoBehaviour
{
    public int cameraIndex = 0;

    private WebCamTexture webcam;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        Debug.Log("===== WEBCAMS =====");
        Debug.Log("Quantidade: " + devices.Length);

        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("[" + i + "] " + devices[i].name);
        }

        if (devices.Length == 0)
        {
            Debug.LogError("Nenhuma webcam encontrada!");
            return;
        }

        if (cameraIndex >= devices.Length)
        {
            Debug.LogError("Índice de câmera inválido!");
            return;
        }

        webcam = new WebCamTexture(devices[cameraIndex].name);

        webcam.Play();

        Debug.Log("Abrindo webcam [" + cameraIndex + "]: " + devices[cameraIndex].name);
    }

    void OnGUI()
    {
        if (webcam != null && webcam.isPlaying)
        {
            GUI.DrawTexture(
                new Rect(0, 0, 800, 600),
                webcam,
                ScaleMode.ScaleToFit
            );
        }
    }

    void OnDestroy()
    {
        if (webcam != null && webcam.isPlaying)
        {
            webcam.Stop();
        }
    }
}
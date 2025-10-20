using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WebCamDisplay : MonoBehaviour
{
    public RawImage RawImage;
    [SerializeField] private AspectRatioFitter _aspectFitter;
    [SerializeField] private TMP_Dropdown _cameraList;
    [SerializeField] private TextMeshProUGUI _cameraText;
    public TextMeshProUGUI _errorField;
    private WebCamTexture _webCamTexture;

    private void Awake()
    {
        _cameraList.ClearOptions();
        _cameraList.onValueChanged.AddListener(UpdateCamera) ;
        _cameraText.text = string.Empty;
    }

    private IEnumerator Start()
    {
        while (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        }

        if (WebCamTexture.devices.Length == 0)
        {
            Debug.LogWarning("Камера не найдена!");
            _errorField.text = "Камера не найдена!";
            _errorField.gameObject.SetActive(true);
            yield break;
        }
        else
        {
            _errorField.gameObject.SetActive(false);
        }

        if (_cameraList != null)
        {
            var devices = WebCamTexture.devices;
            int i = 1;
            List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData>();
            foreach (var device in devices) 
            {
                data.Add(new TMP_Dropdown.OptionData(device.name));
                _cameraText.text += $"{i} - {device.name}";
                i++;
            }
            _cameraList.AddOptions(data);
            if (data.Count > 1)
            {
                _cameraList.value = 1;
            }
            else if (data.Count == 1)
            {
                _cameraList.value = 0;
            }
            SetActiveCamera(_cameraList.options[_cameraList.value].text);
        }
        else
        {
            SetActiveCamera(WebCamTexture.devices[0].name);
        }
    }

    private void UpdateCamera(int numb)
    {
        SetActiveCamera(_cameraList.options[numb].text);
    }

    private void SetActiveCamera(string cameraName)
    {
        if (_webCamTexture != null)
        {
            _webCamTexture.Stop();
            _webCamTexture = null;
        }
        _webCamTexture = new WebCamTexture(cameraName);

        RawImage.texture = _webCamTexture;
        RawImage.material.mainTexture = _webCamTexture;

        _webCamTexture.Play();
    }
}

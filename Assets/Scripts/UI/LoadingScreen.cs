using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private GameObject loadingIcon;
    public GameObject Canvas;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _extraLoadTime;
    //[SerializeField] private TextMeshProUGUI percentageText;
    //[SerializeField] private TextMeshProUGUI pressContinue;




    private void Start()
    {
        //pressContinue.enabled = false;
        //loadingIcon.SetActive(false);
        Canvas.SetActive(false);
        //Invoke("LoadGameScene",10);
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadAsynchronously(sceneToLoad));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        //loadingIcon.SetActive(true);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;
            //percentageText.text = (progress * 100f).ToString("F0") + " %";

            if (operation.progress >= .9f && !operation.allowSceneActivation)
            {
                //loadingIcon.SetActive(false);
                Vector3 angles = loadingIcon.GetComponent<RectTransform>().eulerAngles;
                angles = new Vector3(angles.x, angles.y, angles.z - _rotationSpeed * Time.deltaTime); // + rotationSpeed for right button
                loadingIcon.GetComponent<RectTransform>().eulerAngles = angles;
                _extraLoadTime -= Time.deltaTime;
            }
            if(_extraLoadTime < 0) operation.allowSceneActivation = true;

            yield return null;
            //yield return new WaitForSeconds(3);
        }
    }
}

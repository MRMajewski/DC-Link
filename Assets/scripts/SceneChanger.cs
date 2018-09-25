using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class SceneChanger : MonoBehaviour {

    [SerializeField]
    float FadeDuration = 1f;

    Image Blend;
	// Use this for initialization
	void Start () {

        Blend = CreateBlend();
        StartCoroutine(FadeInCoroutine());
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    Image CreateBlend()
    {
        var obj = new GameObject();
        obj.transform.parent = transform;//nowy obiekt będzie dzieckiem obecnego obiektu

        var rectTransform = obj.AddComponent<RectTransform>(); //komponnet opisujący opłożenie obrazka
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = Vector2.zero;


        obj.AddComponent<CanvasRenderer>(); //nowy komponent renderujący obrazki
        var image = obj.AddComponent<Image>(); //nowt komponent z obrazkiem, tzn białym tłem
        image.color = Color.white;

        obj.SetActive(false);

        return image;
    }

    public void ChangeScene(string name )
    {
        StartCoroutine(FadeOutCoroutine(name));
    }

    IEnumerator FadeInCoroutine()
    {
        Blend.gameObject.SetActive(true);

        while (Blend.color.a>0f ) //pętlazmniejsza przezroczystość od 1 do 0,tzn będzie widoczny
        {
            Blend.color -= new Color(0f, 0f, 0f, 1f) / FadeDuration * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Blend.gameObject.SetActive(false);
    }
    
    IEnumerator FadeOutCoroutine(string sceneName)
    {
        Blend.gameObject.SetActive(true);

        while (Blend.color.a <= 1f) //nadajemy coraz większą przezroczystość
        {
            Blend.color += new Color(0f, 0f, 0f, 1f) * FadeDuration * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Blend.gameObject.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

}


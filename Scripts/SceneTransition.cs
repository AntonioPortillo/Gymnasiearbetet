using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransition : MonoBehaviour
{
    [Header("New Scene Variables")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;

    [Header("Transition Variables")]
    public GameObject FadeInPanel;
    public GameObject FadeOutPanel;
    public float FadeWait;

    private void Awake()
    {
        if (FadeInPanel != null)
        {
            GameObject panel = Instantiate(FadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
 
    /* public bool needText;
     public string placeName;
     public GameObject text;
     public Text placeText;
     */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition; //På detta sätt kan man få nya värden på spelarens position när man hamnar i en annan scen.
            StartCoroutine(FadeCo());
           
        }
        
       /* if (needText)
        {
            StartCoroutine(placeNameCo());
        } */
    }

    public IEnumerator FadeCo()
    {
        if (FadeOutPanel != null) {
            Instantiate(FadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(FadeWait);
        ResetCameraBounds();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
    
    public void ResetCameraBounds() //fixar Koordinat max och min i både X- och Y-led.
    {
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }
    /*private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    } */
}

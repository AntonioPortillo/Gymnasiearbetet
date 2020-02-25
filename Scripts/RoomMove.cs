using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;
    public Vector3 playerChange; //variablen för vart spelaren ska hamna.
    private CameraFollow cam;
    public bool needText;
    public string placeName; //vad som står i UI
    public GameObject text; //UI 
    public Text placeText; //vart texten är i UI

 
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>(); //hämtar camerafollow skriptet.
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //med hjälp av en boxcollider (ruta som i detta falls inte syns) kan man skapa en zon som kan trigga ett event. 
    {
        if (other.CompareTag("Player")) //vår karaktär är taggad med Player.
        {
            cam.minPosition += cameraMinChange; //båda raderna ändrar boundries till det man behöver i nästa rum. 
            cam.maxPosition += cameraMaxChange;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo() //den här är för att kunna få upp namnet på stället man går till ifall man i unity trycker in bool=true (needText).
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f); //hur länge man ska vänta tills texten försvinner
        text.SetActive(false);
    }
}

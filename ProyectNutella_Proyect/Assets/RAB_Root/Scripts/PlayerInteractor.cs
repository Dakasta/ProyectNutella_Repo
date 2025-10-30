using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Points System")]
    public int points; //Puntuación actual del player (en juego)
    public int winPoints = 1; //Puntuación a alcanzar para completar el nivel
    public TMP_Text pointsText; //Ref al texto de puntos para que cambie dinámicamente

    [Header("Scene Management")]
    public int sceneToLoad = 2;

    [Header("Sound References")]
    public PlayerController playerCont; //Ref als cript que contiene las llamadas a sonidos

    [Header("Object References")]
    [SerializeField] GameObject keyDoor;
    [SerializeField] GameObject key;
    [SerializeField] GameObject pickUpDoor1;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0;
        keyDoor.SetActive(true);
        pickUpDoor1.SetActive(true);
        key.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= winPoints)
        {
            LoadScene();
        }

        pointsText.text = "Points: " + points.ToString() + "/" + winPoints.ToString();

        PickUpDoors();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            points += 1;
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            playerCont.PlaySFX(1);
        }

        if (other.gameObject.CompareTag("Key"))
        {
            key.SetActive(false);
            keyDoor.SetActive(false);
        }
    }

    void PickUpDoors()
    {
        if (points >= 1)
        {
            pickUpDoor1.SetActive(false);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}

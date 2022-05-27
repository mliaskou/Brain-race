using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class LifeBonusGain : MonoBehaviour
{
    public GameObject obstacleText;
    
    public LifePanelAdd lifePanelAdd;
    public CarController carController;
    public GameObject car;

    public int forceApplied = 2;

    public LifePanelAdd lifepanelAdd;
    

    private bool livesAreActive = false;
    [SerializeField] GameObject reloadScenePanel;
    [SerializeField] GameObject pauseGamePanel;
    [SerializeField] GameObject gameOverText;
    [SerializeField] Image wreckedCarImage;

    IEnumerator AfterSoundClip(AudioSource audio, System.Action f)
    {
        yield return new WaitWhile(() => audio.isPlaying);
        f();
    }


    public void Start()
    {
        obstacleText.SetActive(false);

    }

    public void Update()
    {
        for (int i = 0; i < lifePanelAdd.Slots.Length; i++) // If the lives reach zero, then the game is over
        {
            if (lifePanelAdd.Slots[i].activeSelf == true) 
            {
                livesAreActive = true;// If player gets all the lives
                break;
            }
            else
            {
                livesAreActive = false;  // if player loses all the lives then the game is over
            }
            Debug.Log("IsEmpty");
        }

        if (livesAreActive ==false)
        {
            reloadScenePanel.SetActive(true);
            carController.speed = 0;
            gameOverText.SetActive(true);
            wreckedCarImage.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseGamePanel.SetActive(true);
            carController.speed = 0;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            Debug.Log(other.gameObject.GetComponent<AudioSource>().clip); 
            for (int i = 0; i <lifePanelAdd.Slots.Length; i++)
            {
                if (lifePanelAdd.Slots[i].activeSelf == false)
                {
                    lifePanelAdd.Slots[i].SetActive(true);
                    other.gameObject.GetComponent<AudioSource>().Play();//play the "heart" audio
                    break;
                }
            }
            StartCoroutine(AfterSoundClip(other.gameObject.GetComponent<AudioSource>(), () =>
            {
                Destroy(other.gameObject);
            }));
            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            /*obstacleText.SetActive(true);
            Rigidbody obstacleRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromObstacle = (collision.gameObject.transform.position);
            obstacleRigidbody.AddForce(awayfromObstacle, ForceMode.Impulse);*/
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            obstacleText.SetActive(true);
            obstacleText.GetComponentInChildren<Text>().text = "You hit an obstacle";
          }
        for (int i = lifepanelAdd.Slots.Length - 1; i >= 0; i--)
        {

            if (lifepanelAdd.Slots[i].activeSelf == true)
            {
                lifepanelAdd.Slots[i].SetActive(false);


                break;
            }
        }
        obstacleText.SetActive(false);
    }

    private void PlayAudio(GameObject heart)
    {
        Destroy(heart);
    }

    public void ContinueGame()
    {
        pauseGamePanel.SetActive(false);
    }
}

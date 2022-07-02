using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    PlayerControls playerControls;
    ScoreKeeper scoreKeeper;
    //MeshRenderer mesh;
    bool movable = true;
    // Start is called before the first frame update
    void Start()
    {
        playerControls = GetComponent<PlayerControls>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movable)
            transform.Translate(Vector3.right*speed*Time.deltaTime);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("IM HIT");
            if(playerControls != null)
            {

                playerControls.enabled = false;
                movable = false;
                StartCoroutine(Reload());
                //mesh.enabled = false;
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Score")
        {
            scoreKeeper.Increment();
            Debug.Log("Score increment "+scoreKeeper.Score.ToString());
            Destroy(other);
        }
    }
}

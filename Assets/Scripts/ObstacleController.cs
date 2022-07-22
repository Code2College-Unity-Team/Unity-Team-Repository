using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    public GameObject labyrinth;
    private LabyController laby;
    public Material green;
    public Material red;
    private MeshRenderer mesh;
    private bool damage = false;
    // Start is called before the first frame update
    void Start()
    {
        laby = labyrinth.GetComponent<LabyController>();
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (laby.timer > 2)
        {
            // should damage
            mesh.material = red;
            damage = true;
        }
        else
        {
            mesh.material = green;
            damage = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (damage)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            return;
        }
    }
}

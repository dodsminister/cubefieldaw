using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject cubePrefab;
    public float spawnDistanceZ;
    public float spawnDistanceX;
    public float cubeSpeed;
    private List<CubeController> cubes;

    public Text scoreText;

    [Range(0, 0.5f)]
    public float spawnRate = 0.05f;

    public float score = 0;

    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        cubes = new List<CubeController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if (gameOver)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 1;
                gameOver = false;

                score = 0;

                foreach (var cube in cubes)
                {
                    Destroy(cube.gameObject);
                }

                cubes.Clear();
            }
        }
        else
        {
            score += Time.deltaTime;

            if (Random.value < spawnRate)
            {
                var spawnedCube = Instantiate(cubePrefab, player.transform.position + Vector3.forward * spawnDistanceZ + Vector3.right * (Random.value - 0.5f) * 2 * spawnDistanceX, Quaternion.identity);
                var cubeScript = spawnedCube.GetComponent<CubeController>();
                cubeScript.gameControllerCubeListReference = cubes;
                cubeScript.speed = cubeSpeed;
                cubes.Add(cubeScript);
            }

            foreach (var cube in cubes)
            {
                if (Vector3.Distance(player.transform.position, cube.transform.position) < 1)
                {
                    Debug.Log("GAME OVER MADDAFAFAKKA" + score.ToString());

                    gameOver = true;
                    Time.timeScale = 0;
                    break;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    public AudioSource audioSource;

    public UnityEngine.UI.Text scoreText, gameOverBestScore, gameOverScore;
    public UnityEngine.UI.Text[] qlarUI;
    public TextMesh[] qlar;
    public GameObject gameOverScreen, mainMenuScreen;
    public float score;

    public int highScore
    {
        get => PlayerPrefs.GetInt("highScore", 0);
        set => PlayerPrefs.SetInt("highScore", value);
    }

    public List<Car> spheres;

    public float speed, scoreIncrementMultipler;

    public void OnTapToPlay()
    {
        audioSource.Play();
        speed = 5;
        scoreIncrementMultipler = 10;
        mainMenuScreen.SetActive(false);
    }

    public void OnTapRetry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime* scoreIncrementMultipler;
        scoreText.text = ((int)score).ToString();
        transform.position += Vector3.forward * Time.deltaTime * speed;

        foreach (var item in spheres)
        {
            qlarUI[spheres.IndexOf(item)].text = Mathf.Sqrt(item.GetComponent<Car>().prob).ToString();
            float a = item.GetComponent<Car>().prob;
            a = Mathf.Abs(a) < .1f ? 0 : (a > .95f ? 1 : (a > .45f ? .5f : (a > .24 ? .25f : a)));
            qlar[spheres.IndexOf(item)].text = (a).ToString();
            item.GetComponent<Car>().prob = FindObjectOfType<Test>().q0Vector4[spheres.IndexOf(item)];
            if (item.GetComponent<Car>().prob > .95f)
            {
                FindObjectOfType<MaterialController>().InitializeCarMaterials(item.transform.GetChild(0).GetComponent<MeshRenderer>());
            }
            else
            {
                FindObjectOfType<MaterialController>().InitializeHologramMaterials(item.transform.GetChild(0).GetComponent<MeshRenderer>());

            }
        }
    }

    IEnumerator WaitAndGameOva()
    {
        yield return new WaitForSeconds(.6f);
        print("LOSER");
        gameOverScreen.SetActive(true);
        gameOverScreen.transform.localScale = Vector3.zero;
        gameOverScreen.transform.DOScale(1, .2f);

        highScore = score > highScore ? (int)score : highScore;
        gameOverBestScore.text = "BEST: " + (highScore).ToString();
        gameOverScore.text = "SCORE: " + scoreText.text;
        scoreText.gameObject.SetActive(false);
    }

    public bool collapsed;
    public void Collapse(int whoTheFuckIsCollidedIndex)
    {
        if (collapsed)
        {
            return;
        }
        collapsed = true;
        float prob2 = Random.Range(0, 1.0f);
        float[] problist = { 0, 0, 0, 0 };

        for (int i = 0; i < problist.Length; i++)
        {
            problist[i] = i == 0 ? spheres[i].prob : problist[i - 1] + spheres[i].prob;
            if (prob2 < problist[i])
            {
                for (int j = 0; j < 4; j++)
                {
                    FindObjectOfType<Test>().q0[j].Rows[0] = i == j ? 1 : 0;
                }
                collapsed = false;
                if (whoTheFuckIsCollidedIndex == i)
                {
                    spheres[whoTheFuckIsCollidedIndex].transform.DORotate(Vector3.right * 10, .2f).SetLoops(2, LoopType.Yoyo);

                    speed = 0;

                    StartCoroutine(WaitAndGameOva());

                    return;
                }

                print("LUCKY BOI");
                return;
            }
        }
        
    }
}

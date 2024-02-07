using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshProUGUI;
    private int count = 0;
    [SerializeField]
    private GameObject coinBase;


    private static GameManager _instance;
    private AudioSource audioSource;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new("GameManager");
                _instance = go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        //Generando fichas en posiciones random
        for (int i = 0; i < 10; i++)
        {
            Vector3 randPos = new(Random.Range(-10, 10), 0, Random.Range(0, 10));
            GameObject newObject = Instantiate(coinBase);
            newObject.transform.position = randPos;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void GrabCoin()
    {
        count += 1;
        m_TextMeshProUGUI.text = count.ToString();

        if (count == 10)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

    }


}

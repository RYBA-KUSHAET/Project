using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0;
    public int exp = 0;
    public int expToNextLevel = 5;
    public int result;
    public int level = 1;
    public int bestScore;

    private float _grannyTimer;
    private float _invisibleTimer;
    public float hitPower = 1;
    public float scoreIncreasedPerSecond = 1;
    public float x = 0f;

    private bool _grannyVisible = false;
    private bool _firstTimeGrannyVisible = false;

    public Text scoreText;
    public Text bestScoreText;
    public Text levelText;
    public Text expToNextLevelText;

    public GameObject SemitransparentPrefab;
    public GameObject Granny;

    private SpriteRenderer _grannySpriteRenderer;
    
    
    private Vector3 _grannyOriginalPosition;

    //Shop

    public int shop1prize = 25;
    public Text shop1text;

    public int shop2prize = 125;
    public Text shop2text;

    public int shop3prize = 250;
    public Text shop3text;

    public int shop4prize = 500;
    public Text shop4text;

    public int shop5prize = 1000;
    public Text shop5text;


    public Text amount1text;
    public int amount1 = 0;
    public float amount1Profit = 1;

    public Text amount2text;
    public int amount2 = 0;
    public float amount2Profit = 5;

    public Text amount3text;
    public int amount3 = 0;
    public float amount3Profit = 10;

    public Text amount4text;
    public int amount4 = 0;
    public float amount4Profit = 25;

    public Text amount5text;
    public int amount5 = 0;
    public float amount5Profit = 50;


    public int upgradePrize = 50;
    public Text upgradeText;

    public GameObject gm1;
    private bool gm_1 = true;
    public GameObject gm2;
    private bool gm_2 = true;


    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;
    public Image image9;
    public Image image10;

    // Start is called before the first frame update
    void Start()
    {
        result = expToNextLevel - exp;

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        _grannySpriteRenderer = Granny.GetComponent<SpriteRenderer>();
        _grannySpriteRenderer.enabled = false;
        _grannyOriginalPosition = Granny.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if(_grannyVisible)
        {
            _grannyTimer -= Time.deltaTime;

            if(_grannyTimer <= 0)
            {
                _grannyVisible = false;
                _grannySpriteRenderer.enabled = false;
                _grannyTimer = Random.Range(3, 6);
            }
        }

        else if(!_grannyVisible && score >= 20)
        {
            _invisibleTimer -= Time.deltaTime;

            if(_invisibleTimer <= 0)
            {
                _grannyVisible = true;
                _grannySpriteRenderer.enabled = true;
                _invisibleTimer = Random.Range(5, 11);
            }
        }

        if (_grannyVisible)
        {
            float xPosition = _grannyOriginalPosition.x + Mathf.Sin(Time.time) * 0.5f;
            Granny.transform.localPosition = new Vector3(xPosition, Granny.transform.localPosition.y, Granny.transform.localPosition.z);
        }

        result = expToNextLevel - exp;
        scoreIncreasedPerSecond = x * Time.deltaTime;
        score = score + scoreIncreasedPerSecond;

        shop1text.text = "Уровень 1: \n" + shop1prize + " очков";
        shop2text.text = "Уровень 2: \n" + shop2prize + " очков";
        shop3text.text = "Уровень 3: \n" + shop3prize + " очков";
        shop4text.text = "Уровень 4: \n" + shop4prize + " очков";
        shop5text.text = "Уровень 5: \n" + shop5prize + " очков";

        amount1text.text = "Уровень 1: " + amount1 + " улучшений \n" + amount1Profit + " очков/с";
        amount2text.text = "Уровень 2: " + amount2 + " улучшений \n" + amount2Profit + " очков/с";
        amount3text.text = "Уровень 3: " + amount3 + " улучшений \n" + amount3Profit + " очков/с";
        amount4text.text = "Уровень 4: " + amount4 + " улучшений \n" + amount4Profit + " очков/с";
        amount5text.text = "Уровень 5: " + amount5 + " улучшений \n" + amount5Profit + " очков/с";

        upgradeText.text = "Цена: " + upgradePrize + " очков";

        if (exp >= expToNextLevel)
        {
            level++;
            exp = 0;
            expToNextLevel *= 2;
        }

        levelText.text = "Уровень: " + level;
        expToNextLevelText.text = "Опыт до следующего уровня: " + result;

        if (score > bestScore)
        {
            bestScore = (int)score;
        }

        bestScoreText.text = "Лучший счет: " + bestScore;

        if (Input.GetKeyUp(KeyCode.A))
        {
            gm_1 = !gm_1;
            gm1.SetActive(gm_1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            gm_2 = !gm_2;
            gm2.SetActive(gm_2);
        }

        scoreText.text = "Очки: " + (int)score;

        //score achievements
        if (bestScore >= 10)
        {
            image1.color = Color.green;
        }
        else
        {
            image1.color = Color.red;
        }

        if (bestScore >= 100)
        {
            image2.color = Color.green;
        }
        else
        {
            image2.color = Color.red;
        }

        if (bestScore >= 1000)
        {
            image3.color = Color.green;
        }
        else
        {
            image3.color = Color.red;
        }

        if (bestScore >= 10000)
        {
            image4.color = Color.green;
        }
        else
        {
            image4.color = Color.red;
        }

        if (bestScore >= 100000)
        {
            image5.color = Color.green;
        }
        else
        {
            image5.color = Color.red;
        }

        //shop achievements

        if (amount1 >= 10)
        {
            image6.color = Color.green;
        }
        else
        {
            image6.color = Color.red;
        }

        if (amount2 >= 10)
        {
            image7.color = Color.green;
        }
        else
        {
            image7.color = Color.red;
        }

        if (amount3>= 10)
        {
            image8.color = Color.green;
        }
        else
        {
            image8.color = Color.red;
        }

        if (amount4 >= 10)
        {
            image9.color = Color.green;
        }
        else
        {
            image9.color = Color.red;
        }

        if (amount5 >= 10)
        {
            image10.color = Color.green;
        }
        else
        {
            image10.color = Color.red;
        }

    }

    void OnMouseDown()
    {
        score += hitPower;
        exp++;

        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-1f, 3f);

        Instantiate(SemitransparentPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);

        if (_grannyVisible)
        {
            if(score > 20)
            {
                score -= 21;
                scoreText.text = "Очки: " + score;
            }
            else
            {
                score = 0;
                scoreText.text = "Очки: 0";
            }
        }

        if (score >= 20 && !_firstTimeGrannyVisible)
        {
            _grannyVisible = true;
            _grannySpriteRenderer.enabled = true;
            _firstTimeGrannyVisible = true;
        }

        transform.localScale *= 0.8f;
        Invoke(nameof(EnlargeCookie), 0.1f);
    }

    private void EnlargeCookie()
    {
        transform.localScale /= 0.8f;
    }

    public void Shop1()
    {
        if (score >= shop1prize)
        {
            score -= shop1prize;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1prize += 25;
        }
    }

    public void Shop2()
    {
        if (score >= shop2prize)
        {
            score -= shop2prize;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2prize += 125;
        }
    }

    public void Shop3()
    {
        if (score >= shop3prize)
        {
            score -= shop3prize;
            amount3 += 1;
            amount3Profit += 10;
            x += 10;
            shop3prize += 250;
        }
    }

    public void Shop4()
    {
        if (score >= shop4prize)
        {
            score -= shop4prize;
            amount4 += 1;
            amount4Profit += 25;
            x += 25;
            shop4prize += 500;
        }
    }

    public void Shop5()
    {
        if (score >= shop5prize)
        {
            score -= shop5prize;
            amount5 += 1;
            amount5Profit += 50;
            x += 50;
            shop5prize += 1000;
        }
    }

    public void Upgrade()
    {
        if (score >= upgradePrize)
        {
            score -= upgradePrize;
            hitPower += 1;
            upgradePrize *= 3;
        }
    }

}

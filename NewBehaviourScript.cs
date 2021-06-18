using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


/*[System.Serializable]
public class GoogleData
{
    public string order, result, msg, value;
}*/

public class NewBehaviourScript : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("BasicImageTracking");
    }
    public GetTrack floor1;
    /*public GoogleData GD;

    public InputField value; //inputTxT_Secondnum;ss
    //string ValueInput; //send1*/

    /*IEnumerator Start()
    {
        /*WWWForm form = new WWWForm();
        form.AddField("value", "값");
    
      UnityWebRequest www = UnityWebRequest.Post(URL, form);*/
    /* UnityWebRequest www = UnityWebRequest.Get(URL);
     yield return www.SendWebRequest();

     string data = www.downloadHandler.text;
     print(data);
 }*/
    const string URL = "https://docs.google.com/spreadsheets/d/1Aw-tZjPh_1cAbGjqxIAEJzXsuykhBQGhALzb9EGyiM4/export?format=tsv";
    public InputField code1;
    public InputField code2;
    public TextAsset txt;
    public Vector3 endposition;
    public Vector3 endposition3;
    string[,] Sentence;
    int lineSize, rowSize;
    private int send1;
    private int send2;
    public GameObject Button1;
    public GameObject text1;
    public GameObject text2;
    public GameObject background1;
    public GameObject text3;
    public Vector3 point1;
    public Vector3 point2;
    public int k;

    public GameObject blue;
    public GameObject view;
    public Text alarmtext;
    public GameObject Ok;
    public GameObject searching;
    public GameObject hideimg;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;

    public GameObject F1;
    public GameObject F3;
    private void Start()
    {
        Button1 = GameObject.Find("button");
        text1 = GameObject.Find("input1");
        text2 = GameObject.Find("input2");
        background1 = GameObject.Find("Image");
        text3 = GameObject.Find("Text1");


        // 엔터단위와 탭으로 나눠서 배열의 크기 조정
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        // 한 줄에서 탭으로 나눔
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++)
            {
                Sentence[i, j] = row[j];
                //print(i + "," + j + "," + Sentence[i, j]);
            }
        }

        StartCoroutine(DebugPosition());
    }

    public void Send()
    {
        send1 = int.Parse(code1.text);
        send2 = int.Parse(code2.text);
        print("버튼클릭됨");
        k = 2;
        if (k < 66)
        {
            //    print("1층입니다 1층이라구요");
            for (var n = 0; n < Sentence.GetUpperBound(0); n++)
            {
                if (send1 > int.Parse(Sentence[n, 1]) && send1 < int.Parse(Sentence[n + 1, 1]))
                {
                    print(k + "번 책장에 도서가 있습니다");

                    break;
                }

                k = k + 2;

            }
        }
        else
        {
            // k = 68;
            //    print("3층입니다 3층이라구요");
            for (var p = 33; p < 65; p++)
            {
                //print(Sentence[33, 1]);
                if (send1 > int.Parse(Sentence[p, 1]) && send1 < int.Parse(Sentence[p + 1, 1]))
                {
                    print(k + "번 책장에 도서가 있습니다");

                    break;
                }
                k = k + 2;

            }
        }



        GetPosition();
        //온클릭하면 비활성화로 안보이기
        if (k < 67)
        {
            alarmtext.text = "찾으시려는 도서는 1층에 있는 도서입니다. 1층으로 이동해 QR을 인식해주세요";
        }
        else if (k >= 67)
        {
            alarmtext.text = "찾으시려는 도서는 3층에 있는 도서입니다. 3층으로 이동해 QR을 인식해주세요";
        }

        Button1.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        background1.SetActive(false);
        text3.SetActive(false);

        arrow1.SetActive(true);
        arrow2.SetActive(true);
        arrow3.SetActive(true);

      
        Ok = GameObject.Find("ok");



        blue = GameObject.Find("Slider (8)");
        view = GameObject.Find("Panel");

        //   alarmtext = GameObject.Find("alarmtext").GetComponent<Text>();
        searching = GameObject.Find("loading");
        hideimg = GameObject.Find("hide");
    }
    public void sliderMove()
    {
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        float time = 0f;
        while (true)
        {
            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();

            GetComponent<Slider>().value = time / 2;
            if (time >= 2)
            {
                blue.SetActive(false);
                // view.SetActive(false);
                // Ok.SetActive(true);
                searching.SetActive(false);
                //alarmtext.text = "찾으시려는 도서는 1층에 있습니다. 1층으로 이동해 바닥의 QR코드를 인식해주세요";
                //Ok.SetActive(true);
                hideimg.SetActive(false);
                //alarmtext.text = "s";
                // alarmtext.GetComponent<Text>().text = "sssss";
                //GameObject.Find("alarmtext").GetComponent<Text>().text="ssss";
                // print(j);
               
            }

        }
    }

    public void alarm()
    {
        //alarmtext = GameObject.Find("alarmtext").GetComponent<Text>();
        //Ok.transform. = "찾으시려는 도서는 1층에 있습니다. 1층으로 이동해 바닥의 QR코드를 인식해주세요";
        Send2();
    }
    public void Send2()
    {
        //   view.SetActive(false);
        Ok.SetActive(false);
        view.SetActive(false);
    }



        public void Update()
    {
        GetPosition();
    }

    IEnumerator DebugPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            Debug.Log(floor1.position[0].transform.position);
            Debug.Log(endposition);
            Debug.Log(endposition3); 
        }

    }

    public void GetPosition()
    {
        for (int i = 0; i < floor1.position.Length - 1; i++)
        {
            //endposition3 = floor1.position[i].transform.position;
            if (int.Parse(floor1.position[i].name) < k && k < int.Parse(floor1.position[i + 1].name))
            {
                if (k >= 1 && k < 3)
                {
                    endposition = GameObject.Find("1").transform.position;
                    endposition3 = (GameObject.Find("1").transform.position + GameObject.Find("3").transform.position) / 2;
                }
                else if (k >= 3 && k < 5)
                {
                    endposition = GameObject.Find("1").transform.position;
                    endposition3 = (GameObject.Find("3").transform.position + GameObject.Find("5").transform.position) / 2;
                }
                else if (k >= 5 && k < 7)
                {
                    endposition = GameObject.Find("1").transform.position;
                    endposition3 = GameObject.Find("7").transform.position;
                }
                else if (k >= 7 && k < 9)
                {
                    endposition = GameObject.Find("7").transform.position;
                    endposition3 = (GameObject.Find("7").transform.position + GameObject.Find("9").transform.position) / 2;
                }
                else if (k >= 9 && k < 11)
                {
                    endposition = GameObject.Find("7").transform.position;
                    endposition3 = (GameObject.Find("9").transform.position + GameObject.Find("11").transform.position) / 2;
                }
                else if (k >= 11 && k < 13)
                {
                    endposition = GameObject.Find("7").transform.position;
                    endposition3 = GameObject.Find("13").transform.position;
                }
                else if (k >= 13 && k < 15)
                {
                    endposition = GameObject.Find("13").transform.position;
                    endposition3 = (GameObject.Find("13").transform.position + GameObject.Find("15").transform.position) / 2;
                }
                else if (k >= 15 && k < 17)
                {
                    endposition = GameObject.Find("13").transform.position;
                    endposition3 = (GameObject.Find("15").transform.position + GameObject.Find("17").transform.position) / 2;
                }
                else if (k >= 17 && k < 19)
                {
                    endposition = GameObject.Find("13").transform.position;
                    endposition3 = GameObject.Find("19").transform.position;
                }
                else if (k >= 19 &&k < 21)
                {
                    endposition = GameObject.Find("19").transform.position;
                    endposition3 = (GameObject.Find("19").transform.position + GameObject.Find("21").transform.position) / 2;
                }
                else if (k >= 21 && k < 23)
                {
                    endposition = GameObject.Find("19").transform.position;
                    endposition3 = (GameObject.Find("21").transform.position + GameObject.Find("23").transform.position) / 2;
                }
                else if (k >= 23 && k < 25)
                {
                    endposition = GameObject.Find("19").transform.position;
                    endposition3 = GameObject.Find("25").transform.position;
                }
                else if (k>= 25 && k < 27)
                {
                    endposition = GameObject.Find("25").transform.position;
                    endposition3 = (GameObject.Find("25").transform.position + GameObject.Find("27").transform.position) / 2;
                }
                else if (k >= 27 && k < 29)
                {
                    endposition = GameObject.Find("25").transform.position;
                    endposition3 = (GameObject.Find("27").transform.position + GameObject.Find("29").transform.position) / 2;
                }
                else if (k >= 29 && k < 31)
                {
                    endposition = GameObject.Find("25").transform.position;
                    endposition3 = GameObject.Find("31").transform.position;
                }
                else if (k >= 31 &&k < 33)
                {
                    endposition = GameObject.Find("31").transform.position;
                    endposition3 = (GameObject.Find("31").transform.position + GameObject.Find("33").transform.position) / 2;
                }
                else if (k >= 33 && k < 35)
                {
                    endposition = GameObject.Find("31").transform.position;
                    endposition3 = (GameObject.Find("33").transform.position + GameObject.Find("35").transform.position) / 2;
                }
                else if (k >= 35 && k < 37)
                {
                    endposition = GameObject.Find("31").transform.position;
                    endposition3 = GameObject.Find("37").transform.position;
                }
                else if (k >= 37 && k < 39)
                {
                    endposition = GameObject.Find("37").transform.position;
                    endposition3 = (GameObject.Find("37").transform.position + GameObject.Find("39").transform.position) / 2;
                }
                else if (k >= 39 && k < 41)
                {
                    endposition = GameObject.Find("37").transform.position;
                    endposition3 = (GameObject.Find("39").transform.position + GameObject.Find("41").transform.position) / 2;
                }
                else if (k >= 41 && k < 43)
                {
                    endposition = GameObject.Find("37").transform.position;
                    endposition3 = GameObject.Find("43").transform.position;
                }
                else if (k >= 43 && k < 45)
                {
                    endposition = GameObject.Find("43").transform.position;
                    endposition3 = (GameObject.Find("43").transform.position + GameObject.Find("45").transform.position) / 2;
                }
                else if (k >= 45 &&k < 47)
                {
                    endposition = GameObject.Find("43").transform.position;
                    endposition3 = (GameObject.Find("45").transform.position + GameObject.Find("47").transform.position) / 2;
                }
                else if (k >= 47 && k < 49)
                {
                    endposition = GameObject.Find("43").transform.position;
                    endposition3 = GameObject.Find("49").transform.position;
                }
                else if (k >= 49 && k < 51)
                {
                    endposition = GameObject.Find("49").transform.position;
                    endposition3 = (GameObject.Find("49").transform.position + GameObject.Find("51").transform.position) / 2;
                }
                else if (k >= 51 && k < 53)
                {
                    endposition = GameObject.Find("49").transform.position;
                    endposition3 = (GameObject.Find("51").transform.position + GameObject.Find("53").transform.position) / 2;
                }
                else if (k >= 53 && k < 55)
                {
                    endposition = GameObject.Find("49").transform.position;
                    endposition3 = GameObject.Find("55").transform.position;
                }
                else if (k >= 55 && k < 57)
                {
                    endposition = GameObject.Find("55").transform.position;
                    endposition3 = (GameObject.Find("55").transform.position + GameObject.Find("57").transform.position) / 2;
                }
                else if (k>= 57 &&k < 59)
                {
                    endposition = GameObject.Find("55").transform.position;
                    endposition3 = (GameObject.Find("57").transform.position + GameObject.Find("59").transform.position) / 2;
                }
                else if (k >= 59 &&k < 61)
                {
                    endposition = GameObject.Find("55").transform.position;
                    endposition3 = GameObject.Find("61").transform.position;
                }
                else if (k >= 61 && k < 63)
                {
                    endposition = GameObject.Find("61").transform.position;
                    endposition3 = (GameObject.Find("61").transform.position + GameObject.Find("63").transform.position) / 2;
                }
                else if (k >=63 && k<65)
                {
                    endposition = GameObject.Find("61").transform.position;
                    endposition3 = (GameObject.Find("63").transform.position + GameObject.Find("65").transform.position) / 2;
                }
                else if (k >= 67 && k < 69)
                {
                    endposition = GameObject.Find("67").transform.position;
                    endposition3 = GameObject.Find("68").transform.position;
                }
                else if (k >= 69 && k < 71)
                {
                    endposition = GameObject.Find("67").transform.position;
                    endposition3 = GameObject.Find("70").transform.position;
                }
                else if (k >= 71 && k < 73)
                {
                    endposition = GameObject.Find("73").transform.position;
                    endposition3 = GameObject.Find("73").transform.position;
                }
                else if (k >= 73 && k < 75)
                {
                    endposition = GameObject.Find("73").transform.position;
                    endposition3 = GameObject.Find("74").transform.position;
                }
                else if (k >= 75 && k < 77)
                {
                    endposition = GameObject.Find("73").transform.position;
                    endposition3 = GameObject.Find("76").transform.position;
                }
                else if (k >= 77 && k < 79)
                {
                    endposition = GameObject.Find("79").transform.position;
                    endposition3 = GameObject.Find("79").transform.position;
                }
                else if (k >= 79 && k < 81)
                {
                    endposition = GameObject.Find("79").transform.position;
                    endposition3 = GameObject.Find("80").transform.position;
                }
                else if (k >= 81 && k < 83)
                {
                    endposition = GameObject.Find("79").transform.position;
                    endposition3 = GameObject.Find("82").transform.position;
                }
                else if (k >= 83 && k < 85)
                {
                    endposition = GameObject.Find("85").transform.position;
                    endposition3 = GameObject.Find("85").transform.position;
                }
                else if (k >= 85 && k < 87)
                {
                    endposition = GameObject.Find("85").transform.position;
                    endposition3 = GameObject.Find("86").transform.position;
                }
                else if (k >= 87 && k < 89)
                {
                    endposition = GameObject.Find("85").transform.position;
                    endposition3 = GameObject.Find("88").transform.position;
                }
                else if (k >= 89 && k < 91)
                {
                    endposition = GameObject.Find("91").transform.position;
                    endposition3 = GameObject.Find("91").transform.position;
                }
                else if (k >= 91 && k < 93)
                {
                    endposition = GameObject.Find("91").transform.position;
                    endposition3 = GameObject.Find("92").transform.position;
                }
                else if (k >= 93 && k < 95)
                {
                    endposition = GameObject.Find("91").transform.position;
                    endposition3 = GameObject.Find("94").transform.position;
                }
                else if (k >= 95 && k < 97)
                {
                    endposition = GameObject.Find("97").transform.position;
                    endposition3 = GameObject.Find("97").transform.position;
                }
                else if (k >= 97 && k < 99)
                {
                    endposition = GameObject.Find("97").transform.position;
                    endposition3 = GameObject.Find("98").transform.position;
                }
                else if (k >= 99 && k < 101)
                {
                    endposition = GameObject.Find("97").transform.position;
                    endposition3 = GameObject.Find("100").transform.position;
                }
                else if (k >= 101 && k < 103)
                {
                    endposition = GameObject.Find("103").transform.position;
                    endposition3 = GameObject.Find("103").transform.position;
                }
                else if (k >= 103 && k < 105)
                {
                    endposition = GameObject.Find("103").transform.position;
                    endposition3 = GameObject.Find("104").transform.position;
                }
                else if (k >= 105 && k < 107)
                {
                    endposition = GameObject.Find("103").transform.position;
                    endposition3 = GameObject.Find("106").transform.position;
                }
                else if (k >= 107 && k < 109)
                {
                    endposition = GameObject.Find("109").transform.position;
                    endposition3 = GameObject.Find("109").transform.position;
                }
                else if (k >= 109 && k < 111)
                {
                    endposition = GameObject.Find("109").transform.position;
                    endposition3 = GameObject.Find("110").transform.position;
                }
                else if (k >= 111 && k < 113)
                {
                    endposition = GameObject.Find("109").transform.position;
                    endposition3 = GameObject.Find("112").transform.position;
                }
                else if (k >= 113 && k < 115)
                {
                    endposition = GameObject.Find("115").transform.position;
                    endposition3 = GameObject.Find("115").transform.position;
                }
                else if (k >= 115 && k < 117)
                {
                    endposition = GameObject.Find("115").transform.position;
                    endposition3 = GameObject.Find("116").transform.position;
                }
                else if (k >= 117 && k < 119)
                {
                    endposition = GameObject.Find("115").transform.position;
                    endposition3 = GameObject.Find("118").transform.position;
                }
                else if (k >= 119 && k < 121)
                {
                    endposition = GameObject.Find("121").transform.position;
                    endposition3 = GameObject.Find("121").transform.position;
                }
                else if (k >= 121 && k < 123)
                {
                    endposition = GameObject.Find("121").transform.position;
                    endposition3 = GameObject.Find("122").transform.position;
                }
                else if (k >= 123 && k < 125)
                {
                    endposition = GameObject.Find("121").transform.position;
                    endposition3 = GameObject.Find("124").transform.position;
                }
                else if (k >= 125 && k < 127)
                {
                    endposition = GameObject.Find("127").transform.position;
                    endposition3 = GameObject.Find("127").transform.position;
                }
                else if (k >= 127 && k < 129)
                {
                    endposition = GameObject.Find("127").transform.position;
                    endposition3 = GameObject.Find("128").transform.position;
                }
                else
                {
                    endposition = GameObject.Find("127").transform.position;
                    endposition3 = GameObject.Find("130").transform.position;
                }
            }
        }

    }
}
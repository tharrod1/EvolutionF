using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {
    public GameObject perceptronBody;
    public GameObject CenterOfBalance;
    public bool Culling;
    public bool Mutating;
    public bool Permutate;
    public int Cullcount;
    public GameObject[] perceptron= new GameObject[100];
    public bool[] PerceptronPositions = new bool[100];
    public Canvas canvas;
    public bool CycleOnce;
	// Use this for initialization
	void Start () {
        Culling = false;
        Cullcount = 0;
        for(int i = 0; i < 100; i++){
            perceptron[i] = Instantiate(perceptronBody);
            perceptron[i].transform.SetParent(canvas.transform);
            perceptron[i].transform.position = new Vector2(46f, 300.8f - (i * 60f));
            perceptron[i].GetComponent<Interpreter>().Percename = "Perceptron " + i;
            PerceptronPositions[i] = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Permutate)
        {
            for(int i = 0; i < 100; i++)
            {
                switch ((int)Random.Range(0, 7))
                {
                    case 0:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = '<';
                        break;
                    case 1:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = '>';
                        break;
                    case 2:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = '.';
                        break;
                    case 3:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = '+';
                        break;
                    case 4:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = '-';
                        break;
                    case 5:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = '[';
                        break;
                    case 6:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = ']';
                        break;
                    case 7:
                        perceptron[i].GetComponent<Interpreter>().genome[(int)Random.Range(0, 100)] = ',';
                        break;
                }
                perceptron[i].GetComponent<Interpreter>().MUTATION = true;
                Permutate = false;
            }
        }
        //Debug.Log("[er" + perceptron[1].GetComponent<Interpreter>().input);
	    if(Culling == true)
        {
            Culling = false;
            
            for(int i = 0; i < 100; i++)
            {

                if(perceptron[i].GetComponent<Interpreter>().output[0] == 0 || perceptron[i] == null || perceptron[i].GetComponent<Interpreter>().output[0] == 'A')
                {
                    Destroy(perceptron[i]);//cull perceptron
                    PerceptronPositions[i] = false;
                    
                }else
                {
                    PerceptronPositions[i] = false;
                    for (int j = 0; j < 100; j++)
                    {

                        if (perceptron[i].GetComponent<Interpreter>().fitness != 1)
                        {
                            if (PerceptronPositions[j] == false)
                            {
                                perceptron[i].GetComponent<Interpreter>().fitness = 1;
                                
                                perceptron[i].transform.position = new Vector2(46f, 300.8f - (j * 60f));
                                PerceptronPositions[j] = true;
                            }
                        }


                    }
                }
                if(Cullcount == 0)
                {
                    Cullcount++;
                }
            }
            if(Cullcount == 2)//numbers only
            {

                for (int i = 0; i < 100; i++)
                {
                    for(int j = 0; j < 10; j++)
                    {
                       if(  (int)perceptron[i].GetComponent<Interpreter>().output[j] > 0 && (int)perceptron[i].GetComponent<Interpreter>().output[j] < 10)
                        {
                            perceptron[i].GetComponent<Interpreter>().fitness = 2;
                            Debug.Log("NUMBER 2 " + perceptron[i].GetComponent<Interpreter>().Percename);
                            Cullcount = 2;
                        }
                    }
                }
                }
        }
        // 0 loser 1 not empty 2 numbers 3 answer
        if (Mutating == true)
        {
            for (int i = 0; i < 100; i++)
            {
                if (perceptron[i] == null)
                {
                    Debug.Log("DEADMANRISING " + i);

                    int j = 0;
                    bool offspring = false;
                    while (j < 100 )
                    {
                        
                        if (PerceptronPositions[j] == false)
                        {
                                    PerceptronPositions[j] = true;
                                    perceptron[i] = Instantiate(perceptronBody);
                                    perceptron[i].transform.SetParent(canvas.transform);
                                    perceptron[i].transform.position = new Vector2(46f, 300.8f - (j * 60f));
                                    perceptron[i].GetComponent<Interpreter>().Percename = "Perceptron " + i;

                            j = 100;
                        }
                        j++;

                        

                    }
                }

                }

            
            Mutating = false;
        }

	}
    public void OnClick()
    {
        for (int i = 0; i < 100; i++)
        {
            perceptron[i].GetComponent<Interpreter>().RunCycle = true;
            //Debug.Log((char)(perceptron[i].GetComponent<Interpreter>().input[0]));
            /*if (perceptron[i].GetComponent<Interpreter>().input[0] != '*')
            {
                Debug.Log("perceptron " + i + " Success " + perceptron[i].GetComponent<Interpreter>().InputString[0]);
            }
            else
            {
                Debug.Log("perceptron " + i + " Failed");
            }*/
        }


    }
}

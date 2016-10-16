using UnityEngine;
using UnityEngine.UI;
//using System.IO;
using System.Collections;

public class Interpreter : MonoBehaviour
{
    public char []genome ;
    public char[] Cells;
    public Manager manager;
    public int restriction;
    public bool RunCycle;
    public bool MUTATION;
    public int fitness;
    public string Percename;
    public GameObject namechild;
    public GameObject Resultchild;
    public Text brainFuck;
    public string input = GameObject.Find("InputText").GetComponent<Text>().text;
    public Canvas canvas;
    public char[] InputString;
    //Random rand;
    //public Component[] component = gameObject.GetComponentInChildren<Image>();
    public char []output;
    void Start()
    {
        MUTATION = false;
        Debug.Log((char)65);
        Debug.Log((char)66);
        genome  = new char[100];
        Cells = new char[genome.Length];
        for(int i = 0; i < Cells.Length; i++)
        {
            Cells[i] = (char)0;
        }
    //namechild = Instantiate(namechild);
    //namechild.transform.SetParent(canvas.transform);
    namechild.GetComponent<Text>().text = Percename;
        manager = GameObject.Find("Step").GetComponent<Manager>();

        for (int i = 0; i < genome.Length; i++)
        {


            switch ((int)Random.Range(0, 7)) {
                case 0:
                    genome[i] = '<';
                    break;
                case 1:
                    genome[i] = '>';
                    break;
                case 2:
                    genome[i] = '.';
                    break;
                case 3:
                    genome[i] = '+';
                    break;
                case 4:
                    genome[i] = '-';
                    break;
                case 5:
                    genome[i] = '[';
                    break;
                case 6:
                    genome[i] = ']';
                    break;
                case 7:
                    genome[i] = ',';
                    break;
            }
        }
        brainFuck.text = new string(genome);

        // random seed number

    }
    void Update()
    {
        if (MUTATION)
        {
            input = GameObject.Find("InputText").GetComponent<Text>().text;
            Interpret(genome);
            brainFuck.text = new string(genome);
            MUTATION = false;
        }
        namechild.GetComponent<Text>().text = Percename;
        if (RunCycle)
        {
            input = GameObject.Find("InputText").GetComponent<Text>().text;

            Interpret(genome);
            InputString[0] = Resultchild.GetComponent<Text>().text[0];
            brainFuck.text = new string(genome);
            RunCycle = false;
            //Resultchild.GetComponent<Text>().text = new string(output);
        }
}
    public void Interpret(char[] s)
    {

        Cells = new char[genome.Length];
        
        if(restriction < 200)
        {
            restriction = 200;
        }
        int i = 0;
        int right = s.Length;
        int pointer = 0;

        int outspot = 0;
        int inspot = 0;
        while ( i < right && restriction >= 0 )
        {
            switch (s[i])
            {
                case '>':
                    {
                        
                        pointer++;
                        if (pointer >= genome.Length)//change to be the size of the program
                        {
                            pointer = 0;
                        }
                        break;
                    }
                case '<':
                    {
                        pointer--;
                        if (pointer < 0)
                        {
                            pointer = genome.Length - 1;
                        }
                        break;
                    }
                case '.':
                    {
                        output[outspot++] = (char)(Mathf.Abs((Cells[pointer])) +65);
                        Resultchild.GetComponent<Text>().text = new string(output);
                        break;
                    }
                case '+':
                    {
                        Cells[pointer]++;
                        
                        break;
                    }
                case '-':
                    {
                        Cells[pointer]--;
                        
                        break;
                    }
                case '[':
                    {
                        if (Cells[pointer] == 0)
                        {
                            int loop = 1;
                            while (loop > 0)
                            {
                                i++;
                                char c = s[i];
                                if (c == '[')
                                {
                                    loop++;
                                }
                                else
                                if (c == ']')
                                {
                                    loop--;
                                }
                            }
                        }
                        
                        break;
                    }
                case ']':
                    {
                        int loop = 1;
                        while (loop > 0)
                        {
                            i--;
                            char c = s[i];
                            if (c == '[')
                            {
                                loop--;
                            }
                            else
                            if (c == ']')
                            {
                                loop++;
                            }
                        }
                        i--;

                        break;
                    }
                case ',':
                    {
                        // read a key
                        char key = input[inspot++];
                        Cells[pointer] = key;
                        
                        break;
                    }
            }
            restriction--;
            i++;
        }
        Resultchild.GetComponent<Text>().text = new string(output);
        brainFuck.text = new string(genome);

    }
}
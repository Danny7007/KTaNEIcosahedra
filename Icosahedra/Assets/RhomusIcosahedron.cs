using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using KModkit;
using Random = UnityEngine.Random;

public class RhomusIcosahedron : MonoBehaviour
{
    public Material[] Textures;
    public TextMesh[] Symbols1;
    public TextMesh[] Symbols2;
    public TextMesh[] Symbols3;
    public TextMesh[] Symbols4;
    public GameObject[] IcosahedronS;
    public Renderer[] ActualIcosahedronS;
    public Renderer[] Spheres;
    public Renderer[] Hole;
    public TextMesh ButtonText;
    int[][] IcoNumInts = new int[4][];
    Vector3[] rotations = new Vector3[]
    {
        new Vector3 (30,0,-12), //

    }

    float rotationSpeed = 0.01f;
    bool solved = false;
    TextMesh[][] Symbols = new TextMesh[4][];
    static int moduleIdCounter = 1;
    int moduleId;
    public int ButtonValue;
    public KMSelectable Button;

    void Start()
    {
        moduleId = moduleIdCounter++;

        for (int i = 0; i < IcoNumInts.Length; i++)
        {
            IcoNumInts[i] = Enumerable.Range(1, 26).ToArray();
        }

        Symbols[0] = Symbols1;
        Symbols[1] = Symbols2;
        Symbols[2] = Symbols3;
        Symbols[3] = Symbols4;

        for (int i = 0; i < Symbols.Length; i++)
            for (int j = 0; j < Symbols[i].Length; j++)
                Symbols[i][j].text = ((char)(Random.Range(0, 26) + 'A')).ToString();

        ButtonValue = Random.Range(1, 27);
        ButtonText.text = ((char)(ButtonValue - 1 + 'A')).ToString();
        Debug.Log(ButtonValue.ToString());
        RandomizeTexture();
        StartCoroutine(IsoRotate());
    }

    IEnumerator IsoRotate()
    {
        x0 = Random.Range(45, 180);
        x1 = Random.Range(45, 180);
        x2 = Random.Range(45, 180);
        x3 = Random.Range(45, 180);
        y0 = Random.Range(45, 180);
        y1 = Random.Range(45, 180);
        y2 = Random.Range(45, 180);
        y3 = Random.Range(45, 180);
        z0 = Random.Range(45, 180);
        z1 = Random.Range(45, 180);
        z2 = Random.Range(45, 180);
        z3 = Random.Range(45, 180);
        Debug.Log("Hey this is the while lOOOOOOP");
        while (!solved)
        {
            IcosahedronS[0].transform.localEulerAngles = new Vector3(Mathf.LerpAngle(X0, x0, counter0 * counter0 * (3f - 2f * counter0)), Mathf.LerpAngle(Y0, y0, counter0 * counter0 * (3f - 2f * counter0)), Mathf.LerpAngle(Z0, z0, counter0 * counter0 * (3f - 2f * counter0)));
            IcosahedronS[1].transform.localEulerAngles = new Vector3(Mathf.LerpAngle(X1, x1, counter1 * counter1 * (3f - 2f * counter1)), Mathf.LerpAngle(Y1, y1, counter1 * counter1 * (3f - 2f * counter1)), Mathf.LerpAngle(Z1, z1, counter1 * counter1 * (3f - 2f * counter1)));
            IcosahedronS[2].transform.localEulerAngles = new Vector3(Mathf.LerpAngle(X2, x2, counter2 * counter2 * (3f - 2f * counter2)), Mathf.LerpAngle(Y2, y2, counter2 * counter2 * (3f - 2f * counter2)), Mathf.LerpAngle(Z2, z2, counter2 * counter2 * (3f - 2f * counter2)));
            IcosahedronS[3].transform.localEulerAngles = new Vector3(Mathf.LerpAngle(X3, x3, counter3 * counter3 * (3f - 2f * counter3)), Mathf.LerpAngle(Y3, y3, counter3 * counter3 * (3f - 2f * counter3)), Mathf.LerpAngle(Z3, z3, counter3 * counter3 * (3f - 2f * counter3)));
            counter0 += rotationSpeed;
            counter1 += rotationSpeed;
            counter2 += rotationSpeed;
            counter3 += rotationSpeed;
            yield return new WaitForSeconds(.01f);
            if (counter0 >= 1)
            {
                X0 = x0;
                x0 = (x0 + Random.Range(45, 90)) % 360;
                Y0 = y0;
                y0 = (y0 + Random.Range(45, 90)) % 360;
                Z0 = z0;
                z0 = (z0 + Random.Range(45, 90)) % 360;
                counter0 = 0;
            }
            if (counter1 >= 1)
            {
                X1 = x1;
                x1 = (x1 + Random.Range(45, 90)) % 360;
                Y1 = y1;
                y1 = (y1 + Random.Range(45, 90)) % 360;
                Z1 = z1;
                z1 = (z1 + Random.Range(45, 90)) % 360;
                counter1 = 0;
            }
            if (counter2 >= 1)
            {
                X2 = x2;
                x2 = (x2 + Random.Range(45, 90)) % 360;
                Y2 = y2;
                y2 = (y2 + Random.Range(45, 90)) % 360;
                Z2 = z2;
                z2 = (z2 + Random.Range(45, 90)) % 360;
                counter2 = 0;
            }
            if (counter3 >= 1)
            {
                X3 = x3;
                x3 = (x3 + Random.Range(45, 90)) % 360;
                Y3 = y3;
                y3 = (y3 + Random.Range(45, 90)) % 360;
                Z3 = z3;
                z3 = (z3 + Random.Range(45, 90)) % 360;
                counter3 = 0;
            }
        }
        yield break;
    }

    void RandomizeTexture()
    {
        int[] ColorsUsed = new int[4];
        for (int i = 0; i <= 3; i++)
        {
            int MaterialNumber = Random.Range(0, Textures.Length);
            while (ColorsUsed.Any(x => x == MaterialNumber))
            {
                MaterialNumber = Random.Range(0, Textures.Length);
            }
            ActualIcosahedronS[i].material = Textures[MaterialNumber];
            Spheres[i].material = Textures[MaterialNumber];
            Hole[i].material = Textures[MaterialNumber];
            ColorsUsed[i] = MaterialNumber;
        }
        Button.GetComponent<MeshRenderer>().material = Textures[Random.Range(0, 6)];
    }
}

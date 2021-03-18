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
        new Vector3 (30,0,-12),
    };

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

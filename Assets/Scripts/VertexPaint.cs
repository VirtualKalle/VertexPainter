using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VertexPaint : MonoBehaviour
{

    [SerializeField] GameObject go;
    Mesh mesh;
    private Vector3[] vertices;
    Color[] colors;
    Color selectedColor;
    [SerializeField] Color black;
    [SerializeField] Color white;
    float brushSize;
    private Color[] previousColors;

    
    void Start()
    {
        mesh = go.GetComponent<MeshFilter>().sharedMesh;
        vertices = mesh.vertices;
        selectedColor = black;
        colors = new Color[mesh.vertices.Length];
        previousColors = new Color[mesh.vertices.Length];

        // Reset mesh to white at start
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            colors[i] = white;
        }

        mesh.colors = colors;

    }

    public void SetBrushSize(float newBrushSize)
    {
        brushSize = newBrushSize;
    }

    public void SetColor(Color color)
    {
        selectedColor = color;
    }

    public void Undo()
    {
        mesh.colors = previousColors;
        colors = previousColors;
    }

    public void SaveVertexColors()
    {
        string[] writeFileStr = new string[mesh.colors.Length];
        Color[] colorToSave = mesh.colors;
        string colorString;

        if (!Directory.Exists(Application.persistentDataPath + "/VertexPainter"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/VertexPainter");
        }


        for (int i = 0; i < colorToSave.Length; i++)
        {
            colorString = colorToSave[i].r + "," + colorToSave[i].g + "," + colorToSave[i].b + "," + colorToSave[i].a;

            writeFileStr[i] = colorString;
        }

        File.WriteAllLines(Application.persistentDataPath + "/VertexPainter/VertexColors.txt", writeFileStr);

        //Debug.Log("Saved to " + Application.persistentDataPath);

    }

    public void LoadVertexColors()
    {
        string[] readFileStr;
        string clrStr;
        Color clr;

        if (File.Exists(Application.persistentDataPath + "/VertexPainter/VertexColors.txt"))
        {

            readFileStr = File.ReadAllLines(Application.persistentDataPath + "/VertexPainter/VertexColors.txt");

            for (int i = 0; i < readFileStr.Length; i++)
            {
                clrStr = readFileStr[i];
                //Debug.Log("clrStr: " + clrStr);

                string[] strArray = clrStr.Split(',');
                //Debug.Log("strArray: " + strArray[0] + " " + strArray[1] + " " + strArray[2] + " " + strArray[3]);

                clr = new Color(float.Parse(strArray[0]), float.Parse(strArray[1]), float.Parse(strArray[2]), float.Parse(strArray[3]));

                //Debug.Log("clr: " + clr);

                colors[i] = clr;
            }

            mesh.colors = colors;
        }

    }


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, float.MaxValue))
            {

                // Save previous stroke
                if (Input.GetMouseButtonDown(0) && hit.collider)
                {
                    previousColors = mesh.colors;
                }

                // Paint vertices 
                if (hit.collider)
                {

                    //Debug.Log("Cast ray");

                    Vector3 hitPos = go.transform.InverseTransformPoint(hit.point);

                    for (int i = 0; i < vertices.Length; i++)
                    {

                        if (!((vertices[i] - hitPos).magnitude > brushSize))
                            colors[i] = selectedColor;
                        //Debug.Log("Painting!");

                    }

                    mesh.colors = colors;
                }
            }


        }



    }

}

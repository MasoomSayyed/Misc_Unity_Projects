using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private Grid<StringObject> grid;
    private void Start()
    {
        //grid = new Grid<CustomObj>(4, 2, 15f, Vector3.zero, (Grid<CustomObj> g, int x, int y) => new CustomObj(g, x, y));
        grid = new Grid<StringObject>(4, 2, 15f, Vector3.zero, (Grid<StringObject> g, int x, int y) => new StringObject(g, x, y));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //grid.SetValue(position, true);
            /*CustomObj customObj = grid.GetValue(position);
            if (customObj != null)
            {
                customObj.AddValue(5);
            }
            */
        }
        Vector3 position = UtilsClass.GetMouseWorldPosition();
        if (Input.GetKeyDown(KeyCode.A)) { grid.GetValue(position).AddLetter("A"); }
        if (Input.GetKeyDown(KeyCode.B)) { grid.GetValue(position).AddLetter("B"); }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { grid.GetValue(position).AddNumber("1"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { grid.GetValue(position).AddNumber("2"); }
    }
}

public class CustomObj
{
    private Grid<CustomObj> grid;
    private int x;
    private int y;

    private int value;

    public CustomObj(Grid<CustomObj> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue)
    {
        value += addValue;
        grid.TriggerGridObject(x, y);
    }

    public override string ToString()
    {
        return value.ToString();
    }
}

public class StringObject
{
    private Grid<StringObject> grid;
    private int x;
    private int y;

    private string letters;
    private string numbers;

    public StringObject(Grid<StringObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        letters = "";
        numbers = "";
    }

    public void AddLetter(string letter)
    {
        letters += letter;
        grid.TriggerGridObject(x, y);
    }

    public void AddNumber(string number)
    {
        numbers += number;
        grid.TriggerGridObject(x, y);
    }

    public override string ToString()
    {
        return letters + "\n" + numbers;
    }
}
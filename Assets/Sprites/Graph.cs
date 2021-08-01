using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Graph : MonoBehaviour
{
    public GameObject Main;
    public int Day=-1;
    public float Scale=1;
    public LineRenderer line1;
    public LineRenderer line2;
    public LineRenderer line3;


    public TextMeshPro All;
    public TextMeshPro B2;
    public TextMeshPro E2;

    public float MaxWidth= 25;
    public float MaxHeight = 15;
    public List<int> Time1 = new List<int>();

    public List<int> Time2 = new List<int>();

    public List<int> Time3 = new List<int>();



    public static List<Chromosome> TimeStat = new List<Chromosome>();

    public static List<Chromosome> TimeStat2 = new List<Chromosome>();

    public static int HourS=0;
    public static int DayS;
    private void Start()
    {
        HourS = -1;
        DayS = -1;
    }
    private int b;
    private int e;
    public bool IsStat = true;

    public int type=0;


    public int MaxSize;
     void FixedUpdate()
    {

        if (MaxSize < 3)
            MaxSize = 3;
        if(Time1.ToArray().Length>MaxSize)
        {
            int i = 0;
             int[] TimeMod = Time1.ToArray();
            Time1 = new List<int>();
            foreach (int t in TimeMod)
            {
                i++;
                if (i % 2 == 0 && i < TimeMod.Length - 1)
                    Time1.Add(t);
            }
        }
        if (Time2.ToArray().Length > MaxSize)
        {
            int i = 0;
            int[] TimeMod = Time2.ToArray();
            Time2 = new List<int>();
            foreach (int t in TimeMod)
            {
                i++;
                if (i % 2 == 0 && i < TimeMod.Length - 1)
                    Time2.Add(t);
            }
        }
        if (Time3.ToArray().Length > MaxSize)
        {
            int i = 0;
            int[] TimeMod = Time3.ToArray();
            Time3 = new List<int>();
            foreach (int t in TimeMod)
            {
                i++;
                if (i % 2 == 0&&i<TimeMod.Length-1)
                    Time3.Add(t);
            }
        }
        if (DayS!=DayManager.Day)
        {
            DayS = DayManager.Day;
            TimeStat = new List<Chromosome>();
            foreach (Chromosome g in GameObject.FindObjectsOfType<Chromosome>())
            {
                TimeStat.Add(g);
            }
     
         }
        if (HourS != DayManager.Hour)
        {
            HourS =(int) DayManager.Hour;
            TimeStat2 = new List<Chromosome>();
            foreach (Chromosome g in GameObject.FindObjectsOfType<Chromosome>())
            {
                TimeStat2.Add(g);
            }

        }
        line1.enabled = Main.active;
        line2.enabled = Main.active;
        line3.enabled = Main.active;
        if(!IsStat)
            this.GetComponent<LineRenderer>().enabled = false;
        if (type == 0&&TimeStat.ToArray().Length > 1)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;

                    foreach (Chromosome g in TimeStat)
                    {
                        if (g.Bacteria)
                            b++;
                        else
                            e++;
                    }
                    Time1.Add(e);

                    Time2.Add(b);

                    Time3.Add(b + e);
                    if (IsStat)
                    {
                        All.text = "Total Population: " + (b + e);
                        B2.text = "Prokaryotes: " + b;
                        E2.text = "Eukaryotes: " + e;
                    }
                

                Time1.Add(e);

                Time2.Add(b);

                Time3.Add(b + e);
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }


            }
        }
        if (type == 10 && TimeStat2.ToArray().Length > 1)
        {
            if (Day != DayManager.Hour)
            {
                Day = (int)DayManager.Hour;

                b = 0;
                e = 0;

                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                        b++;
                    else
                        e++;
                }



                Time1.Add(e);

                Time2.Add(b);

                Time3.Add(b + e);
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }


            }
        }
        if (type == 9 && TimeStat.ToArray().Length > 1)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;

                foreach (Chromosome g in TimeStat)
                {
                    if (g.Bacteria)
                        b++;
                    else
                        e++;
                }
                Time1.Add(e);

                Time2.Add(b);

                Time3.Add(b + e);
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }


                Time1.Add(e);

                Time2.Add(b);

                Time3.Add(b + e);
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }


            }
        }


        if (type == 1&&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.Speed);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.Speed/2);
                        esize++;
                    }
                }
                Time1.Add(e/esize);

                Time2.Add(b/bsize);

                Time3.Add((b + e)/(esize+bsize));
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }

            }
        }
        else if (type == 2 &&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.Size);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.Size);
                        esize++;
                    }
                }
                Time1.Add(e / esize);

                Time2.Add(b / bsize);

                Time3.Add((b + e) / (esize + bsize));
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }

            }
        }
        else if (type == 3 &&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.Health);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.Health);
                        esize++;
                    }
                }
                Time1.Add(e / esize);

                Time2.Add(b / bsize);

                Time3.Add((b + e) / (esize + bsize));
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }

            }
        }
        else if (type == 4 &&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.Attack*10);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.Attack * 10);
                        esize++;
                    }
                }
                Time1.Add(e / esize);

                Time2.Add(b / bsize);

                Time3.Add((b + e) / (esize + bsize));
                if (IsStat)
                {

                    All.text = "Total Population: " + (bsize-1 + esize-1);
                    B2.text = "Prokaryotes: " + (bsize-1);
                    E2.text = "Eukaryotes: " + (esize-1);
                }

            }
        }
        else if (type == 5 &&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.SenseRange);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.SenseRange);
                        esize++;
                    }
                }
                Time1.Add(e / esize);

                Time2.Add(b / bsize);

                Time3.Add((b + e) / (esize + bsize));
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }

            }
        }
        else if (type == 6 &&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.FoodEfficency);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.FoodEfficency);
                        esize++;
                    }
                }
                Time1.Add(e / esize);

                Time2.Add(b / bsize);

                Time3.Add((b + e) / (esize + bsize));
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }

            }
        }
        else if (type == 7 &&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.ReproductiveUrge);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.ReproductiveUrge);
                        esize++;
                    }
                }
                Time1.Add(e / esize);

                Time2.Add(b / bsize);

                Time3.Add((b + e) / (esize + bsize));
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }

            }
        }
        else if (type == 8 &&TimeStat2.ToArray().Length > 0)
        {
            if (Day != DayManager.Day)
            {
                Day = DayManager.Day;

                b = 0;
                e = 0;
                int bsize = 1;
                int esize = 1;
                foreach (Chromosome g in TimeStat2)
                {
                    if (g.Bacteria)
                    {
                        b += Mathf.RoundToInt(g.FoodCapacity);
                        bsize++;
                    }
                    if (!g.Bacteria)
                    {
                        e += Mathf.RoundToInt(g.FoodCapacity);
                        esize++;
                    }
                }
                Time1.Add(e / esize);

                Time2.Add(b / bsize);

                Time3.Add((b + e) / (esize + bsize));
                if (IsStat)
                {
                    All.text = "Total Population: " + (b + e);
                    B2.text = "Prokaryotes: " + b;
                    E2.text = "Eukaryotes: " + e;
                }

            }
        }


        if (b + e > 0)
        {
            Refresh(line1, Time1);
            Refresh(line2, Time2);
            Refresh(line3, Time3);
        }
    }
    public void Refresh(LineRenderer line,List<int> Timez)
    {
        line.positionCount = Timez.Count+1;
        int pc = line.positionCount;
        int px = 1;
        if (line.positionCount > MaxWidth)
        {
            while (pc > MaxWidth && px < line.positionCount-1)
            {
                if (px % 2 == 0&&Timez.ToArray().Length>px)
                {
                    int val1 = Timez.ToArray()[px - 1];
                    int val2 = Timez.ToArray()[px];
                    int av = Mathf.RoundToInt((val1 + val2) / 2.0f);

                    Timez.RemoveAt(px-1);
                    Timez.RemoveAt(px-1);
                    Timez.Insert(px,av);
                    pc--;
                }
                px++;
            }
        }
        int p = 0;

        line.positionCount = Timez.Count + 1;
        foreach (int i in Timez)
        {

                p++;
            float x = p;
            float y = i / Scale;
            float dx = 1;
      
            if (line.positionCount>MaxWidth)
            {
                 dx = MaxWidth / line.positionCount;

            }

            while (y > MaxHeight)
            {
                Scale+=5;
                 y = i / Scale;
            }

            line.SetPosition(p, new Vector3(x*dx, y, 1));
        }
        if(!IsStat&&line.positionCount>=1)
        line.SetPosition(0, line.GetPosition(1));
    }
}

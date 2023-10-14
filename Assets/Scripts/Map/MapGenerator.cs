using UnityEngine;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public struct Pos
{ 
    public Pos(int x,int y)
    {
        X = x; 
        Y = y;
    }

    public static Pos operator +(Pos pos1, Pos pos2)
    {
        return new Pos(pos1.X + pos2.X, pos1.Y + pos2.Y);
    }
    public static Pos operator -(Pos pos1, Pos pos2)
    {
        return new Pos(pos1.X - pos2.X, pos1.Y - pos2.Y);
    }
    public int X { get; private set; }
    public int Y { get; private set; }
}

public class MapGenerator
{
    public int[,] Map { get; private set; } // 만들어지는 맵을 저장
    private Pos[] Dir = new[] { new Pos(0, -1), new Pos(0,1), new Pos(1, -1), new Pos(1, 1), new Pos(1, 0) }; // 이동 방향 (왼쪽으로는 이동하지 않음)

    public void Init(int lengthX, int lengthY)
    {
        Map = new int[lengthY,lengthX];
        int maxX = lengthX - 1;
        int maxY = lengthY - 1;
        Pos endPos = new Pos(maxX / 2, maxY / 2);
        Generate(endPos, new Pos(maxX, 0));
        Generate(new Pos(0, 0), endPos);
        Generate(new Pos(0, maxY), endPos);
        Generate(endPos, new Pos(maxX, maxY));
        CheckMapWithDebugLog();
    }

    public void Generate(Pos startPos, Pos endPos)
    {
        // 범위를 제한.
        int minX = startPos.X < endPos.X ? startPos.X : endPos.X;
        int maxX = startPos.X > endPos.X ? startPos.X : endPos.X;
        int minY = startPos.Y < endPos.Y ? startPos.Y : endPos.Y;
        int maxY = startPos.Y > endPos.Y ? startPos.Y : endPos.Y;

        DFS(startPos, endPos, minX, maxX, minY, maxY);

    
    }
  
    public void DFS(Pos startPos, Pos endPos, int minX, int maxX, int minY, int maxY)
    {
        Map[startPos.Y,startPos.X] = 1;

        if (startPos.X == endPos.X && startPos.Y == endPos.Y) return;

        List<Pos> nextPos = new List<Pos>();
        List<Pos> prevPos = new List<Pos>();

        foreach(Pos movePos in Dir) 
        {
            Pos pos = startPos + movePos;

            if (CheckPos(pos, minX, maxX, minY, maxY))
            {
                if (CheckVisited(pos))
                {
                    prevPos.Add(pos);
                }
                else
                {
                    nextPos.Add(pos);
                }
            }
        }

        if (nextPos.Count == 0) 
        {
            // 되돌아갈수 밖에 없는 경우
            int randIndex = Random.Range(0,prevPos.Count);
            DFS(prevPos[randIndex], endPos,minX ,maxX, minY, maxY);
            

        }
        else
        {
            int randIndex = Random.Range(0, nextPos.Count);
            DFS(nextPos[randIndex], endPos, minX, maxX, minY, maxY);
        }
        
    }

    public void CheckMapWithDebugLog()
    {
        // Debug.Log()로 현재 만들어진 맵을 확인해봄
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                if (Map[i, j] != 0)
                {
                    sb.Append('o');
                }
                else
                {
                    sb.Append('x');
                }
            }
            sb.AppendLine();

        }

        Debug.Log(sb.ToString());

    }

    public bool CheckVisited(Pos pos) 
    {
        // 해당 좌표에 방문한적 있는지를 판단.
        return Map[pos.Y, pos.X] != 0;
    }
    public bool CheckPos(Pos pos, int minX, int maxX, int minY, int maxY)
    {
        // 해당 Pos 좌표가 정해진 맵을 벗어나는지를 판단.
        return !(pos.X < minX || pos.X > maxX || pos.Y < minY || pos.Y > maxY);
    }
}
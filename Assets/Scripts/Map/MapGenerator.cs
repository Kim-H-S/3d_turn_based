using UnityEngine;
using System.Collections.Generic;
using System.Text;


public class MapGenerator
{
    public Location[,] Map { get; private set; } // 만들어지는 맵을 저장
    private Pos[] pathFindDir = new[] { new Pos(0, -1), new Pos(0,1), new Pos(1, -1), new Pos(1, 1), new Pos(1, 0) }; // 맵의 경로를 정할때 쓰는 방향 (왼쪽이없음)
    private Pos[] Dir = new[] { new Pos(0, -1), new Pos(1, -1), new Pos(1, 0), new Pos(1, 1), new Pos(0, 1), new Pos(-1, 1), new Pos(-1, 0), new Pos(-1, -1) };

    public void Init(int lengthX, int lengthY)
    {
        Map = new Location[lengthY,lengthX];
        int maxX = lengthX - 1;
        int maxY = lengthY - 1;
        Pos endPos = new Pos(maxX / 2, maxY / 2);
        Generate(endPos, new Pos(maxX, 0));
        Generate(new Pos(0, 0), endPos);
        Generate(new Pos(0, maxY), endPos);
        Generate(endPos, new Pos(maxX, maxY));

        CheckAdjLocations();
        //CheckMapWithDebugLog();
    }
    private void Generate(Pos startPos, Pos endPos)
    {
        // 범위를 제한.
        int minX = startPos.X < endPos.X ? startPos.X : endPos.X;
        int maxX = startPos.X > endPos.X ? startPos.X : endPos.X;
        int minY = startPos.Y < endPos.Y ? startPos.Y : endPos.Y;
        int maxY = startPos.Y > endPos.Y ? startPos.Y : endPos.Y;
        DFS(startPos, endPos, minX, maxX, minY, maxY);
    }
    private void DFS(Pos startPos, Pos endPos, int minX, int maxX, int minY, int maxY)
    {
        Map[startPos.Y,startPos.X] = new Location(startPos);

        if (startPos.X == endPos.X && startPos.Y == endPos.Y) return;

        List<Pos> nextPos = new List<Pos>();
        List<Pos> prevPos = new List<Pos>();

        foreach(Pos movePos in pathFindDir) 
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
    private void CheckMapWithDebugLog()
    {
        // Debug.Log()로 현재 만들어진 맵을 확인해봄
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                if (Map[i, j] != null)
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
    private bool CheckVisited(Pos pos) 
    {
        // 해당 좌표에 방문한적 있는지를 판단.
        return Map[pos.Y, pos.X] != null;
    }
    private bool CheckPos(Pos pos, int minX, int maxX, int minY, int maxY)
    {
        // 해당 Pos 좌표가 정해진 맵을 벗어나는지를 판단.
        return !(pos.X < minX || pos.X > maxX || pos.Y < minY || pos.Y > maxY);
    }
    private void CheckAdjLocations()
    {
        int x = Map.GetLength(1);
        int y = Map.GetLength(0);
        for (int i =0; i< y; i++) 
        {
            for(int j =0; j< x; j++)
            {
                if (Map[i, j] == null) continue;
                
                foreach(Pos dir in Dir)
                {
                    Pos pos = Map[i, j].LocationPos + dir;
                    if (CheckPos(pos, 0, x-1, 0, y-1) && CheckVisited(pos)) 
                    {
                        Map[i, j].AdjLocations.Add(pos);//의 전방향을 확인하고 이동가능하다면 해당 Pos를 넣어준다.
                    }
                }
            }
        }
    }
}
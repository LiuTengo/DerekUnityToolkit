using DerekToolkit.GeneralTool.Singleton;
using UnityEngine;

public class USingletonMonoTest : USingletonMono<USingletonMonoTest>
{
    public int GetRandomNumber()
    {
        return Random.Range(0, 100);
    }
}

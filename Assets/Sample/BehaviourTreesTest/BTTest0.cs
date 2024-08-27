using DerekToolkit.GeneralTool.BehaviourTrees;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.DefaultBehavioursTreesTask;
using UnityEngine;

namespace Scenes.BehaviourTreesTest
{
    public class BTTest0 : MonoBehaviour
    {
        private UBehaviourTreesBuilder btBuilder;
        private void Start()
        {
            DebugLogTask debuginfo1 = new DebugLogTask("First Line");
            DebugLogTask debuginfo2 = new DebugLogTask("Second Line");
            
            btBuilder = new UBehaviourTreesBuilder();

            btBuilder.Repeat(1).Sequence().
                        AddTask(debuginfo1).
                        AddTask(debuginfo2).
                    Back().
                End();  
            
           
        }

        private void Update()
        {
            btBuilder.TreeTick();
        }
    }
}
using System.Collections.Generic;
using DerekToolkit.GeneralTool.BehaviourTrees.Base;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Interfaces;
using DerekToolkit.GeneralTool.BehaviourTrees.Composite;
using DerekToolkit.GeneralTool.BehaviourTrees.Decorator;

namespace DerekToolkit.GeneralTool.BehaviourTrees
{
    public class UBehaviourTreesBuilder
    {
        private readonly Stack<UBehaviourNode> nodeStack;//构建树结构用的栈
        private readonly UBehaviourTrees bhTree;//构建的树
        public UBehaviourTreesBuilder()
        {
            bhTree = new UBehaviourTrees(null);//构造一个没有根的树
            nodeStack = new Stack<UBehaviourNode>();//初始化构建栈
        }
        private void AddBehavior(UBehaviourNode behavior)
        {
            if (bhTree.hasRoot)//有根节点时，加入构建栈
            {
                nodeStack.Peek().AddBehaviour(behavior);
            }
            else //当树没根时，新增得节点视为根节点
            {
                bhTree.SetBehaviourTreesRoot(behavior);
            }
            //只有组合节点和修饰节点需要进构建堆
            if (behavior is UComposite || behavior is UDecorator)
            {
                nodeStack.Push(behavior);
            }
        }
        public void TreeTick()
        {
            bhTree.Tick();
        }
        public UBehaviourTreesBuilder Back()
        {
            nodeStack.Pop();
            return this;
        }
        public UBehaviourTrees End()
        {
            nodeStack.Clear();
            return bhTree;
        }
        
        public UBehaviourTreesBuilder Sequence()
        {
            var tp = new USequenceComposite();
            AddBehavior(tp);
            return this;
        }
        public UBehaviourTreesBuilder Seletctor()
        {
            var tp = new USelectComposite();
            AddBehavior(tp);
            return this;
        }
        
        public UBehaviourTreesBuilder Parallel(EParallelBehaviourPolicy success, EParallelBehaviourPolicy failure)
        {
            var tp = new UParallelComposite(success, failure);
            AddBehavior(tp);
            return this;
        }
        
        public UBehaviourTreesBuilder Repeat(int limit)
        {
            var tp = new URepeatDecorator(limit);
            AddBehavior(tp);
            return this;
        }
        public UBehaviourTreesBuilder Invert()
        {
            var tp = new UInvertDecorator();
            AddBehavior(tp);
            return this;
        }
        
        public UBehaviourTreesBuilder AddTask(IBehaviourTreesTask task)
        {
            var node = new UBehaviourTreesTaskNode(task);
            AddBehavior(node);
            return this;
        }
    }
}
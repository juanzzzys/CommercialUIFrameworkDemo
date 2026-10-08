using System;
using System.Collections.Generic;

public class RedDotNode
{
    public RedDotNode Parent;

    public List<RedDotNode> Children = new List<RedDotNode>();

    public bool HasRedDot { get; private set; }

    public event Action<RedDotNode, bool> OnStateChanged;

    public void SetRedDot(bool value)
    {
        bool oldState = HasRedDot;

        // 叶子节点：直接使用传入状态
        if (Children.Count == 0)
        {
            HasRedDot = value;
        }
        // 父节点：根据子节点重新计算
        else
        {
            HasRedDot = false;

            foreach (RedDotNode child in Children)
            {
                if (child.HasRedDot)
                {
                    HasRedDot = true;
                    break;
                }
            }
        }

        // 状态没有变化，不继续处理
        if (oldState == HasRedDot)
            return;

        // 告诉 System：我这个 Node 状态变了
        OnStateChanged?.Invoke(this, HasRedDot);

        // 向父节点冒泡
        if (Parent != null)
        {
            Parent.SetRedDot(HasRedDot);
        }
    }
}
using System.Collections.Generic;

namespace Shop.TreeRelated
{
    public interface ITreeNode<T>
    {
        ITreeNode<T> Parent { get; set; }

        List<ITreeNode<T>> Children { get; }

        T Value { get; set; }

        IEnumerable<ITreeNode<T>> GetLeafs();
    }
}

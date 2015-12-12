using System.Collections.Generic;
using System.Linq;

namespace Shop.TreeRelated
{
    public class TreeNode<T> : ITreeNode<T> 
        where T : IIdentifiable, IChild
    {
        public TreeNode(T value)
        {
            Value = value;
            Children = new List<ITreeNode<T>>();
        }

        public ITreeNode<T> Parent { get; set; }

        public List<ITreeNode<T>> Children { get; set; }

        public T Value { get; set; }

        public IEnumerable<ITreeNode<T>> GetLeafs()
        {
            if (!Children.Any())
                yield return this;
            foreach (var leaf in Children.SelectMany(child => child.GetLeafs()))
            {
                yield return leaf;
            }
        }
    }
}
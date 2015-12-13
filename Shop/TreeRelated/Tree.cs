using System.Collections.Generic;
using System.Linq;
using Shop.Models;

namespace Shop.TreeRelated
{
    public class Tree<T> where T : IIdentifiable, IChild
    {
        private readonly List<ITreeNode<T>> roots;

        private readonly List<ITreeNode<T>> flatNodes; 

        public Tree(IEnumerable<T> items)
        {
            flatNodes = new List<ITreeNode<T>>(items.Select(it => new TreeNode<T>(it)));
            roots = new List<ITreeNode<T>>();
            var nodesDict = flatNodes.ToDictionary(it => it.Value.Id, it => it);
            foreach (var item in nodesDict)
            {
                if (item.Value.Value.ParentId == null)
                    roots.Add(item.Value);
                else
                {
                    var parent = nodesDict[item.Value.Value.ParentId.Value];
                    parent.Children.Add(item.Value);
                    item.Value.Parent = parent;
                }
            }
        }

        public List<ITreeNode<T>> Roots
        {
            get
            {
                return roots;
            }
        }

        public List<ITreeNode<T>> FlatNodes
        {
            get
            {
                return flatNodes;
            }
        }

        public IEnumerable<ITreeNode<T>> Leafs
        {
            get
            {
                return roots.SelectMany(r => r.GetLeafs());
            }
        }

        public ITreeNode<T> GetNodeById(int id)
        {
            return FlatNodes.FirstOrDefault(nd => nd.Value.Id == id);
        }
    }
}
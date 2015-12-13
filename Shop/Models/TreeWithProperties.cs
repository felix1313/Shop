using System.Collections.Generic;
using Shop.TreeRelated;

namespace Shop.Models
{
    public class TreeWithProperties
    {
        private readonly Tree<ItemModel> tree;

        private readonly IEnumerable<UnitPropertyModel> properties;

        public TreeWithProperties(Tree<ItemModel> tree, IEnumerable<UnitPropertyModel> properties)
        {
            this.tree = tree;
            this.properties = properties;
        }

        public Tree<ItemModel> Tree
        {
            get { return tree; }
        }

        public IEnumerable<UnitPropertyModel> Properties
        {
            get { return properties; }
        }
    }
}
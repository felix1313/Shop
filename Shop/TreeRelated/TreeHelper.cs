using System.Collections.Generic;
using System.Linq;
using Shop.Models;

namespace Shop.TreeRelated
{
    public static class TreeHelper
    {
        public static void FillNodePropertyValues(
            this Tree<ItemModel> tree,
            List<UnitPropertyModel> propertyModels,
            IEnumerable<UnitPropertyValueModel> propertyValues)
        {
            var propDict = propertyModels.GroupBy(p => p.UnitId).ToDictionary(p => p.Key, p => p.ToList());
            var propNameDict = propertyModels.ToDictionary(p => p.Id, p => p.Name);
            var propValsDict = propertyValues
                .GroupBy(p => p.UnitId)
                .ToDictionary(p => p.Key,
                    p => p.GroupBy(g => g.PropertyId).ToDictionary(g => propNameDict[g.Key], g => g.FirstOrDefault()));
            foreach (var node in tree.FlatNodes)
            {
                if (!propDict.ContainsKey(node.Value.Id))
                    continue;
                var nodeProps = propDict[node.Value.Id];
                foreach (var prop in nodeProps)
                {
                    var clone = prop.Clone();
                    if (!node.Children.Any())
                        clone.PropertyValue = propValsDict[node.Value.Id][clone.Name];
                    node.Value.Properties.Add(clone.Name, clone);
                }
            }

            foreach (var root in tree.Roots)
            {
                SetNodeProps(root, root.Value.Properties, propValsDict);
            }
        }

        private static void SetNodeProps(
            ITreeNode<ItemModel> node,
            Dictionary<string, UnitPropertyModel> props,
            Dictionary<int, Dictionary<string, UnitPropertyValueModel>> propVals)
        {
            var newList = new Dictionary<string, UnitPropertyModel>(props);
            var nodeProps = node.Value.Properties;
            foreach (var prop in newList)
            {
                if (!nodeProps.ContainsKey(prop.Value.Name))
                {
                    var newProp = prop.Value.Clone();
                    if (!node.Children.Any())
                        newProp.PropertyValue = propVals[node.Value.Id][newProp.Name];
                    nodeProps.Add(newProp.Name, newProp);
                }
            }
            foreach (var prop in nodeProps.Where(prop => !newList.ContainsKey(prop.Key)))
            {
                newList.Add(prop.Key, prop.Value);
            }
            foreach (var child in node.Children)
            {
                SetNodeProps(child, newList, propVals);
            }
        }
    }
}
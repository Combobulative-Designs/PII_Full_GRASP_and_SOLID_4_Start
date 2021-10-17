using System.Linq;

namespace Full_GRASP_And_SOLID
{
    public class EquipmentCatalog : Catalog<Equipment>
    {
        public void AddToCatalog(string description, double hourlyCost)
        {
            Equipment equipment = new Equipment(description, hourlyCost);
            itemCatalog.Add(equipment);
        }

        public override Equipment GetItem(string description)
        {
            var query = from Equipment equipment in itemCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}
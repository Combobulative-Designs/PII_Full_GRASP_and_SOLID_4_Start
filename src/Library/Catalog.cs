using System.Collections.Generic;

namespace Full_GRASP_And_SOLID
{
    public abstract class Catalog<T>
    {
        protected List<T> itemCatalog = new List<T>();

        public abstract T GetItem(string description);

        public T ItemAt(int index)
        {
            return itemCatalog[index];
        }
    }
}
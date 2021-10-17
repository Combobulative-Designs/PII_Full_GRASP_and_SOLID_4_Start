//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID
{
    public class Program
    {

        /*
            Cambiamos la clase recipe para que de acuerdo al patron Creator sea esta la que
            crea la los objetos Step para agregar a receta en lugar de recibirlo.

            Tambien agregamos las clases ProductCatalog y EquipmentCatalog derivados de la
            clase abstracta Catalog para manejar la creacion y almacenamiento de productos
            y equipamiento.

            Con estas medidas, pasamos a utilizar Creator y Herencia.
        */

        private static ProductCatalog productCatalog = new ProductCatalog();

        private static EquipmentCatalog equipmentCatalog = new EquipmentCatalog();

        //private static List<Product> productCatalog = new List<Product>();
        //private static List<Equipment> equipmentCatalog = new List<Equipment>();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = productCatalog.GetItem("Café con leche");
            //recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(productCatalog.GetItem("Café"), 100, equipmentCatalog.GetItem("Cafetera"), 120);
            //recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));
            recipe.AddStep(productCatalog.GetItem("Leche"), 200, equipmentCatalog.GetItem("Hervidor"), 60);


            IPrinter printer;
            printer = new ConsolePrinter();
            printer.PrintRecipe(recipe);
            printer = new FilePrinter();
            printer.PrintRecipe(recipe);
        }

        private static void PopulateCatalogs()
        {
            productCatalog.AddToCatalog("Café", 100);
            productCatalog.AddToCatalog("Leche", 200);
            productCatalog.AddToCatalog("Café con leche", 300);

            equipmentCatalog.AddToCatalog("Cafetera", 1000);
            equipmentCatalog.AddToCatalog("Hervidor", 2000);

            /*
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
            */
        }

        /*
        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
        */
    }
}

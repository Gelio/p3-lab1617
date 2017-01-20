using System;
using System.Collections.Generic;
using System.Linq;

namespace L14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Race> races = new List<Race>();
            List<Building> buildings = new List<Building>();
            List<Unit> units = new List<Unit>();

            //Filling data
            races.Add(new Race(0, "Ork"));
            races.Add(new Race(1, "Space Marine"));
            races.Add(new Race(2, "Imperial Guard"));

            buildings.Add(new Building(0, "Stronghold", 0, 400, -1, 1));
            buildings.Add(new Building(1, "Plasma Generator", 0, 100, 0, 1));
            buildings.Add(new Building(2, "Chapel-Barracks", 0, 250, 0, 1));
            buildings.Add(new Building(3, "Armoury", 25, 150, 2, 1));
            buildings.Add(new Building(4, "Machine Cult", 150, 250, 2, 1));
            buildings.Add(new Building(5, "Settlement", 0, 400, -1, 0));
            buildings.Add(new Building(6, "Da Boyz Hut", 0, 250, 5, 0));
            buildings.Add(new Building(7, "Waaagh! Banner", 0, 125, 5, 0));
            buildings.Add(new Building(8, "Da Mek Shop", 250, 125, 6, 0));
            buildings.Add(new Building(9, "Pile O Gunz!", 125, 25, 6, 0));

            units.Add(new Unit(0, "Servitor", 0, 50, 0, 1));
            units.Add(new Unit(1, "Space Marine", 0, 50, 2, 1));
            units.Add(new Unit(2, "Grey Knights", 50, 50, 2, 1));
            units.Add(new Unit(3, "Rhino Transport", 150, 150, 4, 1));
            units.Add(new Unit(4, "Dreadnought ", 125, 350, 4, 1));
            units.Add(new Unit(5, "Chaplain", 100, 150, 2, 1));
            units.Add(new Unit(6, "Ork Boyz", 0, 50, 6, 0));
            units.Add(new Unit(7, "Mad Dok", 50, 150, 6, 0));
            units.Add(new Unit(8, "Killa Kan", 150, 150, 8, 0));
            units.Add(new Unit(9, "Gretchin", 0, 25, 5, 0));

            Console.WriteLine("\n-> ETAP 1 (0.5 pkt.)\n");
            // Napisz zapytanie które zwróci listę z nazwami jednostek dla rasy "Ork" (w wynikach są tylko nazwy jednostek)
            var orcs = from race in races
                       where race.Name == "Ork"
                       join unit in units on race.Id equals unit.RaceId
                       select unit;

            var orcUnits = from orc in orcs
                           select orc.Name;

             print(orcUnits);

            Console.WriteLine("\n-> ETAP 2 (1.0 pkt.)\n");
            // Napisz zapytanie które zwróci listę nazw jednostek dla rasy "Ork", wraz z nazwą budynku oraz kosztem budowy jednostki (gaz i minerały)

            var orcUnitsWithBuildings = from orc in orcs
                                        join building in buildings on orc.BuildingId equals building.Id
                                        select new { orc.Name, BuildingName = building.Name, building.CostGas, building.CostMinerals };

             print(orcUnitsWithBuildings);

            Console.WriteLine("\n-> ETAP 3 (1.0 pkt.)\n");
            // Napisz zapytanie które zwróci listę nazw jednostek wraz z nazwą budynku którego wymagają, tylko dla budyków które wymagają innego budynku do wybudowania
            // (budynki nie wymagające innego bydynku pomijamy)

            var unitsWithBuildingsWithRequirements = from unit in units
                                                     join building in buildings on unit.BuildingId equals building.Id
                                                     where building.BuildingId != -1
                                                     select new { unit.Name, BuildingName = building.Name };
        
             print(unitsWithBuildingsWithRequirements);

            Console.WriteLine("\n-> ETAP 4 (1.0 pkt.)\n");
            // Napisz zapytanie które zwróci liczbę różnych rodzajów jednostek zgrupowanych po konkretnym koszcie

            var unitCountByBuildingByCost = from unit in units
                                            group unit by new { unit.CostGas, unit.CostMinerals } into unitsGrouped
                                            select new { unitsGrouped.Key.CostGas, unitsGrouped.Key.CostMinerals, Count = unitsGrouped.Count() };
            print(unitCountByBuildingByCost);

            Console.WriteLine("\n-> ETAP 5 (1.5 pkt.)\n");
            // Napisz zapytanie które zwróci całkowity koszt budynków które należy wybudować (zaczynamy bez ani jednego budynku wybudowanego),
            // aby móc wybudować budynek "Machine Cult" (wraz z kosztem "Machine Cult")

            
            int machineCultID = (from building in buildings
                                 where building.Name == "Machine Cult"
                                 select building.Id).Single();
            var totalCost = buildings.SelectIterative(machineCultID).Aggregate(new { TotalGasCost = 0, TotalMineralCost = 0 }, (previousCost, building) => new
            {
                TotalGasCost = previousCost.TotalGasCost + building.CostGas,
                TotalMineralCost = previousCost.TotalMineralCost + building.CostMinerals
            });
            var unitRequiredBuildingsTotalCost = Enumerable.Repeat(totalCost, 1);

            print(unitRequiredBuildingsTotalCost);

            Console.WriteLine("\n-> KONIEC\n");
        }

        public static void print(System.Collections.IEnumerable data)
        {
            foreach (var t in data)
            {
                Console.WriteLine(t);
            }
        }

    }

    public static class EnumerableExtensions
    {

        public static IEnumerable<Building> SelectIterative(this IEnumerable<Building> source, int id)
        {
            Building b;
            List<Building> lb = new List<Building>();
            while ( id>=0 )
                {
                b = (from s in source where s.Id==id select s).Single();
                lb.Add(b);
                id=b.BuildingId;
                }
            return lb;
        }

    }

}

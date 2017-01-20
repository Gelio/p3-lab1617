
namespace L14
{

    public class Race
    {

        /// <summary>
        /// Identyfikator rasy
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Nazwa rasy
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Konstruktor rasy (Race)
        /// </summary>
        /// <param name="id">Identyfikator rasy</param>
        /// <param name="name">Nazwa rasy</param>
        public Race(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }

    public class Building
    { 

        /// <summary>
        /// Identyfikator budynku
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Nazwa budynku
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Koszt budowy w gazie
        /// </summary>
        public int CostGas { get; }

        /// <summary>
        /// Koszt budowy w minerałach
        /// </summary>
        public int CostMinerals { get; }

        /// <summary>
        /// Identyfikator budynku wymaganego by zbudować ten budynek
        /// </summary>
        public int BuildingId { get; }

        /// <summary>
        /// Identyfikator rasy dla której przynależy ten budynek
        /// </summary>
        public int RaceId { get; }

        /// <summary>
        /// Konstruktor budynku (Building)
        /// </summary>
        /// <param name="id">Identyfikator budynku</param>
        /// <param name="name">Nazwa budynku</param>
        /// <param name="costGas">Koszt budowy w gazie</param>
        /// <param name="costMinerals">Koszt budowy w minerałach</param>
        /// <param name="buildingId">Identyfikator budynku wymaganego by zbudować ten budynek</param>
        /// <param name="raceId">Identyfikator rasy dla której przynalezy ten budynek</param>
        public Building(int id, string name, int costGas, int costMinerals, int buildingId, int raceId)
        {
            Id = id;
            Name = name;
            RaceId = raceId;
            BuildingId = buildingId;
            CostGas = costGas;
            CostMinerals = costMinerals;
        }

    }

    public class Unit
    {

        /// <summary>
        /// Identyfikator jednostki
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Nazwa jednostki
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Koszt budowy w gazie
        /// </summary>
        public int CostGas { get; }

        /// <summary>
        /// Koszt budowy w minerałach
        /// </summary>
        public int CostMinerals { get; }

        /// <summary>
        /// Identyfikator budynku wymaganego by zbudować tę jednostkę
        /// </summary>
        public int BuildingId { get; }

        /// <summary>
        /// Identyfikator rasy dla której przynależy tę jednostka
        /// </summary>
        public int RaceId { get; }

        /// <summary>
        /// Konstruktor jednostki (Unit)
        /// </summary>
        /// <param name="id">Identyfikator jednostki</param>
        /// <param name="name">Nazwa jednostki</param>
        /// <param name="costGas">Koszt budowy w gazie</param>
        /// <param name="costMinerals">Koszt budowy w minerałach</param>
        /// <param name="buildingId">Identyfikator budynku wymaganego by zbudować te jednostkę</param>
        /// <param name="raceId">Identyfikator rasy dla której przynależy ta jednostka</param>
        public Unit(int id, string name, int costGas, int costMinerals, int buildingId, int raceId)
        {
            Id = id;
            Name = name;
            RaceId = raceId;
            BuildingId = buildingId;
            CostGas = costGas;
            CostMinerals = costMinerals;
        }

    }

}
namespace FluentBuilderPattern
{
    public class MarineUnitBuilder
    {
        private readonly MarineUnit _unit = new();
        
        private MarineUnitBuilder() { }
        
        public static MarineUnitBuilder Initialize() => 
            new MarineUnitBuilder();

        public object WithName(string name)
        {
            _unit.UnitName = name;
            return this;
        }
    }
}
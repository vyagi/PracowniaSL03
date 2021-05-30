using System.Collections;
using System.Collections.Generic;

namespace FluentBuilderPattern
{
    public class MarineUnitBuilder : INameSetter, IIntendedUseSetter
        ,IDimensionsSetter, IMechanicalInstallationSetter, IVersatileInstallationSetter
        ,IElectricalInstallationSetter, IBrandAndModelSetter, IMarineUnitBuilder
    {
        private readonly MarineUnit _unit = new();

        private readonly List<ElectricalInstallation> _electricalInstallations = new();

        private MarineUnitBuilder() { }
        
        public static INameSetter Initialize() => 
            new MarineUnitBuilder();

        public IIntendedUseSetter WithName(string name)
        {
            _unit.UnitName = name;
            return this;
        }

        public IDimensionsSetter WithIntendedUse(UnitIntendedUse intendedUse)
        {
            _unit.UnitIntendedUse = intendedUse;
            return this;
        }

        public IMechanicalInstallationSetter WithDimensions(Dimensions dimensions)
        {
            _unit.Dimensions = dimensions;
            return this;
        }

        public IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation)
        {
            _unit.MechanicalInstallation = mechanicalInstallation;
            return this;
        }

        public IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation)
        {
            _unit.VersatileInstallation = versatileInstallation;
            return this;
        }

        public IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation)
        {
            _electricalInstallations.Add(electricalInstallation);
            return this;
        }

        public IBrandAndModelSetter WithNoMoreElectricalInstallations()
        {
            _unit.ElectricalInstallation = _electricalInstallations.ToArray();
            return this;
        }

        public IMarineUnitBuilder WithBrandAndModel(string brand, string model)
        {
            _unit.Brand = brand;
            _unit.Model = model;
            return this;
        }

        public MarineUnit Build() => _unit;
    }

    public interface IMarineUnitBuilder
    {
        MarineUnit Build();
    }

    public interface IBrandAndModelSetter
    {
        IMarineUnitBuilder WithBrandAndModel(string brand, string model);
    }

    public interface IElectricalInstallationSetter
    {
        IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation);
        IBrandAndModelSetter WithNoMoreElectricalInstallations();
    }

    public interface IVersatileInstallationSetter
    {
        IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation);
    }

    public interface IMechanicalInstallationSetter
    {
        IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation);
    }

    public interface IDimensionsSetter
    {
        IMechanicalInstallationSetter WithDimensions(Dimensions dimensions);
    }

    public interface IIntendedUseSetter
    {
        IDimensionsSetter WithIntendedUse(UnitIntendedUse intendedUse);
    }

    public interface INameSetter
    {
        IIntendedUseSetter WithName(string name);
    }
}
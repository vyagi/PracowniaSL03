using System;
using FluentBuilderPattern;

namespace MarineUnitConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var newUnit = MarineUnitBuilder
                .Initialize()
                .WithName("Luna")
                .WithIntendedUse(new UnitIntendedUse(TypeOfUse.MarineCommercial, "a", "b"))
                .WithDimensions(new Dimensions(10, 10, 10))
                .WithMechanicalInstallation(new MechanicalInstallation())
                .WithVersatileInstallation(new VersatileInstallation())
                .WithElectricalInstallation(new ElectricalInstallation())
                .WithNoMoreElectricalInstallations()
                .WithBrandAndModel("James", "Bond")
                .Build();

            Console.WriteLine(newUnit.ElectricalInstallation.Length);
        }
    }
}

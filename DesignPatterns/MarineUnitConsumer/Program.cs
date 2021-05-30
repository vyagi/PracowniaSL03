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
                .WithName("Cosmos");

            var unit = new MarineUnit();
        }
    }
}

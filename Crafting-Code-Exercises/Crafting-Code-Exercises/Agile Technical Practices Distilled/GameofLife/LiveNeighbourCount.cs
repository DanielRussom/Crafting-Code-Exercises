﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class LiveNeighbourCount
    {
        public LiveNeighbourCount(int value)
        {
            _value = value;
        }

        private int _value;

        public void IncrementBy(LiveNeighbourCount liveNeighbourCount)
        {
            _value += liveNeighbourCount._value;
        }

        public PopulationState IsUnderPopulated()
        {
            if (_value < 2) return PopulationState.UnderPopulated;
            return PopulationState.NotUnderPopulated;
        }
    }
}
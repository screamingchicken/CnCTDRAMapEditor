﻿//
// Copyright 2020 Electronic Arts Inc.
//
// The Command & Conquer Map Editor and corresponding source code is free 
// software: you can redistribute it and/or modify it under the terms of 
// the GNU General Public License as published by the Free Software Foundation, 
// either version 3 of the License, or (at your option) any later version.

// The Command & Conquer Map Editor and corresponding source code is distributed 
// in the hope that it will be useful, but with permitted additional restrictions 
// under Section 7 of the GPL. See the GNU General Public License in LICENSE.TXT 
// distributed with this program. You should have received a copy of the 
// GNU General Public License along with permitted additional restrictions 
// with this program. If not, see https://github.com/electronicarts/CnC_Remastered_Collection
using System.Drawing;
using System.IO;

namespace MobiusEditor.TiberianDawn
{
    public static class Constants
    {
        public static readonly string SaveDirectory = Path.Combine(Globals.RootSaveDirectory, "Tiberian_Dawn");

// MegaMap support - default size is 64x64, but can be updated.
        public static Size MaxSize = new Size(64, 64);

// MegaMap support - use the Sole Survivor binary format when saving 128x128 maps. 64x64 will always remain in their own format.
        public static readonly bool SoleSurvivorMapFormat = true;

        public static void AlterMaxSize(int NewWidth, int NewHeight)
        {
            MaxSize.Width = NewWidth;
            MaxSize.Height = NewHeight;

        }

        public const int MaxAircraft = 100;
        public const int MaxBuildings = 500;
        public const int MaxInfantry = 500;
        public const int MaxTerrain = 500;
        public const int MaxUnits = 500;
        public const int MaxTeams = 60;
        public const int MaxTriggers = 80;
    }
}

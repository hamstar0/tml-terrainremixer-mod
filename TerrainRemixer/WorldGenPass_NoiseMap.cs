﻿using System;
using Terraria;
using Terraria.World.Generation;
using ModLibsCore.Libraries.Debug;
using FastNoiseCSharp;


namespace TerrainRemixer {
	partial class TerrainRemixerGenPass : GenPass {
		public static (float[] map, float minVal, float maxVal) GetNoiseMap(
					int width,
					int height,
					float frequency,
					FastNoise.FractalType wormsMode,
					float sharpness,
					//bool isPerturbed,
					out FastNoise noise ) {
			float[] map = new float[ width * height ];

			noise = new FastNoise( WorldGen.genRand.Next() );
			noise.SetNoiseType( FastNoise.NoiseType.SimplexFractal );
			noise.SetFrequency( frequency );
			noise.SetFractalType( wormsMode );
			noise.SetFractalGain( sharpness );

			int coord;
			float min = 0, max = 0, val;

			for( int x=0; x<width; x++ ) {
				for( int y=0; y<height; y++ ) {
					coord = x + (y*width);
					val = noise.GetNoise( x, y );

					if( min > val ) {
						min = val;
					} else if( max < val ) {
						max = val;
					}

					map[coord] = val;
				}
			}

			return (map, min, max);
		}

		internal static int GetMapCoord( int tileX, int tileY, int startHeight ) {
			return tileX + ((tileY-startHeight) * Main.maxTilesX);
		}
	}
}
